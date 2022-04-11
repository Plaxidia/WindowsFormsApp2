﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public abstract class Filters
    {
        protected abstract Color  calculateNewPixelColor(Bitmap sourceImage, int x, int y);
         
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {   //at the moment the function creates a blank image 
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            //get all pixels of the image
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
        //calcuculate Pixel color and should be unique to eacg real class

        public int Clamp(int value,int min,int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

    }


    class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }


    }

}
