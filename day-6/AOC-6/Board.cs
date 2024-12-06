namespace AOC_6 {
    public class Board {

        public List<List<char>> Map;

        public List<Tuple<int, int>> _visitedPositions {
            private set;
            get;
        }

        public Board(List<List<char>> map) {
            this.Map = map;
            this._visitedPositions = new List<Tuple<int, int>>();
        }

        public bool IsWall(int y, int x) {
            if (!this.IsInBounds(y, x)) {
                return false;
            }
            return this.Map[y][x] == '#';
        }

        public bool IsInBounds(int y, int x) {
            if (y >= this.Map.Count || y < 0 || x >= this.Map[0].Count || x < 0) {
                return false;
            }
            return true;
        }

        public Tuple<int, int> GetGuardPosition() {
            for (int col = 0; col < this.Map.Count; col++) {
                for (int row = 0; row < this.Map[0].Count; row++) {
                    if (this.Map[col][row] == '^' || this.Map[col][row] == '>' || this.Map[col][row] == 'v' || this.Map[col][row] == '<') {
                        return new Tuple<int, int>(col, row);
                    }
                }
            }
            return new Tuple<int, int>(0, 0);
        }

        public bool Visit(Tuple<int, int> position) {
            if (this._visitedPositions.Contains(position) || !this.IsInBounds(position.Item1, position.Item2) || this.IsWall(position.Item1, position.Item2)) {
                return false;
            } else {
                this._visitedPositions.Add(position);
                return true;
            }
        }

        public int GetVisitedPositionCount() {
            return this._visitedPositions.Count;
        }

        public void LogMap() {
            for (int row = 0; row < this.Map.Count; row++) {
                Console.WriteLine();
                for (int col = 0; col < this.Map[0].Count; col++) {
                    if (this._visitedPositions.Contains(new Tuple<int, int>(row ,col))) {
                        Console.Write("X");
                    } else {
                        Console.Write(this.Map[row][col]);
                    }
                }
            }
        }

        public bool SetWall(Tuple<int, int> position) {
            if (this.Map[position.Item1][position.Item2] == '^' || this.IsWall(position.Item1, position.Item2) || !this.IsInBounds(position.Item1, position.Item2)) {
                return false;
            } else {
                this.Map[position.Item1].RemoveAt(position.Item2);
                this.Map[position.Item1].Insert(position.Item2, '#');
                return true;
            }
        }
    }
}