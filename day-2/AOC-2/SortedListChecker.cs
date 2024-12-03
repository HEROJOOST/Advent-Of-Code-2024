namespace AOC_2 {
    public static class SortedListChecker {
        public static int maximumIncrement = 3;

        public static bool isSorted(List<int> sortedList, bool increasing, bool removal) {
            bool removalUsed = false;
            int lastItem = -1;

            foreach (int item in sortedList) {
                if (lastItem == -1) {
                    
                } else if (increasing) {
                    if (item <= lastItem || item > lastItem + maximumIncrement) {
                        if (removal && !removalUsed) {
                            removalUsed = true;
                            continue;
                        }
                        return false;
                    }
                } else {
                    if (item >= lastItem || item < lastItem - maximumIncrement) {
                        if (removal && !removalUsed) {
                            removalUsed = true;
                            continue;
                        }
                        return false;
                    }
                }

                lastItem = item;
            }

            return true;
        }
    }
}
