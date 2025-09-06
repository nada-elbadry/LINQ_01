namespace Demo_LINQ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implicitly Typed Local Variable

            #region var 
            ////string Name = "Ahmed";

            //var Data = "Ahmed"; // Implicit Type 
            //					// Compiler Will Detect its type at compile time based on its Initial Value 

            //var X = null; // Invalid Can Not Initialize With Null
            //var Y; // Invalid Must Be Initialized 

            //Data = null; // Valid 
            //Data = 5; // Invalid
            //		  // after Initialization , Can Not Change Variable Type 
            //Data = "Amr";

            #endregion

            #region Dynamic 
            //dynamic Data = "Ali";
            //// CLR Will Detect Type Of Variable At RunTime
            //// Based On Its Last Assigned Value 

            //Data = 5;
            //// After Initialization , You Can Change Data Type Of Variable 
            //Data = null;
            //Data = true;

            //dynamic X;
            //// Can Declare Variable With Dynamic Without Initialization

            //dynamic Y = null;
            //// Can Be Initialized With null;

            #endregion

            //for (var i = 0; i < 10; i++) { }
            //foreach (var item in args) { }

            ////var X = null; // Invalid
            //dynamic X = null;
            //Console.WriteLine(X); // RuntimeBinderException

            #endregion

            #region Extension Method
            //int X = 12345;
            //int ReversedNumber = IntExtensions.Reverse(X);
            //Console.WriteLine(ReversedNumber); // 54321

            //ReversedNumber = X.Reverse();
            //Console.WriteLine(ReversedNumber); // 54321

            #endregion

            #region Anonymous Type 

            ////Employee employee = new Employee() { Id = 10 , Name = "Ahmed" , Salary = 5000};

            //var employee = new { Id = 10 , Name = "Ahmed" , Salary = 5000};
            //Console.WriteLine(employee.Salary); // Valid

            //int X = 10;
            //Console.WriteLine(X.GetType().Name); // Int32
            //Console.WriteLine(employee.GetType().Name); // <>f__AnonymousType0`3

            ////employee.Name = "Mona"; // Invalid 
            ////// Object Created From Anonymous Type Is An Immutable Objects 

            //var emp01 = new {Id = employee.Id , Name = "Mona" ,Salary = employee.Salary}; // Till C# 9
            //Console.WriteLine(emp01);
            //Console.WriteLine(emp01.Name); // Mona
            //Console.WriteLine(emp01.GetType().Name); // <>f__AnonymousType0`3

            //var emp02 = employee with { Name = "Mona" }; // C# 10 Feature 
            //Console.WriteLine(emp02);
            //Console.WriteLine(emp02.Name); // Mona
            //Console.WriteLine(emp02.GetType().Name); // <>f__AnonymousType0`3

            //// The Same Anonymous Type As long As :
            //// 1. Same Properties Name [Case Sensitive]
            //// 2. Same Properties Order 

            //var emp03 = new { id = 10, Name = "Ahmed", Salary = 5000 };
            //Console.WriteLine(emp03);
            //Console.WriteLine(emp03.GetType().Name); // <>f__AnonymousType1`3

            //var emp04 = new {  Name = "Ahmed", Id = 10, Salary = 5000 };
            //Console.WriteLine(emp04);
            //Console.WriteLine(emp04.GetType().Name); // <>f__AnonymousType2`3

            //var emp05 = new { Name = "Ahmed", Id = 10 };
            //Console.WriteLine(emp05);
            //Console.WriteLine(emp05.GetType().Name); // <>f__AnonymousType3`2
            #endregion

            #region What Is LINQ 

            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var EvenNumbers = Numbers.Where(X => X % 2 == 0).ToList();

            //foreach (var EvenNumber in EvenNumbers)
            //	Console.WriteLine(EvenNumber); // 2 4 6 8 10


            #endregion

            #region LINQ Syntax 

            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            #region 1. Fluent Syntax - Method Syntax
            //// 1.2 Call LinQ Operators As Class Member Method 
            //var EvenNumbers = Enumerable.Where(Numbers, X => X % 2 == 0);

            //// 1.1 Call LinQ Operators As object Member Method [Extension Method - Recommended]
            //EvenNumbers = Numbers.Where(X => X % 2 == 0);
            #endregion


            #region 2.Query Syntax

            //// Started With From And Must Ended With "Select" Or "GroupBy"

            ///* Select *
            // * From Numbers N
            // * Where N % 2 == 0 */


            //EvenNumbers = from N in Numbers
            //			  where N % 2 == 0
            //			  select N;

            #endregion

            //foreach (int num in EvenNumbers)
            //	Console.WriteLine(num); // 2 4 6 8 10  

            #endregion

            #region Execution Ways 

            #region Deferred Execution
            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            //var EvenNumbers = Numbers.Where(X => X % 2 == 0); // Deferred Execution

            //Numbers.AddRange(11, 12, 13, 14, 15);

            //foreach (int num in EvenNumbers)
            //	Console.Write($"{num} "); // 2 4 6 8 10 12 14

            #endregion

            #region Immediate Execution

            //List<int> Numbers = new List<int>(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


            //var EvenNumbers = Numbers.Where(X => X % 2 == 0).ToList(); // Immediate Execution

            //Numbers.AddRange(11, 12, 13, 14, 15);

            //foreach (int num in EvenNumbers)
            //	Console.Write($"{num} "); // 2 4 6 8 10

            #endregion

            #endregion

            #region Setup Data 

            //Product? product =  ProductList?[0];
            //Console.WriteLine(product);
            //// ProductID:1,ProductName:Chai,CategoryBeverages,UnitPrice:18.00,UnitsInStock:100

            //Customer? customer = CustomerList?[0];
            //Console.WriteLine(customer);
            //// 212, Ahmed Ali, Obere Str. 57, Berlin, , 12209, Germany, 030-0074321, 030-0076545


            #endregion

            #region Filtration (Restriction) Operators [Where , TypeOf]

            #region Where 
            //var Result = ProductList?.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 20.0M);

            //Result = from P in ProductList
            //		 where P.UnitsInStock > 0 && P.UnitPrice > 20.0M
            //		 select P;


            // Result = ProductList?.Where((P, I) => I < 10 && P.ProductName?.Length <= 10);
            // //Search in the First 10 Elements only
            // // Get Products ProductName.Length <= 10 From First 10 Elements
            // // Indexed Where is Valid Only in Fluent Syntax, Can't Be Written Using Query Expression

            //foreach (var Item in Result ?? Enumerable.Empty<object>())
            //	Console.WriteLine(Item);

            #endregion

            #region TypeOf 

            //var Result = ProductList?.OfType<Product02>().Where(predicate: P => P.UnitPrice > 10);

            //foreach (var Item in Result ?? Enumerable.Empty<object>())
            //	Console.WriteLine(Item);

            ////ProductID:2000,ProductName:Product02,Category,UnitPrice:60,UnitsInStock:0
            ////ProductID:3000,ProductName:Product03,Category,UnitPrice:100,UnitsInStock:0
            ////ProductID:4000,ProductName:Product04,Category,UnitPrice:70,UnitsInStock:0




            //ArrayList fruits = new()
            //   {
            //  "Mango",
            //  "Orange",
            //  null,
            //  "Apple",
            //  3.0,
            //  "Banana",
            //  "LemoN"
            //};

            //var Result = fruits.OfType<string>().Where(S => S.Contains('n', StringComparison.OrdinalIgnoreCase));

            //foreach (var fruit in Result)
            //	Console.WriteLine(fruit);
            //// Mango
            //// Orange
            //// Banana
            //// LemoN



            #endregion

            #endregion

            #region Transformation (Projection) Operators [Select , Select Many , Zip]

            #region Select

            //var ProductNames = ProductList?.Select(P => P.ProductName);

            //ProductNames = from P in ProductList
            //			   select P.ProductName;

            //var Result01 = ProductList?.Select(P => new Product() { ProductID = P.ProductID, ProductName = P.ProductName });
            //// Rest Of Properties = Null

            //var Result02 = ProductList?.Select(P => new { P.ProductID, ProductName = P.ProductName });
            //// Object From Anonymous Type
            ////CLR Will Create Class In Runtime and Override To String


            //Result02 = from P in ProductList
            //		   select new
            //		   {
            //			   ProductID = P.ProductID,
            //			   ProductName = P.ProductName
            //		   };


            //var DiscountedList = ProductList?.Where(P => P.UnitsInStock > 0)
            //								.Select(P => new
            //								{
            //									Id = P.ProductID,
            //									Name = P.ProductName,
            //									NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)
            //								});

            //DiscountedList = from P in ProductList
            //				 where P.UnitsInStock > 0
            //				 select new
            //				 {
            //					 Id = P.ProductID,
            //					 Name = P.ProductName,
            //					 NewPrice = P.UnitPrice - (P.UnitPrice * 0.1M)
            //				 };


            //var Result = ProductList?.Where(P => P.UnitsInStock > 0)
            //						.Select((P, I) => new
            //						{
            //							Serial = I + 1,
            //							Name = P.ProductName
            //						});

            //foreach (var Item in Result ?? Enumerable.Empty<object>())
            //	Console.WriteLine(Item);

            #endregion

            #region Select Many

            //List<string> phrases = ["Route Academy", "Backend .Net Track", "Linq Course"];

            //var query = from phrase in phrases
            //			from word in phrase.Split(' ')
            //			select word;

            //query = phrases.SelectMany(P => P.Split(' '));

            //foreach (string s in query)
            //{
            //	Console.WriteLine(s);
            //}
            //         // Route
            //         // Academy
            //         // Backend
            //         // .Net
            //         // Track
            //         // Linq
            //         // Course


            //var CustomerOrders = CustomerList?.SelectMany(C => C.Orders);

            //CustomerOrders = from C in CustomerList
            //				 from O in C.Orders
            //				 select O;


            //foreach (var CustomerOrder in CustomerOrders)
            //	Console.WriteLine(CustomerOrder);
            ////// Order Id: 10643, Date: 8/25/1997, Total: 814.50
            ////// Order Id: 10692, Date: 10/3/1997, Total: 878.00
            ////// Order Id: 10702, Date: 10/13/1997, Total: 330.00
            ////// Order Id: 10835, Date: 1/15/1998, Total: 845.80


            //var CustomerOrders = CustomerList?.SelectMany(C => C.Orders,
            //	(Customer, Order) => (Customer.CustomerName, Order.OrderID));

            //CustomerOrders = from C in CustomerList
            //				 from O in C.Orders
            //				 select (C.CustomerName, O.OrderID);

            //foreach (var CustomerOrder in CustomerOrders)
            //	Console.WriteLine(CustomerOrder);
            ////(Ahmed Ali, 10643) 
            ////(Ahmed Ali, 10692) 
            ////(Ahmed Ali, 10702) 
            ////(Ahmed Ali, 10835) 
            ////(Ahmed Ali, 10952) 
            ////(Ahmed Ali, 11011)


            //var CustomerOrders02 = CustomerList?.SelectMany((C, Index) => C.Orders
            //.Select((O, I) => new { CustomerIndex = Index + 1, C.CustomerName, OrderIndex = I + 1, OrderId = O.OrderID }));


            //var Result = CustomerList?.SelectMany((C, CI) => C.Orders
            //.Select((O, OI) => new { CustomerIndex = CI + 1, CustomerName = C.CustomerName, OrderIndex = OI + 1, OrderId = O.OrderID }));

            //foreach (var CustomerOrder in CustomerOrders02 ?? Enumerable.Empty<object>())
            //	Console.WriteLine(CustomerOrder);

            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 0, OrderId = 10643 }
            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 1, OrderId = 10692 }
            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 2, OrderId = 10702 }
            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 3, OrderId = 10835 }
            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 4, OrderId = 10952 }
            //// { CustomerIndex = 0, CustomerName = Ahmed Ali, OrderIndex = 5, OrderId = 11011 }


            #endregion

            #region Zip 

            //List<int> numbers = [1, 2, 3, 4, 5, 6, 7];
            //char[] letters = ['A', 'B', 'C', 'D', 'E', 'F'];
            //string[] Words = ["First", "Second", "Third", "Fourth", "Fifth"];


            //var Result = numbers.Zip(letters, (N, L) => $"Number {N} is Zipped With Letter {L}");

            //foreach (var item in Result)
            //	Console.WriteLine(item);
            //////// Number 1 is Zipped With Letter A
            //////// Number 2 is Zipped With Letter B
            //////// Number 3 is Zipped With Letter C
            //////// Number 4 is Zipped With Letter D
            //////// Number 5 is Zipped With Letter E
            //////// Number 6 is Zipped With Letter F

            //var Result02 = numbers.Zip(letters, Words);
            //foreach (var item in Result02)
            //	Console.WriteLine(item);
            //// (1, A, First)
            //// (2, B, Second)
            //// (3, C, Third)
            //// (4, D, Fourth)
            //// (5, E, Fifth)

            #endregion

            #endregion

            #region Sorting (Ordering) Operators

            ////var Result = CustomerList?.Order();
            //var Result = CustomerList?.OrderByDescending(C => C.CustomerName);


            //Result = from C in (CustomerList ?? Enumerable.Empty<Customer>())
            //		 orderby C.CustomerName descending
            //		 select C;


            //foreach (var item in Result ?? Enumerable.Empty<object>())
            //	Console.WriteLine(item);


            //var Result = ProductList?.OrderBy(p => p.UnitsInStock).ThenByDescending(P => P.UnitPrice);

            //Result = from p in (ProductList ?? Enumerable.Empty<Product>())
            //		 orderby p.UnitsInStock, p.UnitPrice descending
            //		 select p;


            //foreach (var item in Result ?? Enumerable.Empty<Product>())
            //	Console.WriteLine(item);


            //var Result01 = ProductList?.Where(C => C.ProductName?.Length < 10).Select(C => C.ProductName).Reverse();


            //foreach (var item in Result01 ?? Enumerable.Empty<string>())
            //	Console.WriteLine(item);



            //var Result02 = ProductList?.Where(C => C.ProductName?.Length < 10)
            //							.Select(C => C.ProductName)
            //							.OrderBy(S => S?.Length);

            //foreach (var item in Result02 ?? Enumerable.Empty<string?>())
            //	Console.WriteLine(item);


            #endregion
            //..
        }
    }
}
