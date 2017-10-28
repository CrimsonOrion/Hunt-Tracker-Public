using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace CS_HuntTracker
{
    public partial class MobForm : Form
    {
        public MobForm()
        {
            InitializeComponent();
        }

        private void MobForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] help = assembly.GetManifestResourceNames();
            Stream imageStream = assembly.GetManifestResourceStream($"CS_HuntTracker.Resources.{Text.Replace("`", "'")}.jpg");
            try
            {
                if (imageStream != null)
                {
                    Bitmap image = new Bitmap(imageStream);
                    MobPictureBox.Image = image;
                }
            }
            catch (Exception)
            {
                // do nothing, just don't show a pic if I don't have one yet.
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            int hour;
            int minute;
            string deathDateTime = string.Empty;
            if (JustDiedRadio.Checked)
            {
                if (MessageBox.Show($"Set {Text} Time of Death to {DateTime.Now}?", "Set Time of Death", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DB.UpdateMobToD(Text, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            else if (DiedAtRadio.Checked)
            {
                //if(DeathTimeHour.Text != num)
                int.TryParse(DeathTimeHour.Text.Remove(2), out hour);
                int.TryParse(DeathTimeMinute.Text, out minute);
                deathDateTime = $"{DeathDate.Value.ToString("yyyy-MM-dd")} {hour.ToString("00")}:{minute.ToString("00")}:00";
                if (MessageBox.Show($"Set {Text} Time of Death to {deathDateTime}?", "Set Time of Death", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DB.UpdateMobToD(Text, ConvertTimeZone.ToUtcTime(deathDateTime).ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            Close();
        }

        private void JustDiedRadio_CheckedChanged(object sender, EventArgs e)
        {
            OKButton.Enabled = true;
            DeathDate.Enabled = false;
            DeathTimeHour.Enabled = false;
            DeathTimeMinute.Enabled = false;
        }

        private void DiedAtRadio_CheckedChanged(object sender, EventArgs e)
        {
            OKButton.Enabled = true;
            DeathDate.Enabled = true;
            DeathTimeHour.Enabled = true;
            DeathTimeMinute.Enabled = true;
        }
    }
}
