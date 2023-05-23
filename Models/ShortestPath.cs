using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KillZombie.Models
{
    public class PathNode
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

    public class ShortestPath
    {
        public static List<Point> FindPath(int[,] map, Point start, Point final)
        {
            var closedSet = new Collection<PathNode>();
            var openSet = new Collection<PathNode>();
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
            return null;//new List<Point>() { new Point(0, 0) };//null;
        }

        private static int GetPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }

        private static Collection<PathNode> GetNeighbours(PathNode pathNode,
  Point final, int[,] map)
        {
            var result = new Collection<PathNode>();

            Point[] neighbourPoints = new Point[4];
            neighbourPoints[0] = new Point(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[1] = new Point(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[2] = new Point(pathNode.Position.X, pathNode.Position.Y + 1);
            neighbourPoints[3] = new Point(pathNode.Position.X, pathNode.Position.Y - 1);

            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.X >= map.GetLength(1))
                    continue;
                if (point.Y < 0 || point.Y >= map.GetLength(0))
                    continue;
                if (map[point.Y, point.X] != 0) //&& (map[point.X, point.Y] != 1))
                    continue;

                var neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart +
                    GetDistanceBetweenNeighbours(),
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

            //for (int i = 0; i < result.Count; i++)
            //    result[i] = new Point(result[i].X * 32, result[i].Y * 32);
            return result;
        }
    }
}
