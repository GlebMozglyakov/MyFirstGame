using KillZombies.Architecture;
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

        private static Texture2D green1CellTexture;

        private static Texture2D green2CellTexture;

        private static Texture2D greyCellTexture;

        private static Texture2D redCellTexture;

        public readonly MapCell[,] World;

        static List<Tile> tiels;

        public Line Height { get; set; }

        public Line Width { get; set; }

        public Map(MapCell[,] world)
        {
            World = world;
            LoadTiels();
        }

        private void LoadTiels()
        {
            brickTexture = Pictures.BrickCellTexture;
            boxTexture = Pictures.BoxCellTexture;
            green1CellTexture = Pictures.Green1CellTexture;
            green2CellTexture = Pictures.Green2CellTexture;
            greyCellTexture = Pictures.GreyCellTexture;
            redCellTexture = Pictures.RedCellTexture;
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
                            tile = new Tile(green1CellTexture, rectangle);
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
                            tile = new Tile(green2CellTexture, rectangle);
                            tiels.Add(tile);
                            break;
                        case MapCell.Grey:
                            tile = new Tile(greyCellTexture, rectangle);
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
