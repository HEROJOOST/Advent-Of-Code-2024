namespace AOC_4 {
    class Program {
        public static void Main(string[] args) {
            List<List<char>> xmasList = new List<List<char>>();
            int lineNumber = 0;

            foreach (string line in File.ReadLines("input.txt")) {
                xmasList.Add(new List<char>());
                foreach (char character in line) {
                    xmasList[lineNumber].Add(character);
                }
                lineNumber += 1;
            }

            WordFinder wordFinder = new WordFinder(xmasList);
            List<char> xmasWord = new List<char> { 'X', 'M', 'A', 'S' };

            Console.WriteLine(wordFinder.GetWordCount(xmasWord));
        }
    }
}