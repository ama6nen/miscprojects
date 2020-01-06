things to keep in mind:
-this code is horrible
-doesnt work anymore
-contains stitched together snippets from across different files



	static const unsigned char payloadLocalplayer[] = {  0x4c, 0x8b, 0xe8, 0x50, 0x48, 0xB8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x51, 0x48, 0x8b, 0xcF , 0xFF, 0x10, 0x59, 0x58,  0x49 , 0x8b, 0xc5,  0x49, 0xBD, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x83, 0xc4, 0x28, 0xc3 };
	static const unsigned char payloadLocalplayerBig[] = { 0x48, 0x8B , 0x80, 0x20 , 0x01 , 0x00 , 0x00, 0x4c, 0x8b, 0xe8, 0x50, 0x48, 0xB8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x51, 0x48, 0x8b, 0xcb , 0xFF, 0x10,0x59, 0x58,0x49 , 0x8b, 0xc5, 0x48, 0x83, 0xc4, 0x28, 0xc3 };

	static const unsigned char payloadChatMsg[] = { 0x51, 0x49, 0x8b, 0xcb, 0x00,0x00,0x00,0x00,0x00, 0x59, 0x48, 0x8b, 0xc4, 0x55, 0x41, 0x56 ,0x00,0x00,0x00,0x00,0x00 };
	static const unsigned char payloadChatMsgBig[] = { 0x51, 0x49, 0x8b, 0xcb, 0x00,0x00,0x00,0x00,0x00, 0x59, 0x48, 0x8b, 0xc4, 0x55, 0x41, 0x56,0x41,0x57,0x48,0x8d,0xa8,0x08,0xfe,0xff,0xff , 0xFF, 0x25, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00, 00 };
}


bool overrideColor = false;
char color = '1';
static char* meme = "w";
 void hook_chatmsgreceived(DWORD64 r11)
{
	if (r11 && options::LogEverything)
	ConsolePrint("[HOOK] LogToconsoleSafe called! R11 is %llX \n", r11);

	if (r11 && r11 > 0x1500) //sometime r11 is small values that arent valid so we dont want to memcpy then & crash
	{
		char dump[255];
		int counter = 0;
		char color2 = color;
		for (int i = 0; i < 255; i++) 
		{
			BYTE asd = *(BYTE*)(r11 + i);
			counter++;
			dump[i] = (char)asd;

			if (asd == 0x00)
				break;
		}
		if ( counter > 5 )
		{
			char* ptr2 = strstr( dump, "````>" );

			if ( ptr2 )
			{
				int position = ptr2 - dump;
				memcpy( (DWORD64*)( r11 + position + 3 ), (void*)meme, 1 );
				if ( playerStruct && !inOtherActivity )
					memcpy( &playerStruct->Playername[ 1 ], (void*)meme, 1 );
			}

		}

		char* ptr = strstr( dump, "!color " );
		if (ptr)
		{
			    BYTE asd = *(BYTE*)( ptr + 7 );
				ConsolePrint( "Found command (color) => %c\n", (char)(asd) );
				overrideColor = true;
				color = (char)asd;
				meme = &color;
		}
		ConsolePrint("Original message: %s \n",dump);
	}


	static void* unkn = nullptr;
	if (!unkn)
	{
		if((gt > (DWORD64*)0xFFFFFFFFF))
			unkn = (char*)&(payloadChatMsgBig[0]);
		else
			unkn = (char*)&(payloadChatMsg[0]);
	}
	unkn; //idk crashes if i dont do this
}

bool pValidPLayer = false;
void hook_getlocalplayer(DWORD64 rbx)
{
  if (options::LogEverything)
		ConsolePrint("[HOOK] GetLocalPlayer called! RBX is %llX \n", rbx);
  return;

	if (IsValidPlayer(gt, rbx, lastRbx, inOtherActivity))
	{
		playerStruct = (Playerstruct*)rbx;
	
		if (options::LogEverything && lastValidRbx != rbx)
		ConsolePrint("[HOOK] Detected localplayer as %llX\n", rbx);
		lastValidRbx = rbx;
	}
	else
	{
		
		/*if (options::LogEverything)
		ConsolePrint("[HOOK] Not localplayer, %llX\n", rbx);*/

	
	}
		
	lastRbx = rbx;
}


