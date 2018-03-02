using System;
using System.Collections.Generic;

namespace Zork
{

    public enum Directions
    {
        West,
        North,
        South,
        East
    }

	class Area
	{
        //something to hold connected nodes/areas
        public Dictionary<Directions, Area> neighbors = new Dictionary<Directions, Area>();
        //name of area
        public string name;
        //description of area
        public string description;
        //constructor
        public Area(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        //method to add an area to a specific direction
        public void AddArea(Area other, Directions dir)
        {
            neighbors.Add(dir, other);
        }


        //method that returns connected area in specific direction


	}
}
