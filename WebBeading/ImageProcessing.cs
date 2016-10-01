using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace WebBeading
{
    public class ImageProcessing
    {
        /**
     *
     * @param image
     * @param options
     * @return
     */
        public static Mat bixilizeImage(Mat image, LayerOptions options)
        {

            //Calculating appropriate sizes
            int bixelWidth = options.bixelWidth;
            int bixelHeight = options.bixelHeight;
            int width = (image.Cols / bixelWidth) * bixelWidth;
            int height = (image.Rows / bixelHeight) * bixelHeight;
            int bixeledHeight = image.Rows / bixelHeight;
            int bixeledWidth = image.Cols / bixelWidth;

            Bixel[][] bixels = new Bixel[bixeledHeight][];
            for (int i = 0; i < bixeledHeight; ++i) {
                bixels[i] = new Bixel[bixeledWidth];
            }
            Mat newImage = new Mat(height, width, DepthType.Cv8U, 3);
            for (int i = 0; i < bixeledHeight; ++i)
            {
                for (int j = 0; j < bixeledWidth; ++j)
                {
                    Rectangle rect = new Rectangle(j * bixelWidth, i * bixelHeight, bixelWidth, bixelHeight);
                    Mat subImage = new Mat(image, rect);
                    bixels[i][j] = new Bixel(defineColor(subImage, options));
                    int[] rgbArray = bixels[i][j].getColor().getRGBArray();
                    Mat newImageRegion = new Mat(newImage, rect);
                    newImageRegion.SetTo(new MCvScalar(rgbArray[2], rgbArray[1], rgbArray[0]));
                }
            }
            return newImage;
        }


        private static IPaletteColor defineColor(Mat image, LayerOptions options)
        {
            IPalette palette = options.palette;
            switch (options.wayOfBixelColorDefinition)
            {
                case WaysOfBixelColorDefinition.MostPopularOfClosestToPalette:
                    return defineColorMPOCTP(image, palette);
                case WaysOfBixelColorDefinition.ClosestFromPaletteToAverage:
                    return defineColorCFPTA(image, palette);
                default:
                    return defineColorMPOCTP(image, palette);
            }
        }
        //MostPopularOfClosestToPalette
        private static IPaletteColor defineColorMPOCTP(Mat image, IPalette palette)
        {
            return new PaletteColor(0, 0, 0);
        }

        private static IPaletteColor defineColorCFPTA(Mat image, IPalette palette)
        {
            return new PaletteColor(0, 0, 0);

        }
    }
}