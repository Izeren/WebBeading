using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WebBeading
{
    public class PaletteColor : IPaletteColor
    {
        private int RGB { set; get; }

        public PaletteColor()
        {
            RGB = 0;
        }

        public PaletteColor(int RGB)
        {
            this.RGB = RGB;
        }

        public PaletteColor(int red, int green, int blue)
        {
            this.RGB = (red << 16) + (green << 8) + blue;
        }

        /**
         * Returns integer value of RGB color.
         *
         * @return
         */
        public int getRGB()
        {
            return RGB;
        }

        /**
         * Returns color as RR.GG.BB.
         * All parts without leading zeroes, for example: 0.10.255.
         *
         * @return
         */
        public String getStringRGB()
        {
            return null;
        }

        /**
         * Loading the picture from data base.
         * Parameter "isLighted" responsible for type of image in data base.
         *
         * @param isLighted
         * @return
         */
        public Mat getImage(bool isLighted)
        {
            return null;
        }

        /**
         * Generates the picture by RGB color.
         *
         * @return generated picture.
         */
        public Mat getOneColorImage()
        {
            return null;
        }

        /**
         * Returns array of 3 integer elements: red, green, blue.
         *
         * @return Array of 3 integer elements: red, green, blue.
         * Each value is integer number from 0 to 255.
         */
        public int[] getRGBArray()
        {
            int[] array = new int[3];
            array[0] = (RGB >> 16) & 0xFF;
            array[1] = (RGB >> 8) & 0xFF;
            array[2] = RGB & 0xFF;
            return array;
        }

        public static int[] getRGBArray(int RGB)
        {
            int[] array = new int[3];
            array[0] = (RGB >> 16) & 0xFF;
            array[1] = (RGB >> 8) & 0xFF;
            array[2] = RGB & 0xFF;
            return array;
        }

        /**
         * Calculate difference between this color and another.
         * For calculation uses RGB representation. Delta will
         * be calculated as: (r1 - r2) ^ 2 + (g1 - g2) ^ 2 + (b1 - b2) ^ 2.
         *
         * @param RGB
         * @return (r1 - r2) ^ 2 + (g1 - g2) ^ 2 + (b1 - b2) ^ 2.
         */
    public int getDelta(int RGB)
        {
            int[] current = this.getRGBArray();
            int[] other = PaletteColor.getRGBArray(RGB);

            int delta = 0;
            for (int i = 0; i < 3; ++i)
            {
                delta += (current[i] - other[i]) * (current[i] - other[i]);
            }

            return delta;
        }
    }
}