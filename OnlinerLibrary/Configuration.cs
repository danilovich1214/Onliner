using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinerLibrary
{
    public static class Configuration
    {
        private static readonly string PathToDivers;

        static Configuration()
        {
            PathToDivers = System.Environment.CurrentDirectory + "/Drivers";
        }
        
        public static string GetPathToDrivers()
        {
            return PathToDivers;
        }
    }
}
