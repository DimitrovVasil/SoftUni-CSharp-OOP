using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.SurfaceArea(length, width, height)}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea(length, width, height)}");
                Console.WriteLine($"Volume - {box.Volume(length, width, height)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          

            
        }
    }
}
