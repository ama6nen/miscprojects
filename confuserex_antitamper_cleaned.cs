			Module module = typeof(AntiTamperNormal).Module;
			string name = module.FullyQualifiedName;
			bool is_unknown = name.Length > 0 && name[0] == '<'; //<Unknown> name or <Module> (not sure if it can be <Module>)
			var header = (byte*)Marshal.GetHINSTANCE(module);
			byte* signature = header + *(uint*)(header + 0x3c); //0x80
			ushort numofsections = *(ushort*)(signature + 0x6); //0x86
			ushort sizeofoptionalheader = *(ushort*)(signature + 0x14); //0x94

			uint* enc_loc = null;
			uint enc_size = 0;
			var textsection = (uint*)(signature + 0x18 + sizeofoptionalheader); //0x178 because size is 0xE0 usually
			uint key1 = (uint)Mutation.KeyI1, key2 = (uint)Mutation.KeyI2, key3 = (uint)Mutation.KeyI3, key4 = (uint)Mutation.KeyI4;
			//og names: z , x, c , v
			for (int i = 0; i < numofsections; i++) { //loop sections?
				uint sect_namehash = (*textsection++) * (*textsection++); //name1 * name2
				if (sect_namehash == (uint)Mutation.KeyI0) { //namehash == mutationkey0(aka just original name1*name2)
					enc_loc = (uint*)(header + (is_unknown ? *(textsection + 3) : *(textsection + 1))); //reader.ReadUInt32();
					enc_size = (is_unknown ? *(textsection + 2) : *(textsection + 0)) >> 2; //reader.ReadUInt32();
				}
				else if (sect_namehash != 0) {
					var section_loc = (uint*)(header + (is_unknown ? *(textsection + 3) : *(textsection + 1))); //reader.ReadUInt32();
					uint section_size = *(textsection + 2) >> 2; //reader.ReadUInt32();
					for (uint k = 0; k < section_size; k++) { //Hash(stream, reader, sectLoc, sectSize);
						uint temp = (key1 ^ (*section_loc++)) + key2 + key3 * key4;
						key1 = key2;
						key2 = key3;
						key2 = key4; //creator prob meant key3=key4 but who cares
						key4 = temp;
					}
				}
				textsection += 8;
			}

			uint[] destination = new uint[0x10], source = new uint[0x10]; 
			for (int i = 0; i < 0x10; i++) { //Deriving the key
				destination[i] = key4;
				source[i] = key2;
				key1 = (key2 >> 5) | (key2 << 27);
				key2 = (key3 >> 3) | (key3 << 29);
				key3 = (key4 >> 7) | (key4 << 25);
				key4 = (key1 >> 11) | (key1 << 21);
			}
			Mutation.Crypt(destination, source);

			uint allperms = 0x40;
			VirtualProtect((IntPtr)enc_loc, enc_size << 2, allperms, out allperms);

			if (allperms == 0x40) //old perms were already 0x40, return so we dont do 2nd time and fuck ctor
				return;

			for (uint i = 0; i < enc_size; i++) {
				*enc_loc ^= destination[i & 0xf];
				destination[i & 0xf] = (destination[i & 0xf] ^ (*enc_loc++)) + 0x3dbb2819;
			}