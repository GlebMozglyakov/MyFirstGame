﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KillZombies.Models
{
    class Level1 : ILevel
    {
        public Zombie[] Zombies;

        private static SpriteBatch spriteBatch;

        private Point[] spawnPositions;

        private Borders borders;

        public Level1(ContentManager Content, SpriteBatch _spriteBatch, Borders borders, Player player)
        {
            Zombies = new Zombie[5];
            spriteBatch = _spriteBatch;
            this.borders = borders;
            spawnPositions = new Point[5] { new Point(100, 100), new Point(400, 800), new Point(900, 500), new Point(1750, 500), new Point(900, 400) };
            InitializeZombies(Content, player);
        }

        private void InitializeZombies(ContentManager Content, Player player)
        {
            for (int i = 0; i < 5; i++)
            {
                var position = spawnPositions[i];
                //var position = Position.ComputePosition(borders, CreateWorld());
                Zombies[i] = new Zombie(Content, new Rectangle(position.X, position.Y, 60, 120), i % 3, map, player, spriteBatch);
            }
        }

        public void SpawnZombies()
        {
            for (int i = 0;i < 5; i++)
                Zombies[i].Draw(spriteBatch);
        }

        public static int[,] map = new[,] 
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
