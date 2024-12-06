
using System.Text.RegularExpressions;

namespace AOC_5 {
    class Program {
        public static void Main(string[] args) {
            Dictionary<int, List<int>> rules = new Dictionary<int, List<int>>();
            List<List<int>> updates = new List<List<int>>();

            Regex rulesRegex = new Regex(@"^(\d{2})\|(\d{2})$");
            Regex orderRegex = new Regex(@"^(\d{2},?)+$");

            var lines = File.ReadLines("input.txt");
            foreach (string line in lines) {
                Match rulesMatch = rulesRegex.Match(line);
                Match orderMatch = orderRegex.Match(line);

                if (rulesMatch.Success) {
                    int rule = int.Parse(rulesMatch.Groups[1].Value);

                    if (!rules.ContainsKey(rule)) {
                        rules[rule] = new List<int>();
                    }

                    rules[rule].Add(int.Parse(rulesMatch.Groups[2].Value));
                } else if (orderMatch.Success) {
                    string[] numbersString = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<int> update = new List<int>();
                    foreach (string number in numbersString) {
                        update.Add(int.Parse(number));
                    }

                    updates.Add(update);
                }
            }

            PageOrdering pageOrdering = new PageOrdering(rules);
            int validUpdates = 0;
            int invalidUpdates = 0;

            foreach (List<int> order in updates) {
                if (pageOrdering.IsValidOrder(order)) {
                    validUpdates += MiddlePageNumber.GetMiddlePageNumber(order);
                } else {
                    invalidUpdates += MiddlePageNumber.GetMiddlePageNumber(pageOrdering.SortUpdateOrder(order));
                }
            }

            Console.WriteLine(validUpdates);
            Console.WriteLine(invalidUpdates);
        }
    }
}
