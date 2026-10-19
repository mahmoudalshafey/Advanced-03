namespace Advanced_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
        }

        static void Exercise1()
        {

            List<int> grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First: {grades.First()}, Last: {grades.Last()}");

            grades.Sort();                       // ascending
            Console.WriteLine("Sorted: " + string.Join(", ", grades));

            int firstAbove90 = grades.First(g => g > 90);
            Console.WriteLine($"First grade above 90: {firstAbove90}");

            List<int> failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing grades (< 75): " + string.Join(", ", failing));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After removing failing: " + string.Join(", ", grades));

            Console.WriteLine($"Any grade equals 100? {grades.Any(g => g == 100)}");

            List<string> labels = grades.Select(g => $"Grade: {g}").ToList();
            labels.ForEach(Console.WriteLine);
        }

        static void Exercise2()
        {

            var board = new SortedDictionary<int, string>
        {
            { 500, "Ahmed" },
            { 200, "Sara" },
            { 800, "Ali" },
            { 350, "Mona" }
        };

            Console.WriteLine("All entries (sorted by score):");
            foreach (var kv in board)
                Console.WriteLine($"  {kv.Key} -> {kv.Value}");

            Console.WriteLine($"First key: {board.Keys.First()}");
            Console.WriteLine($"First value: {board.Values.First()}");

            Console.WriteLine($"Score 500 exists? {board.ContainsKey(500)}");

            if (board.TryGetValue(999, out string? player))
                Console.WriteLine($"Player with 999: {player}");
            else
                Console.WriteLine("No player with score 999");

            board.Remove(200);
            Console.WriteLine("After removing score 200:");
            foreach (var kv in board)
                Console.WriteLine($"  {kv.Key} -> {kv.Value}");
        }
    }
}
