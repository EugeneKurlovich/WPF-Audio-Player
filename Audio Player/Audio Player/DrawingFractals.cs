using System;
using System.Drawing;
namespace Audio_Player
{
   public  class DrawingFractals
    {
        public int xc;
        public int yc;
        public int rad;
        public Graphics g;
        public System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Color.Black);

        public void SetColor()
        {

            Random rand = new Random();
            int colorId = rand.Next(1, 10);

            switch (colorId)
            {
                case 1: p = new System.Drawing.Pen(System.Drawing.Color.Aqua); g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 650,523); break;
                case 2: p = new System.Drawing.Pen(System.Drawing.Color.Chocolate); g.FillRectangle(System.Drawing.Brushes.MintCream, 0, 0, 650, 523); break;
                case 3: p = new System.Drawing.Pen(System.Drawing.Color.GreenYellow); g.FillRectangle(System.Drawing.Brushes.MediumAquamarine, 0, 0, 650, 523); break;
                case 4: p = new System.Drawing.Pen(System.Drawing.Color.Indigo); g.FillRectangle(System.Drawing.Brushes.MediumBlue, 0, 0, 650, 523); break;
                case 5: p = new System.Drawing.Pen(System.Drawing.Color.Magenta); g.FillRectangle(System.Drawing.Brushes.MediumTurquoise, 0, 0, 650, 523); break;
                case 6: p = new System.Drawing.Pen(System.Drawing.Color.Moccasin); g.FillRectangle(System.Drawing.Brushes.Tomato, 0, 0, 650, 523); break;
                case 7: p = new System.Drawing.Pen(System.Drawing.Color.MistyRose);g.FillRectangle(System.Drawing.Brushes.Transparent, 0, 0, 650, 523); break;
                case 8: p = new System.Drawing.Pen(System.Drawing.Color.OldLace); g.FillRectangle(System.Drawing.Brushes.Silver, 0, 0, 650, 523); break;
                case 9: p = new System.Drawing.Pen(System.Drawing.Color.Navy); g.FillRectangle(System.Drawing.Brushes.Violet, 0, 0, 650, 523); break;
            }
        }

        public void Draw(int x, int y, int size, Graphics g, System.Drawing.Pen p)
        {

            int iter = 6, a = 3;
            int r1, r2;

            if (size > 1)
            {
                r1 = (int)Math.Round(size / (a * 2.0));
                r2 = (int)Math.Round(size * (a - 2.0) / a);
                Draw(x, y, r1, g, p);
                for (int i = 1; i <= iter; i++)
                    Draw(x - (int)Math.Round(r2 * Math.Sin(2 * Math.PI / iter * i)), y + (int)Math.Round(r2 * Math.Cos(2 * Math.PI / iter * i)), r1, g, p);

            }
            try
            {
                g.DrawEllipse(p, x - size, y - size, 2 * size, 2 * size);
            }
            catch
            {

            }
          
        }
    }



}
