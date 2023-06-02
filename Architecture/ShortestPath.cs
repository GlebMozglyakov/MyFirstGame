using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KillZombie.Models
{
    class ShortestPath
    {
        public static List<Point> FindPath(int[,] map, Point start, Point final)
        {
            var closedSet = new List<PathNode>();
            var openSet = new List<PathNode>();
            var startNode = new PathNode()
            {
                Position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                PathLength = GetPathLength(start, final)
            };

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                var currentNode = openSet.OrderBy(node => node.PathLength).First();

                if (currentNode.Position == final)
                    return GetPathForNode(currentNode);

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                var neighbours = GetNeighbours(currentNode, final, map);

                foreach (var neighbourNode in neighbours)
                {
                    if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                        continue;

                    var openNode = openSet.FirstOrDefault(node =>
                      node.Position == neighbourNode.Position);

                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            return null;
        }

        private static List<PathNode> GetNeighbours(PathNode pathNode, Point final, int[,] map)
        {
            var result = new List<PathNode>();
            var neighbourPoints = new List<Point>();

            for (int dy = -1; dy <= 1; dy++)
                for (int dx = -1; dx <= 1; dx++)
                    if (dx != 0 && dy != 0) continue;
                    else neighbourPoints.Add(new Point(pathNode.Position.X + dx, pathNode.Position.Y + dy));


            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.X >= map.GetLength(1))
                    continue;
                if (point.Y < 0 || point.Y >= map.GetLength(0))
                    continue;
                if (map[point.Y, point.X] != 0)
                    continue;

                var neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart + 1,
                    PathLength = GetPathLength(point, final)
                };
                result.Add(neighbourNode);
            }
            return result;
        }

        private static List<Point> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Point>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();

            return result;
        }

        private static int GetPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
    }

    class PathNode
    {
        public Point Position { get; set; }

        public int PathLengthFromStart { get; set; }

        public PathNode CameFrom { get; set; }

        public int PathLength { get; set; }

        public int FullPathLength
        {
            get
            {
                return PathLengthFromStart + PathLength;
            }
        }
    }
}
