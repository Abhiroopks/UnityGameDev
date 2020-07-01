using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the x coordinate for Point 1:");
            float point1x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate for Point 1:");
            float point1y = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter the x coordinate for Point 2:");
            float point2x = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the y coordinate for Point 2:");
            float point2y = float.Parse(Console.ReadLine());

            float deltax = point2x - point1x;
            float deltay = point2y - point1y;

            double dist = Math.Sqrt(deltax*deltax + deltay*deltay);
            double angle = Math.Atan2(deltay,deltax);
            angle = (angle * 180.0)/Math.PI;

            Console.WriteLine("Distance Between Points: " + dist + "\nAngle from Point 1 to Point 2: " + angle);



        }
    }
}
