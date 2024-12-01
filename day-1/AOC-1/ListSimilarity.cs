namespace AOC_1 {
    public class ListSimilarity {
        private Dictionary<int, int> _similarityScore = new Dictionary<int, int>();

        public ListSimilarity(List<int> arrayOne, List<int> arrayTwo) {
            foreach (int number in arrayOne) {
                this._similarityScore[number] = 0;
            }

            foreach (int number in arrayTwo) {
                if (this._similarityScore.ContainsKey(number)) {
                    this._similarityScore[number] += 1;
                }
            }
        }

        public int GetSimilarityScore(int number) {
            if (this._similarityScore.ContainsKey(number)) {
                return this._similarityScore[number];
            }
            return 0;
        }
    }
}