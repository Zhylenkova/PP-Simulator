﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20");
        }
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.Y >= 0 && p.X < Size && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);

        int newX = (nextPoint.X + Size) % Size;
        int newY = (nextPoint.Y + Size) % Size;

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);

        int newX = (nextDiagonalPoint.X + Size) % Size;
        int newY = (nextDiagonalPoint.Y + Size) % Size;

        return new Point(newX, newY);
    }

}
