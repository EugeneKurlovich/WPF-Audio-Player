using System;
using System.Collections.Generic;

namespace Audio_Player
{
   public class Files
    {
        public static List <SongElements> PlayList = new List <SongElements>(); 
        public static List<string> allNamePl = new List<string>();
        public static List<string> forPlay = new List<string>();
        public static  string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        public static int trackNumber; 
 
        public static string getSongName(string fullFileName)
        {
            string[] songName = fullFileName.Split('\\');
            return songName[songName.Length-1];           
        }

   
    }
}
