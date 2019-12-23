using System;
using System.Runtime.InteropServices;
using Color = System.Windows.Media.Color;

namespace Calckit.Calculations
{
   public class ColorsConverter
    {


        [DllImport("shlwapi.dll")]
        public static extern int ColorHLSToRGB(int H, int L, int S);
        //Convert color to hex

        private string RGBToHexColor(int R,int G,int B)
        {
            return "#" + R.ToString("X2") + G.ToString("X2") + B.ToString("X2");
        }

        public Color FromHex(string hex)
        {
            if (hex.Length > 7)
            {
                return Color.FromArgb(Convert.ToByte(hex.Substring(1, 2), 16),
                    Convert.ToByte(hex.Substring(3, 2), 16),
                    Convert.ToByte(hex.Substring(5, 2), 16),
                    Convert.ToByte(hex.Substring(7), 16));
            }
            else
            {
                return Color.FromRgb(
                  Convert.ToByte(hex.Substring(1, 2), 16),
                  Convert.ToByte(hex.Substring(3, 2), 16),
                  Convert.ToByte(hex.Substring(5, 2), 16));
            } 
        }

        public string Tohex(Color c)
        {
            
            return "#" + c.A.ToString("X2") + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public Color FromHSL(int h,int s,int l)
        {
            int colorInt = ColorHLSToRGB(h, s, l);
            byte[] bytes = BitConverter.GetBytes(colorInt);
            return Color.FromArgb(255, bytes[0], bytes[1], bytes[2]);
        }


        public Color RGBTOColor(int r,int g,int b)
        {
            return Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }

        public  Color FromAhsb(int alpha, float hue, float saturation, float brightness)
        {

            if (0 > alpha || 255 < alpha)
            {
                throw new ArgumentOutOfRangeException("alpha", alpha,
                  "Value must be within a range of 0 - 255.");
            }
            if (0f > hue || 360f < hue)
            {
                throw new ArgumentOutOfRangeException("hue", hue,
                  "Value must be within a range of 0 - 360.");
            }
            if (0f > saturation || 1f < saturation)
            {
                throw new ArgumentOutOfRangeException("saturation", saturation,
                  "Value must be within a range of 0 - 1.");
            }
            if (0f > brightness || 1f < brightness)
            {
                throw new ArgumentOutOfRangeException("brightness", brightness,
                  "Value must be within a range of 0 - 1.");
            }

            if (0 == saturation)
            {
                return Color.FromArgb((byte)alpha, Convert.ToByte(brightness * 255),
                  Convert.ToByte(brightness * 255), Convert.ToByte(brightness * 255));
            }

            float fMax, fMid, fMin;
            int iSextant;
            byte iMax, iMid, iMin;

            if (0.5 < brightness)
            {
                fMax = brightness - (brightness * saturation) + saturation;
                fMin = brightness + (brightness * saturation) - saturation;
            }
            else
            {
                fMax = brightness + (brightness * saturation);
                fMin = brightness - (brightness * saturation);
            }

            iSextant = (int)Math.Floor(hue / 60f);
            if (300f <= hue)
            {
                hue -= 360f;
            }
            hue /= 60f;
            hue -= 2f * (float)Math.Floor(((iSextant + 1f) % 6f) / 2f);
            if (0 == iSextant % 2)
            {
                fMid = hue * (fMax - fMin) + fMin;
            }
            else
            {
                fMid = fMin - hue * (fMax - fMin);
            }

            iMax = Convert.ToByte(fMax * 255);
            iMid = Convert.ToByte(fMid * 255);
            iMin = Convert.ToByte(fMin * 255);

            switch (iSextant)
            {
                case 1:
                    return Color.FromArgb((byte)alpha, iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb((byte)alpha, iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb((byte)alpha, iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb((byte)alpha, iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb((byte)alpha, iMax, iMin, iMid);
                default:
                    return Color.FromArgb((byte)alpha, iMax, iMid, iMin);
            }
        }


        //Color Operations

        private Color ColorAdd(Color color1,Color color2)
        {
            return Color.Add(color1, color2);
        }

        private Color ColorSUb(Color color1,Color color2)
        {
            return Color.Subtract(color1, color2);
        }

        private Color ColoMultiply(Color color1,float Coef)
        {
            return Color.Multiply(color1, Coef);
        }

        //Public method to calculate 
        public string ColorOperation(Color color1,Color color2,char Op,float coef)
        {
            switch (Op)
            {
                case '+':
                    {
                       return Tohex( ColorAdd(color1, color2));
                    }

                case '-':
                    {
                        return Tohex(ColorSUb(color1, color2));
                    }

                case '*':
                    {
                        return Tohex(ColoMultiply(color1, coef));
                    }

                default:
                    return "Choose an operator";
            }
        }
    }
}
