namespace AOC_6 {
    public class InfiniteLoop {
        private Board _board;

        private Guard _guard;

        public InfiniteLoop(Board board) {
            this._board = board;
            this._guard = new Guard(_board);
        }

        public int GetLoopCount() {
            int count = 0;

            while (true) {
                for (int directionNumber = 0; directionNumber <= 3; directionNumber++) {
                    Board board = new Board(this._board.Map);
                    Guard guard = new Guard(board);
                    Guard guard1 = new Guard(board);

                    while (true) {
                        if (!guard1.TakeStep()) {
                            break;
                        }
                    }

                    Tuple<int, int> guardPosition = this._guard.Position;
                    Tuple<int, int> direction = DirectionHelper.GetDirectionValues(DirectionHelper.GetDirection(directionNumber));

                    if (!board.SetWall(new Tuple<int, int>(guardPosition.Item1 + direction.Item1, guardPosition.Item2 + direction.Item2))) {
                        continue;
                    }

                    while (true) {
                        if (!guard.TakeStep()) {
                            break;
                        }
                    }

                    Console.WriteLine();
                }

                if (!this._guard.TakeStep()) {
                    break;
                }
            }

            return count;
        }
    }
}