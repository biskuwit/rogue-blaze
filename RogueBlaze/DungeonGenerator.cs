namespace RogueBlaze
{
    public class DungeonGenerator
    {
        private string[] prefixes = { "ground" };

        private string[] middles =
        {
            "crusted",
            "dirt_brown",
            "dirt_dark",
            "grass",
            "grass_burnt",
            "sand"
        };

        public MapPosition[,] Map { get; }

        public DungeonGenerator(int width, int height)
        {
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
        }
    }
}