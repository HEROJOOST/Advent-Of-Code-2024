namespace AOC_2 {
    class Program {
        public static void Main(string[] args) {
            int validLevels = 0;
            int validLevelsDampener = 0;

            var lines = File.ReadLines("input.txt");
            foreach (var line in lines) {
                string[] numbersString = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                List<int> numbers = new List<int>();
                foreach (string number in numbersString) {
                    numbers.Add(int.Parse(number));
                }

                if (SortedListChecker.isSorted(numbers, true, false) || SortedListChecker.isSorted(numbers, false, false)) {
                    validLevels += 1;
                }

                if (SortedListChecker.isSorted(numbers, true, true) || SortedListChecker.isSorted(numbers, false, true)) {
                    validLevelsDampener += 1;
                }
            }

            Console.WriteLine($"Save reports: {validLevels}");
            Console.WriteLine($"Save reports: {validLevelsDampener}");
        }
    }
}