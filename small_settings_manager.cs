/*
NOTES:
Saving of settings uses await Task.Delay which is only usable with .NET framework version 4.5 and higher. If you want to use a older version of .NET Framework replace it with Thread.Sleep, other alternative waiting ways, or remove it completely.

LoadSettings() when you open your program
SaveSetting calls loading automatically 

SaveSetting("boolvar1=" + somebool.ToString()); //False/True
SaveSetting("stringvar1=anything is ok here " ); //anything as its a string
SaveSetting("boolvar1" , somebool.ToString()); //False/True (Alternative way without having to input separator

SaveAllCurrentSettings() saves all current settings in struct
saveSetting(args) saves a single setting without changing others

every time you save or load settings struct will be updated with corresponding values

Probably doesnt work for class items or arrays
*/

class yourClass
    {
        private const string dirName = @"\settingsTemplate\"; //Your directory name
        //%Appdata% as our directory base, change if needed / wanted
        private static string dirBase = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
        private static string dir = dirBase + dirName; //Full directory
        private static string file = dir + "settings.txt"; //Our settings file
        private static char separator = '='; // [name][separator][value][newline]
                                             // example1=exampleVal
                                             // example2=2
        public struct settings
        {
            public static bool exampleBoolean1 = true;
            public static bool exampleBoolean2 = false;
            public static string exampleString1 = "";
            public static string exampleString2 = "boi";
        };

        private static void parseLine( string line , Type type , FieldInfo info)
        {
            try
            {
                var array = line.Split( separator );
                if (array.Length < 2)
                    return;

                if (array[ 0 ] == info.Name)
                {
                   var convertedValue = Convert.ChangeType( array[1] , info.FieldType ); //Convert
                   info.SetValueDirect( __makeref(type) , convertedValue );
                }
            }
            catch{  }
        }


        //input ex. key=value 
        public static async void SaveSetting( string setting , uint wait_time_ms = 0 )
        {
            
            if (!Directory.Exists( dir )) 
                Directory.CreateDirectory( dir ); //make directory it if doesnt exist

            if (!setting.Contains( separator.ToString() )) //Invalid settings as it doesnt contain our separator
                return;

            if (File.Exists( file )) //if our settings file exists
            {
                var lines = File.ReadAllLines( file ).ToList(); //read lines to string array

                var key = setting.Split( separator )[ 0 ];
                var index = lines.FindIndex( s => s.StartsWith( key ) ); //check if our settings already contain our key
                if (index >= 0)
                {
                    lines.RemoveAt( index ); //remove existing
                    lines.Insert( index , setting ); //insert new at same index
                    File.WriteAllLines( file , lines ); //Write lines 
                }
                else //Key doesnt exist
                    File.AppendAllText( file , setting + Environment.NewLine ); //Append new setting
                
            }
            else
                File.WriteAllText( file , setting );  //our settings file doesnt exist, just write our only current setting

            if(wait_time_ms > 0) // wait if wait time is defined
               await Task.Delay( 250 ); // 250 ms

            LoadSettings( ); //reload
        }

        //No need to type seperator yourself manually
        public static async void SaveSetting( string key , string value, uint wait_time_ms = 0 )
        {

            if (!Directory.Exists( dir ))
                Directory.CreateDirectory( dir ); //make directory it if doesnt exist

            var setting = key + separator + value;
            if (File.Exists( file )) //if our settings file exists
            {
                var lines = File.ReadAllLines( file ).ToList( ); //read lines to string array

                var index = lines.FindIndex( s => s.StartsWith( key ) ); //check if our settings already contain our key
                if (index >= 0)
                {
                    lines.RemoveAt( index ); //remove existing
                    lines.Insert( index , setting ); //insert new at same index
                    File.WriteAllLines( file , lines ); //Write lines 
                }
                else //Key doesnt exist
                    File.AppendAllText( file , setting + Environment.NewLine ); //Append new setting

            }
            else
                File.WriteAllText( file , setting );  //our settings file doesnt exist, just write our only current setting

            if (wait_time_ms > 0) // wait if wait time is defined
                await Task.Delay( 250 ); // 250 ms

            LoadSettings( ); //reload
        }


        public static void SaveAllCurrentSettings()
        {
            if (!Directory.Exists( dir )) //dir check
                Directory.CreateDirectory( dir );

            var type = typeof( settings );
            var fields = type.GetFields( ).ToList( ); //get fields of our struct w reflection

            if (File.Exists( file )) //if settings exist
            {
                var reference = __makeref(type);
                foreach(var field in fields)
                {
                    var value = field.GetValueDirect( reference ).ToString();
                    var key = field.Name;
                    SaveSetting( key , value );
                }
                
            }
            else
            {
                var list = new List<string>( ); 
                fields.ForEach( field => list.Add( field.Name + separator + field.GetValueDirect( __makeref(type) ).ToString( ) ) );
                File.WriteAllLines( file , list );
            }

        }
        public static void LoadSettings()
        {
            if (!Directory.Exists( dir )) //dir check
                Directory.CreateDirectory( dir );

            var type = typeof( settings );
            var fields = type.GetFields( ).ToList( ); //get fields of our struct w reflection

            if (File.Exists( file )) //if settings exist
            {
               
                var lines = File.ReadAllLines( file ).ToList(); //read all lines
                lines.ForEach( line => fields.ForEach(field => parseLine(line, type, field ) ));
            }
            else
            {
                var list = new List<string>( ); //Write all existing settings to make loading faster later
                fields.ForEach( field => list.Add( field.Name + separator + field.GetValueDirect( __makeref(type) ).ToString() ));
                File.WriteAllLines( file , list );
            }
        }

        public static void ResetSettings()
        {
            if (File.Exists( file )) //if our settings exist then delete file
                File.Delete( file );
        }
    }