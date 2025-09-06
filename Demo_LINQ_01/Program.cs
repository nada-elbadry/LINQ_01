using Demo_LINQ_01.Data;

namespace Demo_LINQ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
           #region LINQ - Restriction Operators

            // 1. Find all products that are out of stock.
            var q1 = ListGenerators.ProductsList.Where(p => p.UnitsInStock == 0);
            Console.WriteLine("Products that are out of stock:");
            foreach (var p in q1)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            Console.WriteLine(new string('-', 50));

            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            var q2 = ListGenerators.ProductsList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            Console.WriteLine("Products in stock with price > 3.00:");
            foreach (var p in q2)
                Console.WriteLine($"{p.ProductName} - Price: {p.UnitPrice}");
            Console.WriteLine(new string('-', 50));

            // 3. Returns digits whose name is shorter than their value.
            string[] digits = { "zero", "one", "two", "three", "four",
                                "five", "six", "seven", "eight", "nine" };
            var q3 = digits
                .Select((d, i) => new { Digit = d, Index = i })
                .Where(x => x.Digit.Length < x.Index);
            Console.WriteLine("Digits shorter than their value:");
            foreach (var d in q3)
                Console.WriteLine($"{d.Digit} ({d.Index})");
            Console.WriteLine(new string('-', 50));

            #endregion

            #region LINQ - Ordering Operators

            // 1. Sort a list of products by name
            var q4 = ListGenerators.ProductsList.OrderBy(p => p.ProductName);
            Console.WriteLine("Products sorted by name:");
            foreach (var p in q4)
                Console.WriteLine(p.ProductName);
            Console.WriteLine(new string('-', 50));

            // 2. Case-insensitive sort of words in array
            string[] words1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var q5 = words1.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Words case-insensitive sort:");
            foreach (var w in q5)
                Console.WriteLine(w);
            Console.WriteLine(new string('-', 50));

            // 3. Sort products by units in stock (desc)
            var q6 = ListGenerators.ProductsList.OrderByDescending(p => p.UnitsInStock);
            Console.WriteLine("Products sorted by stock (desc):");
            foreach (var p in q6)
                Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");
            Console.WriteLine(new string('-', 50));

            // 4. Sort digits by length then alphabetically
            var q7 = digits.OrderBy(d => d.Length).ThenBy(d => d);
            Console.WriteLine("Digits sorted by length then alphabetically:");
            foreach (var d in q7)
                Console.WriteLine(d);
            Console.WriteLine(new string('-', 50));

            // 5. Sort words by length then case-insensitive
            var q8 = words1.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Words sorted by length then case-insensitive:");
            foreach (var w in q8)
                Console.WriteLine(w);
            Console.WriteLine(new string('-', 50));

            // 6. Sort products by category then unit price (desc)
            var q9 = ListGenerators.ProductsList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            Console.WriteLine("Products sorted by category then price desc:");
            foreach (var p in q9)
                Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");
            Console.WriteLine(new string('-', 50));

            // 7. Sort words by length then case-insensitive (desc)
            var q10 = words1.OrderBy(w => w.Length)
                            .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine("Words sorted by length then case-insensitive desc:");
            foreach (var w in q10)
                Console.WriteLine(w);
            Console.WriteLine(new string('-', 50));

            // 8. Digits whose second letter is 'i', reversed order
            var q11 = digits.Where(d => d.Length > 1 && d[1] == 'i')
                            .Reverse();
            Console.WriteLine("Digits with second letter 'i' reversed:");
            foreach (var d in q11)
                Console.WriteLine(d);
            Console.WriteLine(new string('-', 50));

            #endregion

            #region LINQ – Transformation Operators

            // 1. Return only product names
            var q12 = ListGenerators.ProductsList.Select(p => p.ProductName);
            Console.WriteLine("Product names:");
            foreach (var n in q12)
                Console.WriteLine(n);
            Console.WriteLine(new string('-', 50));

            // 2. Uppercase & lowercase versions of words
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var q13 = words2.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            Console.WriteLine("Words upper and lower:");
            foreach (var w in q13)
                Console.WriteLine($"{w.Upper} - {w.Lower}");
            Console.WriteLine(new string('-', 50));

            // 3. Select some properties, rename UnitPrice to Price
            var q14 = ListGenerators.ProductsList
                .Select(p => new { p.ProductID, p.ProductName, Price = p.UnitPrice });
            Console.WriteLine("Products with custom properties:");
            foreach (var p in q14)
                Console.WriteLine($"{p.ProductID} - {p.ProductName} - {p.Price}");
            Console.WriteLine(new string('-', 50));

            // 4. Check if int value matches its position
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var q15 = numbers.Select((num, index) => new { num, index, match = (num == index) });
            Console.WriteLine("Check if number == index:");
            foreach (var n in q15)
                Console.WriteLine($"{n.num} at index {n.index} match: {n.match}");
            Console.WriteLine(new string('-', 50));

            // 5. Return all pairs where A < B
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var q16 = from a in numbersA
                      from b in numbersB
                      where a < b
                      select new { a, b };
            Console.WriteLine("Pairs A < B:");
            foreach (var pair in q16)
                Console.WriteLine($"{pair.a}, {pair.b}");
            Console.WriteLine(new string('-', 50));

            // 6. Select all orders where total < 500
            var q17 = ListGenerators.CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500.00M);
            Console.WriteLine("Orders with total < 500:");
            foreach (var o in q17)
                Console.WriteLine($"Order ID: {o.OrderID}, Total: {o.Total}");
            Console.WriteLine(new string('-', 50));

            // 7. Select orders in 1998 or later
            var q18 = ListGenerators.CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year >= 1998);
            Console.WriteLine("Orders from 1998 or later:");
            foreach (var o in q18)
                Console.WriteLine($"Order ID: {o.OrderID}, Date: {o.OrderDate}");
            Console.WriteLine(new string('-', 50));

            #endregion
        }
    }
}
