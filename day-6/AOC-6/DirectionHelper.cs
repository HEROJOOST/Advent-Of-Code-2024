namespace AOC_6 {
    public static class DirectionHelper {
        public static Direction GetDirection(Direction value) {
            switch (value) {
                case Direction.Up: 
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Up;
                default:
                    return Direction.None;
            }
        } 

        public static Direction GetDirection(int value) {
            int newValue = value % 4;
            switch (newValue) {
                case 1: 
                    return Direction.Right;
                case 2:
                    return Direction.Down;
                case 3:
                    return Direction.Left;
                case 0:
                    return Direction.Up;
                default:
                    return Direction.None;
            }
        }

        public static Direction GetDirection(char value) {
            switch (value) {
                case '>':
                    return Direction.Right;
                case '^':
                    return Direction.Up;
                case 'v':
                    return Direction.Down;
                case '<':
                    return Direction.Left;
                default:
                    return Direction.None;
            }
        }

        public static Tuple<int, int> GetDirectionValues(Direction direction) {
            switch (direction) {
                case Direction.Up:
                    return new Tuple<int, int>(-1, 0);
                case Direction.Down:
                    return new Tuple<int, int>(1, 0);
                case Direction.Right:
                    return new Tuple<int, int>(0, 1);
                case Direction.Left:
                    return new Tuple<int, int>(0, -1);
            }
            return new Tuple<int, int>(0, 0);
        }
    }
}