using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }
         
        public void Draw()
        {
            
        }
    }
}
