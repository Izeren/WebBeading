using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emgu.CV;

namespace WebBeading
{
    public class Layer
    {
        private LayerOptions options;

        private Mat image { get; }

    public Layer(Mat image)
        {
            this.image = image;
        }

        /**
         *
         * @param image
         * @param options
         */
        public Layer(Mat image, LayerOptions options)
        {
            this.options = options;
            this.image = ImageProcessing.bixilizeImage(image, options);
        }

    public Mat getImage()
        {
            return image;
        }
    }
}