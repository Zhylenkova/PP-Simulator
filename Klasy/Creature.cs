using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Creature
{

    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameSet = false;
    private bool _levelSet = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameSet) return;
            string trimmedName = value.Trim();
            if(trimmedName.Length>25)
                trimmedName=trimmedName.Substring(0, 25).TrimEnd();
            if (trimmedName.Length < 3)
                trimmedName = trimmedName.PadRight(3, '#');

            
            if (char.IsLower(trimmedName[0]))
                trimmedName = char.ToUpper(trimmedName[0]) + trimmedName.Substring(1);

            _name = trimmedName;
            _nameSet = true; 
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (_levelSet) return; 
            _level = Math.Clamp(value, 1, 10);
            _levelSet = true; 
        }
    }
    public string Info => $"{Name} <{Level}>";
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi()
    {
        Console.WriteLine($"Hello, I'm {Name} at level {Level}!");
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public void Go(Direction direction)
    {
        
        string directionName = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {directionName}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction); 
        }
    }

    public void Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        Go(directions);
    }
}