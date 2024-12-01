namespace AOC_1 {
    class Program {
        static void Main(string[] args) {
            List<int> listOne = [];
            List<int> listTwo = [];

            var lines = File.ReadLines("input.txt");
            foreach (var line in lines) {
                Array numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                listOne.Add(int.Parse(numbers.GetValue(0).ToString()));
                listTwo.Add(int.Parse(numbers.GetValue(1).ToString()));
            }

            ListSimilarity listSimilarity = new ListSimilarity(listOne, listTwo);

            ListSorter listOneSorter = new ListSorter(listOne);
            ListSorter listTwoSorter = new ListSorter(listTwo);

            int difference = 0;
            int similarity = 0;

            Console.WriteLine(listOneSorter.Length());

            for (int index = 0; index < listOneSorter.Length(); index++) {
                int num1 = listOneSorter.GetNextItem();
                int num2 = listTwoSorter.GetNextItem();
                int number = num1 - num2;
                
                if (number < 0) {
                    number *= -1;
                }

                difference += number;

                similarity += num1 * listSimilarity.GetSimilarityScore(num1);
            }

            Console.WriteLine($"Difference: {difference}");
            Console.WriteLine($"Similarity: {similarity}");
        }
    }
}