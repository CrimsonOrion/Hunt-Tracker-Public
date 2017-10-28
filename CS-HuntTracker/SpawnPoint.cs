using System;
using System.Drawing;

namespace CS_HuntTracker
{
    public class SpawnPoint
    {
        public int ID { get; set; }
        public string MobB { get; set; }
        public string MobA { get; set; }
        public string MobS { get; set; }
        public string MobB2 { get; set; }
        public string MobA2 { get; set; }
        public float X { get; set; }
        public float Y { get; set; }        
        public string S_CanSpawnHere { get; set; }
        public SpawnPointCircle SpawnCircle { get; set; }

        public SpawnPoint(float x, float y, int id, string mobB, string mobA, string mobS, string mobB2, string mobA2, HuntMapForm form, string type)
        {
            ID = id;
            MobB = mobB;
            MobA = mobA;
            MobS = mobS;
            MobB2 = mobB2;
            MobA2 = mobA2;
            X = x;
            Y = y;            
            string sCanSpawnHere;

            if (MobS == "0")
            {
                sCanSpawnHere = "never";
            }
            else
            {
                sCanSpawnHere = "yes";
            }

            double ratio;
            float radius;
            switch (type)
            {
                case "ARR":
                    ratio = 41.0;
                    radius = (12.5f) / (2048/ form.ClientSize.Height);
                    break;
                case "HW":
                    ratio = 43.1;
                    radius = (25.0f) / (2048 / form.ClientSize.Height);
                    break;
                case "SB":
                    ratio = 41.0;
                    radius = (25.0f) / (2048 / form.ClientSize.Height);
                    break;
                default:
                    ratio = 41.0;
                    radius = (12.5f) / (2048 / form.ClientSize.Height);
                    break;
            }

            SpawnCircle = new SpawnPointCircle(X, Y, radius, form, ratio, sCanSpawnHere);
        }
    }

    public class SpawnPointCircle
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; }
        public Rectangle HitBox { get; set; }
        public HuntMapForm Canvas { get; set; }        

        public SpawnPointCircle(float x, float y, float radius, HuntMapForm canvas, double ratio, string sCanSpawnHere)
        {
            X = (float)Math.Round((x - 1) * canvas.ClientSize.Width / ratio, MidpointRounding.AwayFromZero);
            Y = (float)Math.Round((y - 1) * canvas.ClientSize.Height / ratio, MidpointRounding.AwayFromZero);
            Radius = radius;
            Canvas = canvas;
            HitBox = new Rectangle((int)(X - radius), (int)(Y - radius), (int)(radius + radius), (int)(radius + radius));

            DrawCircle(sCanSpawnHere);
        }

        public void DrawCircle(string sCanSpawnHere)
        {
            Graphics g = Canvas.CreateGraphics();
            Pen pen;
            SolidBrush brush;
            if (sCanSpawnHere == "yes")
            {
                pen = new Pen(CircleColor.possibleRed);
                brush = new SolidBrush(CircleColor.possibleRed);
            }            
            else
            {
                pen = new Pen(CircleColor.neverBlack);
                brush = new SolidBrush(CircleColor.neverBlack);
            }
            
            g.FillCircle(brush, X, Y, Radius);
        }
    }

    static class CircleColor
    {   
        public static Color possibleRed = Color.FromArgb(255, 255, 0, 0);
        public static Color neverBlack = Color.FromArgb(255, 0, 0, 1);        
    }

    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                 float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

    }
}
