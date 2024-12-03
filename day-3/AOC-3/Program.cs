using System.Text.RegularExpressions;

namespace AOC_3 {
    class Program {
        public static void Main(string[] args) {
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)|don't\(\)|do\(\)";

            string text = File.ReadAllText("input.txt");
            MatchCollection matches = Regex.Matches(text, pattern);

            bool enabled = true;

            int count = 0;
            foreach (Match match in matches) {
                if (match.ToString() == "do()") {
                    enabled = true;
                } else if (match.ToString() == "don't()") {
                    enabled = false;
                } else if (enabled) {
                    count += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                }
            }

            Console.WriteLine(count);
        }
    }
}