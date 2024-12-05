namespace AOC_4 {
    public class WordFinder {
        private List<List<char>> _list;
        private int _height;
        private int _width;

        public WordFinder(List<List<char>> charList) {
            this._list = charList;
            this._height = charList.Count;
            this._width = charList[this._height].Count;
        }   

        public int GetWordCount(List<char> word) {
            int count = 0;

            for (int row = 0; row < this._height; row++) {
                for (int index = 0; index < this._width; index++) {
                    if (this._list[row][index] == word[0]) {
                        count += this._CheckDirections(word, row, index);
                    }
                }
            }
            return count;
        }

        private int _CheckDirections(List<char> word, int row, int index) {
            int[][] directions = new int[][] {
                new int[] { 0, 1 },  // Right
                new int[] { 0, -1 }, // Left
                new int[] { 1, 0 },  // Down
                new int[] { -1, 0 }, // Up
                new int[] { 1, 1 },  // Diagonal down-right
                new int[] { -1, -1 }, // Diagonal up-left
                new int[] { 1, -1 }, // Diagonal down-left
                new int[] { -1, 1 }  // Diagonal up-right
            };

            int count = 0;
            int wordLength = word.Count;

            bool MatchesDirection(int rowDelta, int colDelta) {
                for (int i = 0; i < wordLength; i++) {
                    int calculatedRow = row + i * rowDelta;
                    int calculatedCol = index + i * colDelta;

                    if (0 > calculatedRow && calculatedRow >= this._list.Count && 0 > calculatedCol && calculatedCol >= this._width) {
                        return false;
                    } 

                    if (this._list[calculatedRow][calculatedCol] != word[i]) {
                        return false;
                    }

                    // if (calculatedRow < 0 || calculatedRow >= this._height || calculatedCol < 0 || calculatedCol >= this._width || this._list[calculatedRow][calculatedCol] != word[i]) {
                    //     return false;
                    // }
                }
                return true;
            }

            foreach (var direction in directions) {
                if (MatchesDirection(direction[0], direction[1])) {
                    count++;
                }
            }

            return count;
        }
    }
}