DWORD WINAPI Setup(LPVOID base)
{
	try 
	{
		AttachConsole();

		system("color 0a");

		ConsolePrint("Successfully injected to Growtopia \n");

	    gt = (DWORD64*)GetModuleHandle(NULL);

		ConsolePrint("Base address: %llX\n", gt);

		bool needsBig = (gt > (DWORD64*)0xFFFFFFFFF);

		if (needsBig)
			ConsolePrint("Detected need for big jmp \n");
		

		if (options::BanBypass)
		{
			const auto banBypass = (DWORD64*)(PatternSearch("", banbypass::sig(), banbypass::mask(), NULL, NULL) + 3);
			const BYTE Patch[] = { 0x90, 0x90 };
			if (banBypass)
			{
				ConsolePrint( "Ban bypass: %llX\n", banBypass );

				auto bypassed = write( banBypass, sizeof( Patch ), &Patch   );

				if ( bypassed )
					ConsolePrint( "patched successfully\n" );
				else
					ConsolePrint( "patch failed\n" );
			
			}
			else
				ConsolePrint("Ban bypass sig is outdated\n");

		}
		
		if (options::hookChat)
		{
			const auto chatMsgAddy = (DWORD64*)(PatternSearch("", chatmsg::sig(), chatmsg::mask(), NULL, NULL));

			if (chatMsgAddy)
			{
				ConsolePrint("ChatMsg address: %llX \n", (chatMsgAddy));

				if (needsBig)
				{
					char* payloadChatMsgPtr = (char*)&(payloadChatMsgBig[0]);

					DWORD dwback2;
					VirtualProtect(payloadChatMsgPtr, sizeof(payloadChatMsgBig), PAGE_EXECUTE_READWRITE, &dwback2); //make sure we have perms

					AddCALL((BYTE*)&(payloadChatMsgBig[4]), (LPBYTE)(&(hook_chatmsgreceived))); //add call to the hooked func (not in localplayer cuz its done in assembly)
					Detour((LPBYTE)(chatMsgAddy), (LPBYTE)payloadChatMsgPtr, 0x28, 1, true);
					AddJMP((LPBYTE)((DWORD64)payloadChatMsgPtr + 25), (LPBYTE)((DWORD64)chatMsgAddy + 0xE), true); //jump back to original function 

					ConsolePrint("ChatMsg payload: %llX \n", (DWORD64)((LPBYTE)payloadChatMsgPtr));
				}
				else
				{
					char* payloadChatMsgPtr = (char*)&(payloadChatMsg[0]);

					DWORD dwback2;
					VirtualProtect(payloadChatMsgPtr, sizeof(payloadChatMsg), PAGE_EXECUTE_READWRITE, &dwback2); //make sure we have perms

					AddCALL((BYTE*)&(payloadChatMsg[4]), (LPBYTE)(&(hook_chatmsgreceived))); //add call to the hooked func (not in localplayer cuz its done in assembly)
					Detour((LPBYTE)(chatMsgAddy), (LPBYTE)payloadChatMsgPtr, 0x40, 1);
					AddJMP((LPBYTE)((DWORD64)payloadChatMsgPtr + 0x10), (LPBYTE)((DWORD64)chatMsgAddy + 5)); //jump back to original function 

					ConsolePrint("ChatMsg payload: %llX \n", (DWORD64)((LPBYTE)payloadChatMsgPtr));
				}
			}
			else
				ConsolePrint("Couldn't find ChatMsg address \n");
		}


		if (options::hookLocalPlayer) 
		{
			int addValue = needsBig ? 0 : 7; //Needs more memory with big jmp so we need to change the pos we detour at

			const auto localAddy = (DWORD64*)(PatternSearch("", getlocal::sig(), getlocal::mask(), NULL, NULL) + addValue);

			if (localAddy)
			{
				ConsolePrint("GetLocalPlayer address: %llX \n", (localAddy));
				if (needsBig) 
				{
					char* payloadLocalplayerPtr = (char*)&(payloadLocalplayerBig[0]);

					DWORD dwback;
					VirtualProtect(payloadLocalplayerPtr, sizeof(payloadLocalplayerBig), PAGE_EXECUTE_READWRITE, &dwback); //make sure we have perms
			
					long long int fpot = (long long int)(&(hook_getlocalplayer)); 
					long long int somVal = (long long int)&fpot; //anybody

					memcpy((void*)&(payloadLocalplayerBig[0xD]), &(somVal), 8); //write address of hook_getlocalplayer in rax register and then call it

					Detour((LPBYTE)((DWORD64)localAddy), (LPBYTE)payloadLocalplayerPtr, 0x40, 0, true);

					ConsolePrint("GetLocalPlayer address: %llX \n", (DWORD64)((LPBYTE)payloadLocalplayerPtr));

				}
				else 
				{
					char* payloadLocalplayerPtr = (char*)&(payloadLocalplayer[0]);

					DWORD dwback;
					VirtualProtect(payloadLocalplayerPtr, sizeof(payloadLocalplayer), PAGE_EXECUTE_READWRITE, &dwback); //make sure we have perms

					long long int fpot = (long long int)(&(hook_getlocalplayer));
					long long int somVal = (long long int)&fpot;

					memcpy((void*)&(payloadLocalplayer[6]), &(somVal), 8); //write address of hook_getlocalplayer in rax register and then call it

					Detour((LPBYTE)((DWORD64)localAddy), (LPBYTE)payloadLocalplayerPtr, 0x28);

					ConsolePrint("GetLocalPlayer payload: %llX \n", (DWORD64)((LPBYTE)payloadLocalplayerPtr));
				}
			}
			else
				ConsolePrint("Can't find GetLocalPlayer \n");
		}
		
		/*
		TODO:
		-fix gt crashing if leaving (happened once, idk)
		-idk
		-update now that its (probably) malfunctioning since last update 3 months ago
		*/
		
		while (!GetAsyncKeyState(VK_F7)) //F7 to unload, will not restore detour code since its manually added
		{
			if (!options::hookLocalPlayer) // No need to do any other checks unless we hook localplr
			{
				DWORD64* ptrc = (DWORD64*)lastValidRbx;
				if (ptrc && lastValidRbx && lastValidRbx > 0x1500 && lastValidRbx != 0xFFFFFFFF)
				{
					//Accessing playerstruct without this check will crash because playerstruct is in different place when punching or placing
					if (*(BYTE*)(lastValidRbx) == 0x58 && *(BYTE*)(lastValidRbx + 4) == 0x01 && *(BYTE*)(lastValidRbx + 6) == 0x00)
					{
						if (playerStruct && (DWORD64)playerStruct == lastValidRbx)
						{
							if (!inOtherActivity)
							{
								static Vec2D oldpos;
								static Vec2D oldpos2;

								Vec2D pos_block(playerStruct->XPOS2, playerStruct->YPOS2);
								Vec2D pos_exact(playerStruct->XPOS, playerStruct->YPOS);


								if (oldpos != pos_block || oldpos2 != pos_exact)
								{

									oldpos = pos_block;
									oldpos2 = pos_exact;
									ConsolePrint("[HOOK] X: %.0f (%.0f) Y: %.0f (%.0f) \n", pos_block.x, pos_exact.x, pos_block.y, pos_exact.y);
								}
							}
							else 
								inOtherActivity = false;
						}
					}
				}
			}		
			Sleep(50);
		}
		
	
		DetachConsole();
		FreeLibraryAndExitThread(static_cast<HMODULE>(base), 1);
	}
	catch (const std::exception& ex) {
		ConsolePrint("An error occured during initialization:\n");
		ConsolePrint("%s\n", ex.what());
		ConsolePrint("Press any key to exit.\n");
		ConsoleReadKey();
		DetachConsole();

		FreeLibraryAndExitThread(static_cast<HMODULE>(base), 1);
	}
}