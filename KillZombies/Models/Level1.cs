﻿namespace KillZombies.Models
{
    class Level1
    {
        private static int[,] map = new[,] 
        { 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 2, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 2, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 2, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 2, 2, 2,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 0,  0, 4, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 4,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 4, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 4, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 4, 0, 0, 0,  0, 0, 0, 0, 2, 2, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 4, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 4, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 4, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 4,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 4, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  4, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 4, 0, 0, 0, 0, 0,  0, 4, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 4, 0, 0, 0, 2, 2, 2, 0,  0, 0, 0, 0, 0, 0, 4, 4, 4, 4,  4, 4, 0, 0, 0, 0, 0, 0, 0, 0,  4, 4, 4, 4, 4, 4, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 2, 0, 2, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 2, 2, 2, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 2, 2, 2, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 2, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 2, 2, 2, 2, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 1,},
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,  1, 1, 1, 1, 1, 1, 1, 1, 1, 1,},
        };

        public static MapCell[,] CreateWorld()
        {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            var world = new MapCell[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch(map[i, j])
                    {
                        case 0:
                            world[i, j] = MapCell.Green1;
                            break;
                        case 1:
                            world[i, j] = MapCell.Brick;
                            break; 
                        case 2:
                            world[i, j] = MapCell.Box;
                            break;
                        case 3:
                            world[i, j] = MapCell.Green2;
                            break;
                        case 4:
                            world[i, j] = MapCell.Grey;
                            break;
                    }
                }
            }

            return world;
        }
    }
}