﻿using System;
using System.Collections.Generic;
using TVGL;


namespace TVGL_Test
{
    internal partial class Program
    {

        [STAThread]
        private static void Main2(string[] args)
        {
            Test11();
        }

        private static void Test1()
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { -0.1, -0.1, 0.0 }));         
            var point1 = new Point(new Vertex(new[]{ 1.0, 0.25, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 0.4, 1.2, 0.0 }));
            var point3 = new Point(new Vertex(new[]{ 0.75, 0.5, 0.0}));
            var point4 = new Point(new Vertex(new[]{ 0.6, 0.4, 0.0  }));
            var point5 = new Point(new Vertex(new[]{ 0.4, 0.6, 0.0  }));
            var point6 = new Point(new Vertex(new[]{0.2, 0.1, 0.0}));
            var point7 = new Point(new Vertex(new[] { 0.3, 1.2, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 0.2, 1.4, 0.0 }));
            var point9 = new Point(new Vertex(new[] { 0.2, 0.4, 0.0 }));
            var point10 = new Point(new Vertex(new[] { -0.1, 1.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8, point9, point10};

            //Clockwise ordered negative loop inside positive loop
            var point11 = new Point(new Vertex(new[] { 0.4, 0.2, 0.0 }));
            var point12 = new Point(new Vertex(new[] { 0.3, 0.3, 0.0 }));
            var point13 = new Point(new Vertex(new[] { 0.6, 0.25, 0.0 }));
            var negLoop1 = new Point[] { point11, point12, point13 };

            //2nd Clockwise ordered negative loop inside positive loop
            var point14 = new Point(new Vertex(new[] { 0.1, 0.5, 0.0 }));
            var point15 = new Point(new Vertex(new[] { 0.2, 0.2, 0.0 }));
            var point16 = new Point(new Vertex(new[] { 0.1, 0.2, 0.0 }));
            var point17 = new Point(new Vertex(new[] { 0.1, 0.4, 0.0 }));
            var negLoop2 = new Point[] { point14, point15, point16, point17 };

            //2nd Counterclockwise ordered positive loop
            var point18 = new Point(new Vertex(new[] { 0.3, 0.4, 0.0 }));
            var point19 = new Point(new Vertex(new[] { 0.4, 0.8, 0.0 }));
            var point20 = new Point(new Vertex(new[] { 0.3, 1.6, 0.0 }));
            var point21 = new Point(new Vertex(new[] { 0.375, 0.75, 0.0 }));
            var posLoop2 = new Point[] { point18, point19, point20, point21};

            //Add loops to a list of loops
            var listPoints = new List<Point[]> { posLoop1, negLoop1, posLoop2, negLoop2};
            var listBool = new Boolean[] { true,false, true, false };

            var listTriangles = TriangulatePolygon.Run(listPoints, listBool);


            //Print Triangles to Console
            var i = 1;
            Console.WriteLine("New Triangles");
            foreach (var triangle in listTriangles)
            {
                Console.WriteLine("Triangle: " + i);
                Console.WriteLine("(" + (triangle[0].X) + " , " + (triangle[0].Y) + ")");
                Console.WriteLine("(" + (triangle[1].X) + " , " + (triangle[1].Y) + ")");
                Console.WriteLine("(" + (triangle[2].X) + " , " + (triangle[2].Y) + ")");
                i++;
            }

            Console.ReadLine();

        }//End TestFunction

        private static void Test2()
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { -1.0, -1.0, 0.0 }));         
            var point1 = new Point(new Vertex(new[]{ -0.5, -1.5, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 0.0, -2.0, 0.0 }));
            var point3 = new Point(new Vertex(new[]{ 0.0, 0.0, 0.0}));
            var point4 = new Point(new Vertex(new[]{ 0.001, -2.001, 0.0  }));
            var point5 = new Point(new Vertex(new[]{ -1.0, -2.0, 0.0  }));
            var point6 = new Point(new Vertex(new[] { 0.001, -2.002, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 0.3, 1.2, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 0.2, 1.2, 0.0 }));
            var point9 = new Point(new Vertex(new[] { 0.2, 0.4, 0.0 }));
            var point10 = new Point(new Vertex(new[] { -0.1, 0.4, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8, point9, point10};

            //Clockwise ordered negative loop inside positive loop
            var point11 = new Point(new Vertex(new[] { -0.99, -1.0, 0.0 }));
            var point12 = new Point(new Vertex(new[] { -.001, 0.0, 0.0 }));    
            var point13 = new Point(new Vertex(new[] {-0.2, -1.0, 0.0 }));
            var negLoop1 = new Point[] { point11, point12, point13 };

            //Add loops to a list of loops
            var listPoints = new List<Point[]> { posLoop1, negLoop1};
            var listBool = new Boolean[] { true,false };

            var listTriangles = TriangulatePolygon.Run(listPoints, listBool);


            //Print Triangles to Console
            var i = 1;
            Console.WriteLine("New Triangles");
            foreach (var triangle in listTriangles)
            {
                Console.WriteLine("Triangle: " + i);
                Console.WriteLine("(" + (triangle[0].X) + " , " + (triangle[0].Y) + ")");
                Console.WriteLine("(" + (triangle[1].X) + " , " + (triangle[1].Y) + ")");
                Console.WriteLine("(" + (triangle[2].X) + " , " + (triangle[2].Y) + ")");
                i++;
            }

            Console.ReadLine();

        }//End TestFunction

        private static void Test3() //ClipperOffset
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { -0.1, -0.1, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 1.0, 0.25, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 0.4, 1.2, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 0.75, 0.5, 0.0 }));
            var point4 = new Point(new Vertex(new[] { 0.6, 0.4, 0.0 }));
            var point5 = new Point(new Vertex(new[] { 0.4, 0.6, 0.0 }));
            var point6 = new Point(new Vertex(new[] { 0.2, 0.1, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 0.3, 1.2, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 0.2, 1.4, 0.0 }));
            var point9 = new Point(new Vertex(new[] { 0.2, 0.4, 0.0 }));
            var point10 = new Point(new Vertex(new[] { -0.1, 1.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8, point9, point10 };


            //Add loops to a list of loops
            var listPoints = new List<Point[]> { posLoop1 };
            var offsets = TVGL.Offset.Run(listPoints);


            //Print Triangles to Console
            var i = 1;
            Console.WriteLine("New Loops");
            foreach (var Loop in offsets)
            {
                Console.WriteLine("Triangle: " + i);           
                foreach (var vertex in Loop)
                {
                    Console.WriteLine("(" + (vertex.X) + " , " + (vertex.Y) + ")");
                }
                i++;
            }

            Console.ReadLine();

        }//End TestFunction

        private static void Test4() //Bounding Rectangle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { -0.1, -0.1, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 1.0, 0.25, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 0.4, 1.2, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 0.75, 0.5, 0.0 }));
            var point4 = new Point(new Vertex(new[] { 0.6, 0.4, 0.0 }));
            var point5 = new Point(new Vertex(new[] { 0.4, 0.6, 0.0 }));
            var point6 = new Point(new Vertex(new[] { 0.2, 0.1, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 0.3, 1.2, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 0.2, 1.4, 0.0 }));
            var point9 = new Point(new Vertex(new[] { 0.2, 0.4, 0.0 }));
            var point10 = new Point(new Vertex(new[] { -0.1, 1.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8, point9, point10 };


            //Add loops to a list of loops
            var boundingRectangle = TVGL.MinimumEnclosure.BoundingRectangle(posLoop1);
            Console.WriteLine("Best Angle for Bounding Box:");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle, 3) + " radians");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle * 180 / Math.PI, 3) + " degrees (Clockwise rotation of left caliper,");
            Console.WriteLine("which could now look like its on top.)");
            Console.WriteLine();
            Console.WriteLine("Minimum Bounding Area:");
            Console.WriteLine(boundingRectangle.Area);
            Console.ReadLine();
        }//End TestFunction


        private static void Test5() //Bounding Rectangle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 0.0, 0.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 2.0, 0.0, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 6.0, 1.0, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 9.0, 3.0, 0.0 }));
            var point4 = new Point(new Vertex(new[] { 8.0, 5.0, 0.0 }));
            var point5 = new Point(new Vertex(new[] { 5.0, 4.5, 0.0 }));
            var point6 = new Point(new Vertex(new[] { 3.0, 3.4, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 2.0, 2.5, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 1.0, 1.5, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8 };



            //Add loops to a list of loops
            var boundingRectangle = TVGL.MinimumEnclosure.BoundingRectangle(posLoop1);
            Console.WriteLine("Best Angle for Bounding Box:");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle, 3) + " radians");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle * 180 / Math.PI, 3) + " degrees (Clockwise rotation of left caliper,");
            Console.WriteLine("which could now look like its on top.)");
            Console.WriteLine();
            Console.WriteLine("Minimum Bounding Area:");
            Console.WriteLine(boundingRectangle.Area);
            Console.ReadLine();
        }//End TestFunction

        private static void Test6() //Bounding Rectangle: Simple Box
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 0.0, 0.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 1.0, 0.0, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 1.0, 1.0, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 0.0, 1.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3};



            //Add loops to a list of loops
            var boundingRectangle = TVGL.MinimumEnclosure.BoundingRectangle(posLoop1);
            Console.WriteLine("Best Angle for Bounding Box:");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle, 3) + " radians");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle * 180 / Math.PI, 3) + " degrees (Clockwise rotation of left caliper,");
            Console.WriteLine("which could now look like its on top.)");
            Console.WriteLine();
            Console.WriteLine("Minimum Bounding Area:");
            Console.WriteLine(boundingRectangle.Area);
            Console.ReadLine();
        }//End TestFunction

        private static void Test7() //Bounding Rectangle: Simple Triangle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 1.25, 1.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 0.0, 0.75, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 1.0, 0.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2 };



            //Add loops to a list of loops
            var boundingRectangle = TVGL.MinimumEnclosure.BoundingRectangle(posLoop1);
            Console.WriteLine("Best Angle for Bounding Box:");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle, 3) + " radians");
            Console.WriteLine(Math.Round(boundingRectangle.BestAngle * 180 / Math.PI, 3) + " degrees (Clockwise rotation of left caliper,");
            Console.WriteLine("which could now look like its on top.)");
            Console.WriteLine();
            Console.WriteLine("Minimum Bounding Area:");
            Console.WriteLine(boundingRectangle.Area);
            Console.ReadLine();
        }//End TestFunction

        private static void Test8() //Bounding Circle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 0.0, 0.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 1.0, 0.0, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 1.0, 1.0, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 0.0, 1.0, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3 };
 
            //Add loops to a list of loops
            var minimumCircle = MinimumEnclosure.MinimumCircle(new List<Point> (posLoop1));  
            Console.WriteLine("Minimum Area Circle:");
            Console.WriteLine(Math.Round(minimumCircle.Area, 3));
            Console.WriteLine();
            Console.WriteLine("Radius:");
            Console.WriteLine(Math.Round(minimumCircle.Radius, 3));
            Console.WriteLine();
            Console.WriteLine("Center:");
            Console.WriteLine("(" + Math.Round(minimumCircle.Center.X, 3) + "," + Math.Round(minimumCircle.Center.Y, 3) + ")");
            Console.ReadLine();
        }//End TestFunction

        private static void Test9() //Bounding Circle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 0.0, 0.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 2.0, 0.0, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 6.0, 1.0, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 9.0, 3.0, 0.0 }));
            var point4 = new Point(new Vertex(new[] { 8.0, 5.0, 0.0 }));
            var point5 = new Point(new Vertex(new[] { 5.0, 4.5, 0.0 }));
            var point6 = new Point(new Vertex(new[] { 3.0, 3.4, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 2.0, 2.5, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 1.0, 1.5, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8 };

            //Add loops to a list of loops
            var minimumCircle = MinimumEnclosure.MinimumCircle(new List<Point>(posLoop1));
            Console.WriteLine("Minimum Area Circle:");
            Console.WriteLine(Math.Round(minimumCircle.Area, 3));
            Console.WriteLine();
            Console.WriteLine("Radius:");
            Console.WriteLine(Math.Round(minimumCircle.Radius, 3));
            Console.WriteLine();
            Console.WriteLine("Center:");
            Console.WriteLine("(" + Math.Round(minimumCircle.Center.X, 3) + "," + Math.Round(minimumCircle.Center.Y, 3) + ")");
            Console.ReadLine();
        }//End TestFunction

        private static void Test10() //Is Point inside polygon
        {
            //Counterclockwise ordered positive loop
            var point0 = new Point(new Vertex(new[] { 0.0, 0.0, 0.0 }));
            var point1 = new Point(new Vertex(new[] { 2.0, 0.0, 0.0 }));
            var point2 = new Point(new Vertex(new[] { 6.0, 1.0, 0.0 }));
            var point3 = new Point(new Vertex(new[] { 9.0, 3.0, 0.0 }));
            var point4 = new Point(new Vertex(new[] { 8.0, 5.0, 0.0 }));
            var point5 = new Point(new Vertex(new[] { 5.0, 5.0, 0.0 }));
            var point6 = new Point(new Vertex(new[] { 3.0, 3.4, 0.0 }));
            var point7 = new Point(new Vertex(new[] { 2.0, 2.5, 0.0 }));
            var point8 = new Point(new Vertex(new[] { 1.0, 1.5, 0.0 }));
            var posLoop1 = new Point[] { point0, point1, point2, point3, point4, point5, point6, point7, point8 };

            var pointInQuestion = new Point(new Vertex(new[] { 5.1, 5.0, 0.0 }));
            //Add loops to a list of loops
            var isPointInside = MiscFunctions.IsPointInsidePolygon(new List<Point>(posLoop1), pointInQuestion, false);
            Console.WriteLine("Is Point Inside Polygon?");
            Console.WriteLine(isPointInside);
            Console.ReadLine();
        }//End TestFunction

        private static void Test11() //Is Point inside triangle
        {
            //Counterclockwise ordered positive loop
            var point0 = new Vertex(new[] { 19.99, 26.168, 19.639 });
            var point1 =new Vertex(new[] { 13.6080,23.92,25.572 });
            var point2 =new Vertex(new[] {2.2697,4.28,5.9330});
            var posLoop1 = new [] { point0, point1, point2};

            //var pointInQuestion = new Vertex(new[] { 11.12985, 15.224, 12.786 }); //On a line
            //var pointInQuestion = new Vertex(new[] { 19.99, 26.168, 19.639 }); //On a vertex
            //var pointInQuestion = new Vertex(new[] { 5.42080538, 9.73828825, 11.39101034 }); 
            var pointInQuestion = new Vertex(new[] { 7.93885, 14.1000, 15.7525 }); 
            //Add loops to a list of loops
            var isPointInside = MiscFunctions.IsPointInsideTriangle(new List<Vertex>(posLoop1), pointInQuestion, true);
            Console.WriteLine("Is Point Inside Polygon?");
            Console.WriteLine(isPointInside);
            Console.ReadLine();
        }//End TestFunction
    }

}//End Namespace