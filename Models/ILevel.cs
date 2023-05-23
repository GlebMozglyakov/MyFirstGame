namespace KillZombie.Models
{
    interface ILevel
    {
        private static int[,] map;

        public static MapCell[,] CreateWorld()
        {
            var width = map.GetLength(0);
            var height = map.GetLength(1);
            var world = new MapCell[width, height];
            
            return world;
        }
    }
}
