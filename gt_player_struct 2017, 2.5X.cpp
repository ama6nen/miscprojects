//if smth says instaban it means if you modify = ban, u can still read
//old & probably some parts wrong playerstruct from 2.5X version
//Most of the things are commented out cuz i was testing shit with position only
//2016 
class Playerstruct 
{
public:
	char pad_0x0000[0x8]; //0x0000
	float XPOS; //0x0008 instaban
	float YPOS; //0x000C instaban
	float playerwidth ; //0x0010 instaban
	float playerheight ; //0x0014 instaban
	float XPOS2; //0x0018 instaban
	float YPOS2; //0x001C instaban
	char pad_0x0020[0x8]; //0x0020
	char Playername[15]; //0x5EF4728 no ban
	char pad_0x0037[0x1]; //0x0037
	__int8 PlayernameLength; //0x0038 no ban max 20
	char pad_0x0039[0xF7]; //0x0039
	__int8 N00000027; //0x0130 
	//unsigned char LookingLeft; //0x0131 
	//char pad_0x0132[0x2]; //0x0132
	//__int64 PosChangingCryptedNoBan; //0x0134 
	//char pad_0x013C[0x1]; //0x013C
	//float N000002A8; //0x013D 
	//char pad_0x0141[0xF]; //0x0141
	//float AffectsPunchSpeed; //0x0150 
	//char pad_0x0154[0x4]; //0x0154
	//unsigned char Jumping2; //0x0158 
	//char pad_0x0159[0xF]; //0x0159
	//unsigned char OnGround3; //0x0168 
	//char pad_0x0169[0x3]; //0x0169
	//float Accel; //0x016C  169 is slime
	//char pad_0x0170[0x4]; //0x0170
	//float Accel2; //0x0174 
	//float ManualSpeedSet; //0x0178 
	//float JumpAccel; //0x017C 
	//char pad_0x0180[0x4]; //0x0180
	//float JumpAccel2; //0x0184 
	//float ManualJumpSet; //0x0188 (dont work)
	//char pad_0x018C[0x2C]; //0x018C
	//__int8 Jumping; //0x01B8 
	//char pad_0x01B9[0x7]; //0x01B9
	//unsigned char DeathState; //0x01C0 
	//char pad_0x01C1[0x3F]; //0x01C1
	//unsigned char ModInvis; //0x0200 (ban)
	//unsigned char ModZoom; //0x0201 
	//unsigned char DevZoom; //0x0202 
	//char pad_0x0203[0x5]; //0x0203
	//__int16 N00000042; //0x0208 
	//__int16 N000002DE; //0x020A 
	//unsigned char TalkingorBRB; //0x020C 
	//char pad_0x020D[0x3]; //0x020D
	//__int16 ModNoclipakaplayerstate; //0x0210 
	//__int32 PlayerState2; //0x0212 
	//char pad_0x0216[0x15A]; //0x0216
	//unsigned char PlayerskinAlpha; //0x0370 
	//unsigned char PlayerSkinRred; //0x0371 
	//unsigned char PlayerSkinGreen; //0x0372 
	//unsigned char PlayerSkinBlue; //0x0373 
	//char pad_0x0374[0x14]; //0x0374
	//__int16 Headitem; //0x0388 
	//__int16 Shirtitem; //0x038A 
	//__int16 Pantsitem; //0x038C 
	//__int16 Feetitem; //0x038E 
	//__int16 Faceitem; //0x0390 
	//__int16 Handitem; //0x0392 
	//__int16 Backitem; //0x0394 
	//__int16 Headitem2; //0x0396 
	//__int16 Neckitem; //0x0398 
	//char pad_0x039A[0x6]; //0x039A
	//__int16 N00000075; //0x03A0 
	//__int32 N0000129D; //0x03A2 
	//char pad_0x03A6[0x16]; //0x03A6
	//float XPOS3; //0x03BC 
	//float YPOS3; //0x03C0 
	//float UnknownMovingThing; //0x03C4 
	//float UnkownJumpingThings; //0x03C8 
	//float XPOS5; //0x03CC 
	//float YPOS5; //0x03D0 
	//float XPOS4; //0x03D4 
	//float YPOS4; //0x03D8 
	//char pad_0x03DC[0x8]; //0x03DC
	//__int16 TileWeAreOver; //0x03E4 
	//char pad_0x03E6[0x5]; //0x03E6
	//unsigned char OnGround2; //0x03EB 
	//unsigned char OnSliding; //0x03EC 
	//unsigned char OnWater; //0x03ED 
	//char pad_0x03EE[0x2]; //0x03EE
	//unsigned char Lookingtoleft2; //0x03F0 
	//char pad_0x03F1[0x12]; //0x03F1
	//__int8 Status; //0x0403 
	//__int8 Action; //0x0404 
	//char pad_0x0405[0x7C]; //0x0405
	//__int8 IsSitting; //0x0481 
	//char pad_0x0482[0xBBD]; //0x0482
	//probably doesnt end here or has things inbetween idk

}; //Size=0x103F