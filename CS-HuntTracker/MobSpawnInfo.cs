using System;
using System.Collections.Generic;

namespace CS_HuntTracker
{
    class MobSpawnInfo
    {
        public int ID { get; set; }
        public string Mob { get; set; }
        public string Rank { get; set; }
        public string Zone { get; set; }
        public TimeSpan RespawnMin { get; set; }
        public TimeSpan RespawnMax { get; set; }
        public TimeSpan MaintMin { get; set; }
        public TimeSpan MaintMax { get; set; }
        public DateTime LastSeen { get; set; }
        public bool SeenAlive { get; set; }

        public static List<MobSpawnInfo> GetMobSpawnInfo;

        public MobSpawnInfo(int id, string mob, string rank, string zone, TimeSpan respawnMin, TimeSpan respawnMax, TimeSpan maintMin, TimeSpan maintMax, DateTime lastSeen, bool seenAlive)
        {
            ID = id;
            Mob = mob;
            Rank = rank;
            Zone = zone;
            RespawnMin = respawnMin;
            RespawnMax = respawnMax;
            MaintMin = maintMin;
            MaintMax = maintMax;
            LastSeen = lastSeen;
            SeenAlive = seenAlive;
        }
    }
}
