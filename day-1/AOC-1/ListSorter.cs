namespace AOC_1 { 
    public class ListSorter {
        private List<int> _list;
        private int _listLength;
        private int _basePointer;
        private int _searchPointer;

        public ListSorter(List<int> list) {
            this._list = list;

            this._listLength = list.Count;
            this._basePointer = 0;
            this._searchPointer = 0;
        }

        public int GetNextItem() {
            int lowestNumber = this._list[this._searchPointer];
            int lowestNumberIndex = this._searchPointer;

            while (this._searchPointer < this._listLength) {
                int number = this._list[this._searchPointer];
                
                if (number < lowestNumber) {
                    lowestNumber = number;
                    lowestNumberIndex = this._searchPointer;
                }

                this._searchPointer += 1;
            }

            int swappedNumber = this._list[this._basePointer];
            this._list[this._basePointer] = this._list[lowestNumberIndex];
            this._list[lowestNumberIndex] = swappedNumber;

            this._basePointer += 1;
            this._searchPointer = this._basePointer;

            return lowestNumber;
        }

        public int Length() {
            return this._list.Count;
        }
    }
}