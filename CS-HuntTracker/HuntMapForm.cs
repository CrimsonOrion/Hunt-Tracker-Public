using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CS_HuntTracker
{
    public partial class HuntMapForm : Form
    {
        public string MapType { get; set; }
        public List<SpawnPoint> MapSpawnPoints { get; set; }        

        public HuntMapForm(string mapType, Image map)
        {            
            BackgroundImage = map;      // Make the selected map the background image for the form.
            this.MapType = mapType;     // Make the ratios line up whether its ARR, HW or SB.            
            InitializeComponent();      // Dynamically create the form.            
        }       
        
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint the form with the map first
            base.OnPaint(e);

            // then populate the spawn points
            PopulateMap(this);
        }

        private void PopulateMap(HuntMapForm huntMapForm)
        {
            // get the spawn points for this map
            this.MapSpawnPoints = DB.GetSpawnPoints(this, MapType);            
        }

    }
}
