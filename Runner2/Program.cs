using Simulator.Maps;
using System.Drawing;

namespace Simulator;

public class Program
{
    static void Main()
    {

    }

    static void Lab5a()
    {
        try
        {
            var r1 = new Rectangle(1, 3, 5, 7);
            Console.WriteLine($"{r1}");

            var p1 = new Point(3, 4);
            var p2 = new Point(7, 8);
            var r2 = new Rectangle(p1, p2);
            Console.WriteLine($"{r2}");

            var po1 = new Point(3, 4);
            var po2 = new Point(9, 10);
            Console.WriteLine($"Punkt {po1} jest w prostokącie: {r1.Contains(po1)}");
            Console.WriteLine($"Punkt {po2} jest w prostokącie: {r1.Contains(po2)}");

            var r3 = new Rectangle(2, 2, 2, 2);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Lab5b()
    {
        try
        {
            var map = new SmallSquareMap(8);
            Console.WriteLine($"Map size: {map.SizeY}");

            var po1 = new Point(6, 7);
            var po2 = new Point(10, 15);
            Console.WriteLine($"Point {po1} is in the map: {map.Exist(po1)}");
            Console.WriteLine($"Point {po2} is in the map: {map.Exist(po2)}");

            var poczPoint = new Point(6, 5);
            var nextPoint = map.Next(poczPoint, Direction.Left);
            Console.WriteLine($"Next point: {nextPoint}");

            var diagonalPoint = map.NextDiagonal(poczPoint, Direction.Up);
            Console.WriteLine($"Diagonal point: {diagonalPoint}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}