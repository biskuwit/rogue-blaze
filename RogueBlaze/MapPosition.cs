namespace RogueBlaze
{
    public class MapPosition
    {
        public MapPosition(int x, int y, TileType tileType, string imageName)
        {
            ImageName = imageName;
            TileType = tileType;
            X = x;
            Y = y;
        }

        public string ImageName { get; set; }
        public TileType TileType { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
