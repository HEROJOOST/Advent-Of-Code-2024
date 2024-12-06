namespace AOC_6 {
    class Program {
        public static void Main(string[] args) {
            List<List<char>> map = new List<List<char>>();

            var lines = File.ReadLines("input.txt");
            foreach (string line in lines) {
                List<char> row = new List<char>();
                foreach (char character in line) {
                    row.Add(character);
                }
                map.Add(row);
            }

            Board board = new Board(map);
            Guard guard = new Guard(board);
            InfiniteLoop infiniteLoop = new InfiniteLoop(board);

            guard.Run();
            board.LogMap();

            Console.WriteLine(board.GetVisitedPositionCount());
            Console.WriteLine(infiniteLoop.GetLoopCount());
        }
    }
}