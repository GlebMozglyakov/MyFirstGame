using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace KillZombies.Models
{
    class Map
    {
        private static Texture2D brickTexture;

        private static Texture2D boxTexture;

        private static Texture2D green1Texture;

        private static Texture2D green2Texture;

        private static Texture2D greyTexture;

        private static Texture2D redTexture;

        public readonly MapCell[,] World;

        static List<Tile> tiels;

        public Line Height { get; set; }

        public Line Width { get; set; }

        private void LoadTiels(ContentManager Content)
        {
            brickTexture = Content.Load<Texture2D>("brick");
            boxTexture = Content.Load<Texture2D>("box");
            green1Texture = Content.Load<Texture2D>("green1");
            green2Texture = Content.Load<Texture2D>("green2");
            greyTexture = Content.Load<Texture2D>("grey");
            redTexture = Content.Load<Texture2D>("red");
        }

        public Map(MapCell[,] world, ContentManager Content)
        {
            World = world;
            LoadTiels(Content);
        }

        public List<Tile> CreateWorld()
        {
            tiels = new List<Tile>();
            var width = World.GetLength(0);
            var height = World.GetLength(1);
            var x = 0;
            var y = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var rectangle = new Rectangle(x, y, 32, 32);
                    var item = World[i, j];
                    Tile tile;

                    switch (item)
                    {
                        case MapCell.Green1:
                            tile = new Tile(green1Texture, rectangle);
                            tiels.Add(tile);
                            break;
                        case MapCell.Brick:
                            tile = new Tile(brickTexture, rectangle);
                            tiels.Add(tile);
                            break;
                        case MapCell.Box:
                            tile = new Tile(boxTexture, rectangle);
                            tiels.Add(tile);
                            break;
                        case MapCell.Green2:
                            tile = new Tile(green2Texture, rectangle);
                            tiels.Add(tile);
                            break;
                        case MapCell.Grey:
                            tile = new Tile(greyTexture, rectangle);
                            tiels.Add(tile);
                            break;
                    }

                    x += 32;
                }
                x = 0;
                y += 32;
            }

            return tiels;
        }
    }
}
