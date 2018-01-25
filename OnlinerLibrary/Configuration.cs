namespace OnlinerLibrary
{
    public static class Configuration
    {
        private static readonly string PathToDivers;

        static Configuration()
        {
            PathToDivers = System.Environment.CurrentDirectory + @"\Drivers";
        }
        
        public static string GetPathToDrivers()
        {
            return PathToDivers;
        }
    }
}
