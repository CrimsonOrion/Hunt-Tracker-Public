using System;
using System.Collections.Generic;
using System.Drawing;

namespace CS_HuntTracker
{
    class MobSpawnTimer
    {
        public int ID { get; set; }
        public string Mob { get; set; }
        public string Rank { get; set; }
        public TimeSpan RespawnMin { get; set; }
        public TimeSpan RespawnMax { get; set; }

        public static List<MobSpawnTimer> MobSpawnTimers;
        public static DateTime MaintTime;
        public static bool Maintanence = false;

        public static Color NotOpen = Color.Red;
        public static Color AboutToOpen = Color.Goldenrod;
        public static Color Open = Color.Lime;
        public static Color OpenForced = Color.Aqua;
        public static Color Missing = Color.Gray;

        public MobSpawnTimer(int id, string mob, string rank, TimeSpan respawnMin, TimeSpan respawnMax)
        {
            ID = id;
            Mob = mob;
            Rank = rank;
            RespawnMin = respawnMin;
            RespawnMax = respawnMax;
        }

        public static TimeSpan GetTimer(MobSpawnInfo mSI)
        {
            TimeSpan timer = TimeSpan.FromSeconds(0);
            TimeSpan respawnMin;
            TimeSpan totalSeconds;

            if (Maintanence)
            {
                respawnMin = mSI.MaintMin;
                totalSeconds = (DateTime.Now - MaintTime.Add(respawnMin));
            }
            else
            {
                respawnMin = mSI.RespawnMin;
                totalSeconds = (DateTime.Now - mSI.LastSeen.Add(respawnMin));
            }

            //TimeSpan totalSeconds = (DateTime.Now - mSI.LastSeen.Add(respawnMin));
            int days = totalSeconds.Days;
            int hours = (int)totalSeconds.TotalHours;
            int minutes = totalSeconds.Minutes;
            int seconds = totalSeconds.Seconds;
            timer = new TimeSpan(hours, minutes, seconds);

            return timer;
        }

    }
}
