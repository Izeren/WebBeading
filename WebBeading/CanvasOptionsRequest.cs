using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class CanvasOptionsRequest
    {
        public int width;
        public int height;
        public int bixelWidth;
        public int bixelHeight;

        public void setWidth(int newWidth)
        {
            width = newWidth;
        }

        public void setHeight(int newHeight)
        {
            height = newHeight;
        }

        public void setBixelWidth(int newBixelWidth)
        {
            bixelWidth = newBixelWidth;
        }

        public void setBixelHeight(int newBixelHeight)
        {
            bixelHeight = newBixelHeight;
        }

        public int getWidth()
        {
            return width;
        }
        public int getHeight()
        {
            return height;
        }
        public int getBixelWidth()
        {
            return bixelWidth;
        }
        public int getBixelHeight()
        {
            return bixelHeight;
        }
    }
}