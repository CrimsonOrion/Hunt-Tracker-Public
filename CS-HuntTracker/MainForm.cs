using CS_HuntTracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace CS_HuntTracker
{
    public partial class MainForm : Form
    {        
        private System.Timers.Timer myTimer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
            SetTimers();            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(RefreshTimedEvent);
            // Set it to go off every five seconds
            myTimer.Interval = 5000;
            // And start it        
            myTimer.Enabled = true;

        }

        // Implement a call with the right signature for events going off
        private void RefreshTimedEvent(object source, ElapsedEventArgs e) => SetTimers();        

        private void UpdateTimerThread(object sender, EventArgs e)
        {
            Thread updateThread =
               new Thread(new ThreadStart(SetTimers));
            updateThread.Start();
        }

        private void SetTimers()
        {
            MobSpawnInfo.GetMobSpawnInfo = DB.GetMobSpawnInfo();
            DB.GetMaintenanceTime();
            MobSpawnTimer.MobSpawnTimers = new List<MobSpawnTimer>();
            foreach (var mob in MobSpawnInfo.GetMobSpawnInfo)
            {
                if (mob.LastSeen <= MobSpawnTimer.MaintTime) { MobSpawnTimer.Maintanence = true; } else { MobSpawnTimer.Maintanence = false; };
                TimeSpan resMin = MobSpawnTimer.GetTimer(mob);
                TimeSpan resMax;
                if (MobSpawnTimer.Maintanence) { resMax = resMin - (mob.MaintMax - mob.MaintMin); } else { resMax = resMin - (mob.RespawnMax - mob.RespawnMin); }
                
                MobSpawnTimer.MobSpawnTimers.Add(new MobSpawnTimer(mob.ID, mob.Mob, mob.Rank, resMin, resMax));
                switch (mob.ID)
                {
                    case 2936:
                        SetTimerLabel(CentralShroudARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2953:
                        SetTimerLabel(CentralShroudSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2941:
                        SetTimerLabel(CentralThanalanARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2958:
                        SetTimerLabel(CentralThanalanSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2937:
                        SetTimerLabel(EastShroudARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2954:
                        SetTimerLabel(EastShroudSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2947:
                        SetTimerLabel(EasternLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2964:
                        SetTimerLabel(EasternLaNosceaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2942:
                        SetTimerLabel(EasternThanalanARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2959:
                        SetTimerLabel(EasternThanalanSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2946:
                        SetTimerLabel(LowerLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2963:
                        SetTimerLabel(LowerLaNosceaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2945:
                        SetTimerLabel(MiddleLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2962:
                        SetTimerLabel(MiddleLaNosceaSRankLabel, resMin, resMax, mob.Rank);
                        break;                    
                    case 2952:
                        SetTimerLabel(MorDhonaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2969:
                        SetTimerLabel(MorDhonaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2939:
                        SetTimerLabel(NorthShroudARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2956:
                        SetTimerLabel(NorthShroudSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2944:
                        SetTimerLabel(NorthernThanalanARankLabel, resMin, resMax, mob.Rank);
                        break;                    
                    case 2961:
                        SetTimerLabel(NorthernThanalanSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2950:
                        SetTimerLabel(OuterLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2967:
                        SetTimerLabel(OuterLaNosceaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2938:
                        SetTimerLabel(SouthShroudARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2955:
                        SetTimerLabel(SouthShroudSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2943:
                        SetTimerLabel(SouthernThanalanARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2960:
                        SetTimerLabel(SouthernThanalanSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2949:
                        SetTimerLabel(UpperLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2966:
                        SetTimerLabel(UpperLaNosceaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2948:
                        SetTimerLabel(WesternLaNosceaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2965:
                        SetTimerLabel(WesternLaNosceaSRankLabel, resMin, resMax, mob.Rank);                        
                        break;
                    case 2940:
                        SetTimerLabel(WesternThanalanARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2957:
                        SetTimerLabel(WesternThanalanSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2951:
                        SetTimerLabel(CoerthasCentralHighlandsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 2968:
                        SetTimerLabel(CoerthasCentralHighlandsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4362:
                        SetTimerLabel(CoerthasWesternHighlandsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4363:
                        SetTimerLabel(CoerthasWesternHighlandsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4374:
                        SetTimerLabel(CoerthasWesternHighlandsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4372:
                        SetTimerLabel(AzysLlaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4373:
                        SetTimerLabel(AzysLlaA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4380:
                        SetTimerLabel(AzysLlaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 6000:
                        SetTimerLabel(TheAzimSteppeARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 6001:
                        SetTimerLabel(TheAzimSteppeA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5986:
                        SetTimerLabel(TheAzimSteppeSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4368:
                        SetTimerLabel(TheChurningMistsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4369:
                        SetTimerLabel(TheChurningMistsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4377:
                        SetTimerLabel(TheChurningMistsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4364:
                        SetTimerLabel(TheDravanianForelandsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4365:
                        SetTimerLabel(TheDravanianForelandsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4375:
                        SetTimerLabel(TheDravanianForelandsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4366:
                        SetTimerLabel(TheDravanianHinterlandsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4367:
                        SetTimerLabel(TheDravanianHinterlandsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4376:
                        SetTimerLabel(TheDravanianHinterlandsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5990:
                        SetTimerLabel(TheFringesARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5991:
                        SetTimerLabel(TheFringesA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5987:
                        SetTimerLabel(TheFringesSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5994:
                        SetTimerLabel(TheLochsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5995:
                        SetTimerLabel(TheLochsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5989:
                        SetTimerLabel(TheLochsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5992:
                        SetTimerLabel(ThePeaksARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5993:
                        SetTimerLabel(ThePeaksA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5988:
                        SetTimerLabel(ThePeaksSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5996:
                        SetTimerLabel(TheRubySeaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5997:
                        SetTimerLabel(TheRubySeaA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5984:
                        SetTimerLabel(TheRubySeaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4370:
                        SetTimerLabel(TheSeaOfCloudsARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4371:
                        SetTimerLabel(TheSeaOfCloudsA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 4378:
                        SetTimerLabel(TheSeaOfCloudsSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5998:
                        SetTimerLabel(YanxiaARankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5999:
                        SetTimerLabel(YanxiaA2RankLabel, resMin, resMax, mob.Rank);
                        break;
                    case 5985:
                        SetTimerLabel(YanxiaSRankLabel, resMin, resMax, mob.Rank);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetTimerLabel(Label label, TimeSpan resMin, TimeSpan resMax, string rank)
        {
            string resMinHMS = string.Empty;
            if ((int)resMin.TotalHours == 0 && resMin.Minutes != 0) { resMinHMS = $"{resMin.Minutes}m".Replace("-", ""); }
            else if ((int)resMin.TotalHours == 0 && resMin.Minutes == 0) { resMinHMS= $"{resMin.Seconds}s".Replace("-", ""); }
            else { resMinHMS = $"{(int)resMin.TotalHours}h {resMin.Minutes}m".Replace("-", "");/* {resMin.Seconds}s".Replace("-", "");*/ }            
            ThreadHelperClass.SetText(this, label, $"{resMinHMS}");
            if (resMin <= TimeSpan.FromMinutes(-10)) { label.ForeColor = MobSpawnTimer.NotOpen; }
            else if (resMin > TimeSpan.FromMinutes(-10) && resMin <= TimeSpan.FromMinutes(0) ) { label.ForeColor = MobSpawnTimer.AboutToOpen; }
            else if (resMin > TimeSpan.FromMinutes(0) && resMax <= TimeSpan.FromMinutes(0)) { label.ForeColor = MobSpawnTimer.Open; }
            else if (resMax < TimeSpan.FromMinutes(10)) { label.ForeColor = MobSpawnTimer.OpenForced; }
            else if (rank == "A") { label.ForeColor = MobSpawnTimer.Missing; }
            else { label.ForeColor = MobSpawnTimer.OpenForced; }
        }
       
        private void TestDBConnectionButton_Click(object sender, EventArgs e)
        {            
            bool connected = false;
            connected = DB.TestConnection();           
            MessageBox.Show($"Connected to DB: {connected}.");

        }
        
        private void LoadMobForm(object sender, MouseEventArgs e)
        {
            MobForm form = new MobForm() { Text = (sender as Label).Text.Replace(":","") };
            form.ShowDialog();
            SetTimers();
        }

        #region "Eorzea"        

        private void MiddleLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.MLaNoscea)
            {
                Name = "MiddleLaNoscea",
                Text = (sender as Button).Text /*,  <- FOR SETTING CUSTOM WINDOW LOCATIONS LATER
                StartPosition = FormStartPosition.Manual,
                Top = this.Top + 40,
                Left = this.Left + 275
                */
            };
            form.ShowDialog();
        }

        private void LowerLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.LLaNoscea)
            {
                Name = "LowerLaNoscea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void EasternLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.ELaNoscea)
            {
                Name = "EasternLaNoscea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void WesternLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.WLaNoscea)
            {
                Name = "WesternLaNoscea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void UpperLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.ULaNoscea)
            {
                Name = "UpperLaNoscea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }
                
        private void OuterLaNosceaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.OLaNoscea)
            {
                Name = "OuterLaNoscea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void CentralShroudButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.CShroud)
            {
                Name = "CentralShroud",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void EastShroudButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.EShroud)
            {
                Name = "EastShroud",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void SouthShroudButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.SShroud)
            {
                Name = "SouthShroud",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void NorthShroudButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.NShroud)
            {
                Name = "NorthShroud",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void WesternThanalanButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.WThan)
            {
                Name = "WesternThanalan",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void CentralThanalanButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.CThan)
            {
                Name = "CentralThanalan",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void EasternThanalanButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.EThan)
            {
                Name = "EasternThanalan",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void SouthernThanalanButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.SThan)
            {
                Name = "SouthernThanalan",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void NorthernThanalanButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.NThan)
            {
                Name = "NorthernThanalan",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void MorDhonaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.MorDhona)
            {
                Name = "MorDhona",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        #endregion

        #region "Ishgard and Surrounding Area


        private void CoerthasCentralHighlandsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("ARR", Resources.CorthasCent)
            {
                Name = "CoerthasCentralHighlands",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void CoerthasWesternHighlandsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.CorthasWest)
            {
                Name = "CoerthasWesternHighlands",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheChurningMistsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.ChurningMists)
            {
                Name = "TheChurningMists",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheDravanianForelandsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.DravForelands)
            {
                Name = "TheDravanianForelands",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheDravanianHinterlandsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.DravHinderlands)
            {
                Name = "TheDravanianHinterlands",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void AzysLlaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.AzysLla)
            {
                Name = "AzysLla",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheSeaOfCloudsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("HW", Resources.SeaOfClouds)
            {
                Name = "TheSeaOfClouds",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        #endregion

        #region "Gyr Abania"

        private void TheLochsButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.TheLochs)
            {
                Name = "TheLochs",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheFringesButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.TheFringes)
            {
                Name = "TheFringes",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void ThePeaksButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.ThePeaks)
            {
                Name = "ThePeaks",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        #endregion

        #region "Othard"

        private void TheAzimSteppeButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.AzimSteppe)
            {
                Name = "TheAzimSteppe",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void TheRubySeaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.TheRubySea)
            {
                Name = "TheRubySea",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        private void YanxiaButton_Click(object sender, EventArgs e)
        {
            HuntMapForm form = new HuntMapForm("SB", Resources.Yanxia)
            {
                Name = "Yanxia",
                Text = (sender as Button).Text
            };
            form.ShowDialog();
        }

        #endregion
    }
}
