namespace Simulator.Maps;

public abstract class BigMap : Map
{
    //private Dictionary<Point, List<IMappable>> _fields;

    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000 || sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException("Map size is too large.");
        }
    }
}