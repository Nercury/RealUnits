/*
 * This is example usage of RealUnits library.
 * 
 */

using System;
using RealUnits;

namespace ExampleOfRealUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            // new distance in meters
            DistanceF a = new DistanceF(10, Unit.Meters);
            // new distance in centimeters
            DistanceF b = new DistanceF(5, Unit.Centimeters);
            // new distance in inches
            DistanceF c = new DistanceF(14, Unit.Inches);
            // new distance in feet
            DistanceF d = new DistanceF(1.5f, Unit.Feet);

            // sum of them (all converted automatically)
            DistanceF sum = a + b + c + d;
            Console.WriteLine("Sum of " + a + ", " + b + ", " + c + ", " + d + " equals " + sum);

            // get distance converted to millimeters
            DistanceF mm = sum.Converted(Unit.Millimeters);

            // get distance as float
            float distanceAsFloat = mm.Decimeters;
            Console.WriteLine(mm + " in decimeters is equal to " + distanceAsFloat);

            // get distance as pixels (you need to specify dpi (dots per inch))
            int pixels = (int)b.Pixels(92);
            Console.WriteLine(b + " is " + pixels + " pixels on 92 dpi monitor"); 

            // create distance from pixels
            DistanceF distanceFromPixels = DistanceF.FromPixels(1024, 92);
            Console.WriteLine("Screen width is " + distanceFromPixels + " on 1024px wide 92dpi display");  

            // compare distances
            if (a > b)
            {
                Console.WriteLine(a + " is more than " + b);
            }

            // compare distances
            if (b <= c)
            {
                Console.WriteLine(b + " is less or equal to " + c);
            }

            // create vectors from distances
            Vector2f v1 = new Vector2f(a, b);
            Vector2f v2 = new Vector2f(b, c);
            Vector2f v3 = new Vector2f(c, d);

            // sum of vectors
            Vector2f vSum = v1 + v2;
            Console.WriteLine("(Vector " + v1 + ") + (Vector " + v2 + ") equals (Vector " + vSum + ")");

            // subtract vectors
            Vector2f vSub = v3 - v2;
            Console.WriteLine("(Vector " + v3 + ") - (Vector " + v2 + ") equals Vector (" + vSub + ")");

            // calculate dot product of two vectors
            float vDot = v2 * v3;
            Console.WriteLine("(Vector " + v2 + ") dot (Vector " + v3 + ") equals " + vDot);

            // find vector which is perpendicular to v1
            Vector2f vPerp = v1.Perpendicular;
            Console.WriteLine("(Vector " + v1 + ") is perpendicular to (Vector " + vPerp + ")");

            // Create rectangle in eal units
            Rectangle2f rect = new Rectangle2f(10, 15, 90, 80, Unit.Millimeters);

            // Crop rectangle top and right margins by 1 cm
            Rectangle2f rectCropped = rect.Cropped(DistanceF.Zero, new DistanceF(1, Unit.Centimeters), new DistanceF(1, Unit.Centimeters), DistanceF.Zero);

            Console.WriteLine("(Rectangle " + rect + ") with top and right cm cropped is equal to (Rectangle " + rectCropped + ")");

            Console.ReadKey();
        }
    }
}
