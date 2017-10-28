using System.Collections.Generic;

namespace CS_HuntTracker
{
    class Zone
    {
        public string TableName { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }

        public Zone(string tableName, string name, string region)
        {
            TableName = tableName;
            Name = name;
            Region = region;
        }

        public static List<Zone> GetZones;
    }
}
