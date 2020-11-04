using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length 
        {
            get
            {
                return this.length;
            }
            set 
            {
                if (value > 0)
                {
                    this.length = value;
                }

                else
                {                
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            } 
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }

                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value > 0)
                {
                    this.height = value;
                }

                else
                {           
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public string SurfaceArea(double length, double width, double height)
        {
            //2lw + 2lh + 2wh
            double result = 2 * length * width + 2 * length * height + 2 * width * height;
            string resultAsStr = result.ToString("0.00");
            return resultAsStr;
        }

        public string LateralSurfaceArea(double length, double width, double height)
        {
            //2lh + 2wh
            double result = 2 * length * height + 2 * width * height;
            string resultAsStr = result.ToString("0.00");
            return resultAsStr;
        }

        public string Volume(double length, double width, double height)
        {
            double result = length * width * height;
            string resultAsStr = result.ToString("0.00");
            return resultAsStr;
        }
    }
}
