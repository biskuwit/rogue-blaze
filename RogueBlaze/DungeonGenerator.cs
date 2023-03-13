namespace RogueBlaze
{
    public class DungeonGenerator
    {
        private string DungeonWallSet;

        public MapPosition[,] Map { get; }

        Random random = new Random();

        // Walls with borders- "cave", "ruins", "stone" 
        // Wall-sets have tiles 1-6 halved; can be used to round off the top 
        // and - in junction with this - to paste over bottom part of lowermost floors for same... 
        // Wall tiles 7-12 have no front-face 
        // Wall tiles 13 is special? 
        // Wall tiles 14-19 have a front-face 
        private readonly String[] WallSets = new[] { "crypt", "dungeon", };
        private readonly int[] WallsWithoutFront = new[] { 7, 8, 9, 10, 11, 12 };
        private readonly int[] WallsWithFront = new[] { 14, 15, 16, 17, 18, 19 };
        private readonly String[] BaseFloorSets = new[] { "blue", "dark", "grey" };
        private readonly int[] BaseFloorIndexes = new[] { 1, 2, 3, 4, 5 };

        public DungeonGenerator(int width, int height)
        {
            // Choose random wall-set for this entire dungeon
            DungeonWallSet = "wall_" + RandomElement(WallSets);

            Map = new MapPosition[width, height];
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
                Map[i, j] = new MapPosition
                {
                    X = i,
                    Y = j,
                    ImageName = "floor_extra_11"
                };
        }

        public void Generate()
        {
            CreateRoom(1, 3, 6, 7);
        }

        private T RandomElement<T>(T[] elements)
        {
            return elements[random.Next(0, elements.Length)];
        }

        private void SetWall(int x, int y, int[] wallIndexes)
        {
            Map[x, y].ImageName = DungeonWallSet + "_" + RandomElement(wallIndexes);
        }

        private void SetFloor(int x, int y, string floorSet, int[] floorIndexes)
        {
            Map[x, y].ImageName = "floor_set_" + floorSet + "_" + RandomElement(floorIndexes);
        }

        private void CreateRoom(int leftX, int topY, int width, int height)
        {
            // Choose random floor-set for this room
            var floorSet = RandomElement(BaseFloorSets);

            // Corners
            SetWall(leftX, topY, WallsWithoutFront);
            SetWall(leftX + width - 1, topY, WallsWithoutFront);
            SetWall(leftX, topY + height - 1, WallsWithFront);
            SetWall(leftX + width - 1, topY + height - 1, WallsWithFront);

            // Rest of top row and bottom row
            for (var x = 1; x < width - 1; x++)
            {
                SetWall(leftX + x, topY, WallsWithoutFront);
                SetWall(leftX + x, topY + height - 1, WallsWithFront);
            }

            int rightX = leftX + width;
            int bottomY = topY + height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    if (x == 0 || x == width - 1)
                        SetWall(leftX + x, topY + y, WallsWithoutFront);
                    else
                        SetFloor(leftX + x, topY + y, floorSet, BaseFloorIndexes);
                }
            }
        }
    }
}