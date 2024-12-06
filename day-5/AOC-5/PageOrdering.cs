namespace AOC_5 {
    public class PageOrdering {

        private Dictionary<int, List<int>> _rules;

        public PageOrdering(Dictionary<int, List<int>> rules) {
            this._rules = rules;
        }

        public List<int> SortUpdateOrder(List<int> currentOrder) {
            List<int> updatedOrder = new List<int>(currentOrder);

            int index = -1;

            while (true) {
                if (index > 0) {
                    int number = updatedOrder[index];
                    updatedOrder.Remove(number);
                    updatedOrder.Insert(index - 1, number);
                }
                
                List<int> passedNumbers = new List<int>();
                foreach (int number in updatedOrder) {
                    if (!this._numberAppliedRules(number, passedNumbers)) {
                        index = updatedOrder.IndexOf(number);
                        break;
                    }

                    passedNumbers.Add(number);
                }
                if (this.IsValidOrder(updatedOrder)) {
                    break;
                }
            }

            return updatedOrder;
        }

        public bool IsValidOrder(List<int> order) {
            List<int> passedNumbers = new List<int>();
            foreach (int number in order) {
                if (!this._numberAppliedRules(number, passedNumbers)) {
                    return false;
                }

                passedNumbers.Add(number);
            }

            return true;
        }

        private bool _numberAppliedRules(int checkedNumber, List<int> numbers) {
            foreach (int number in numbers) {
                if (this._rules.ContainsKey(checkedNumber) && this._rules[checkedNumber].Contains(number)) {
                    return false;
                }
            }

            return true;
        }
    }

}
