﻿using Simulator;
using Simulator.Maps;

namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int sizeX = 10, sizeY = 10;
        // Act
        var map = new SmallSquareMap(sizeX, sizeY);
        // Assert
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Fact]
    public void Constructor_NonSquareDimensions_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new SmallSquareMap(10, 15));
    }

    [Fact]
    public void Constructor_MinimalSize_ShouldWork()
    {
        var map = new SmallSquareMap(5, 5);
        Assert.Equal(5, map.SizeX);
        Assert.Equal(5, map.SizeY);
    }

    [Theory]
    [InlineData(4, 5)]
    [InlineData(5, 4)]
    [InlineData(21, 20)]
    [InlineData(20, 21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size, size);
        var point = new Point(x, y);

        // Act
        var result = map.Exist(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(17, 19, Direction.Up, 17, 19)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(10, 10, Direction.Right, 11, 10)]
    [InlineData(19, 19, Direction.Down, 19, 18)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.Next(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(19, 19, Direction.Up, 19, 19)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(15, 10, Direction.Right, 16, 9)]
    [InlineData(1, 0, Direction.Down, 1, 0)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(20, 20);
        var point = new Point(x, y);

        // Act
        var nextPoint = map.NextDiagonal(point, direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

}