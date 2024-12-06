namespace AOC_6 {
    public class Guard {

        public Tuple<int, int> Position {
            get;
            private set;
        }

        private Board _board;
        private Direction _direction;

        public Guard(Board board) {
            this._board = board;
            this.Position = board.GetGuardPosition();
            this._direction = DirectionHelper.GetDirection(this._board.Map[this.Position.Item1][this.Position.Item2]);
        }

        public bool TakeStep() {
            switch (this._direction) {
                case Direction.Up:
                    if (this._isWall(-1 ,0)) {
                        this._direction = DirectionHelper.GetDirection(this._direction);
                    } else if (this._isValidNextStep(-1, 0)) {
                        this._visitBoardPosition(-1, 0);
                    } else {
                        return false;
                    }
                    break;
                case Direction.Left:
                    if (this._isWall(0 ,-1)) {
                        this._direction = DirectionHelper.GetDirection(this._direction);
                    } else if (this._isValidNextStep(0, -1)) {
                        this._visitBoardPosition(0, -1);
                    } else {
                        return false;
                    }
                    break;
                case Direction.Right:
                    if (this._isWall(0 ,1)) {
                        this._direction = DirectionHelper.GetDirection(this._direction);
                    } else if (this._isValidNextStep(0, 1)) {
                        this._visitBoardPosition(0, 1);
                    } else {
                        return false;
                    }
                    break;
                case Direction.Down:
                    if (this._isWall(1 ,0)) {
                        this._direction = DirectionHelper.GetDirection(this._direction);
                    } else if (this._isValidNextStep(1, 0)) {
                        this._visitBoardPosition(1, 0);
                    } else {
                        return false;
                    }
                    break;
                case Direction.None:
                    Environment.Exit(1);
                    return false;
            }
            return true;
        }
        public void Run() {
            while (true) {
                if (!this.TakeStep()) {
                    break;
                }
            }
        }

        private bool _isValidNextStep(int y_dif, int x_dif) {
            return this._board.IsInBounds(this.Position.Item1 + y_dif, this.Position.Item2 + x_dif);
        }

        private bool _visitBoardPosition(int y_dif, int x_dif) {
            this.Position = new Tuple<int, int>(this.Position.Item1 + y_dif, this.Position.Item2 + x_dif);
            return this._board.Visit(this.Position);
        }

        private bool _isWall(int y_dif, int x_dif) {
            return this._board.IsWall(this.Position.Item1 + y_dif, this.Position.Item2 + x_dif);
        }
    }
}