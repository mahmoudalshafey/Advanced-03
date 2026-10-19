namespace Advanced_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
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

        static void Exercise3()
        {

            var book = new Dictionary<string, string>
        {
            { "Ahmed", "0100-111-1111" },
            { "Sara",  "0100-222-2222" },
            { "Ali",   "0100-333-3333" },
            { "Mona",  "0100-444-4444" }
        };

            book["Omar"] = "0100-555-5555";
            book["Sara"] = "0100-999-9999";   
            Console.WriteLine("Added Omar and updated Sara using [].");

            try
            {
                book.Add("Ahmed", "0100-000-0000");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Add() failed: {ex.Message}");
            }

            bool added = book.TryAdd("Ahmed", "0100-000-0000");
            Console.WriteLine($"TryAdd() succeeded? {added}");

            Console.WriteLine($"Contains 'Hassan'? {book.ContainsKey("Hassan")}");

            string phone = book.GetValueOrDefault("Hassan", "Not Found");
            Console.WriteLine($"Hassan: {phone}");

            Console.WriteLine("Keys:   " + string.Join(", ", book.Keys));
            Console.WriteLine("Values: " + string.Join(", ", book.Values));
        }

        static void Exercise4()
        {

            var emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            emails.Add("ahmed@test.com");
            emails.Add("AHMED@test.com");  
            emails.Add("sara@test.com");
            emails.Add("Sara@Test.Com");    
            Console.WriteLine($"Count: {emails.Count}");
            Console.WriteLine("Why? The comparer is OrdinalIgnoreCase, so \"ahmed@test.com\" and");
            Console.WriteLine("\"AHMED@test.com\" are treated as the same value; a HashSet never");
            Console.WriteLine("stores duplicates, so only 2 emails remain.");
            Console.WriteLine("Stored: " + string.Join(", ", emails));

            var setA = new HashSet<int> { 1, 2, 3, 4, 5 };
            var setB = new HashSet<int> { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("UnionWith:     " + string.Join(", ", union));

            var intersect = new HashSet<int>(setA);
            intersect.IntersectWith(setB);
            Console.WriteLine("IntersectWith: " + string.Join(", ", intersect));

            var except = new HashSet<int>(setA);
            except.ExceptWith(setB);
            Console.WriteLine("ExceptWith:    " + string.Join(", ", except));

            var small = new HashSet<int> { 1, 2 };
            Console.WriteLine($"{{1,2}} is subset of Set A? {small.IsSubsetOf(setA)}");
        }
    }
}
