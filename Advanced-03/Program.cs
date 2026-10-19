namespace Advanced_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
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
    }
}
