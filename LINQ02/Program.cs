using LINQ01;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LINQ02;
internal class Program
{
    public static void Main(string[] args)

    {
        #region Element operators

        #region Question1
        //Get first Product out of Stock 
        var firstOutOfStock = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
        firstOutOfStock.Print();
        #endregion

        #region Question2
        //Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
        var firstPrice = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
        firstPrice.Print();
        #endregion

        #region Question3
        //Retrieve the second number greater than 5 
        var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var secondGreaterThanFive = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
        secondGreaterThanFive.Print();
        #endregion

        #endregion

        #region Aggregate Operators

        #region Question1
        //Uses Count to get the number of odd numbers in the array
        var oddNumbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var oddCount = oddNumbers.Count(n => n % 2 != 0);
        oddCount.Print();
        #endregion

        #region Question2
        //Return a list of customers and how many orders each has.
        var customerOrder = ListGenerators.CustomerList
    .Select(c => new { CustomerName = c.CustomerName, OrderCount = c.Orders.Length });
        customerOrder.Print();
        #endregion

        #region Question3
        //Return a list of categories and how many products each has
        var categoryProduct = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, ProductCount = g.Count() });
        categoryProduct.Print();
        #endregion

        #region Question4
        //Get the total of the numbers in an array.
        var counts = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var total = counts.Sum();
        total.Print();
        #endregion

        #region Question5
        //Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var words = new string[] { "wipeouts", "woodmanship", "wrothsome", "zygaenid" };
        var totalWords = words.Sum( w => w.Length );
        totalWords.Print();
        //??
        #endregion

        #region Question6
        //Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var shortWords = new string[] { "whipstock", "wealthiest", "voluminously", "vetivene" };
        var shortestLength = shortWords.Min(w => w.Length);
        shortestLength.Print();
        #endregion

        #region Question7
        //Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var longWords = new string[] { "valuelessness", "uptears", "upbrow", "uptemper" };
        var longestLength = longWords.Min(w => w.Length);
        longestLength.Print();
        #endregion

        #region Question8
        //Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var avgWords = new string[] { "unsuppliable", "unslakeable", "unreworded", "unprognosticated" };
        var avgestLength = avgWords.Min(w => w.Length);
        avgestLength.Print();
        #endregion

        #region Question9
        //Get the total units in stock for each product category.
        var categoryTotals = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
        categoryTotals.Print();
        #endregion

        #region Question10
        //Get the cheapest price among each category's products
        var cheapestPrice = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
        cheapestPrice.Print();
        #endregion

        #region Question11
        //Get the products with the cheapest price in each category (Use Let)???????
        var cheapestProducts = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new
    {
        Category = g.Key,
        CheapestPrice = g.Min(p => p.UnitPrice),
        Products = g.Where(p => p.UnitPrice == g.Min(p => p.UnitPrice))
    });
        #endregion

        #region Question12
        //Get the most expensive price among each category's products.
        var mostExpensive = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });
        mostExpensive.Print();
        #endregion

        #region Question13
        //Get the products with the most expensive price in each category.
        var mostExpensiveProducts = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new
    {
        Category = g.Key,
        MostExpensivePrice = g.Max(p => p.UnitPrice),
        Products = g.Where(p => p.UnitPrice == g.Max(p => p.UnitPrice))
    });
        mostExpensiveProducts.Print();
        #endregion

        #region Question14
        //Get the average price of each category's products.
        var averagePrices = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });
        averagePrices.Print();
        #endregion
        #endregion

        #region Set operators

        #region Question1
        //Find the unique Category names from Product List
        var uniqueCategories = ListGenerators.ProductList.Select(p => p.Category).Distinct();
        uniqueCategories.Print();
        #endregion

        #region Question2
        //Produce a Sequence containing the unique first letter from both product and customer names.
        var productFirstLetters = ListGenerators.ProductList.Select(p => p.ProductName[0]);
        var customerFirstLetters = ListGenerators.CustomerList.Select(c => c.CustomerName[0]);
        var uniqueFirstLetters = productFirstLetters.Concat(customerFirstLetters).Distinct();
        productFirstLetters.Print();
        customerFirstLetters.Print();
        uniqueFirstLetters.Print();
        #endregion

        #region Question3
        //Create one sequence that contains the common first letter from both product and customer names.
        var productLetters = ListGenerators.ProductList.Select(p => p.ProductName[0]);
        var customerLetters = ListGenerators.CustomerList.Select(c => c.CustomerName[0]);
        var commonFirstLetters = productLetters.Intersect(customerFirstLetters);

        commonFirstLetters.Print();
        #endregion

        #region Question4
        //Create one sequence that contains the first letters of product names that are not also first letters of customer names.
        var productFirstLetter = ListGenerators.ProductList.Select(p => p.ProductName[0]);
        var customerFirstLetter = ListGenerators.CustomerList.Select(c => c.CustomerName[0]);
        var uniqueProductFirstLetters = productFirstLetter.Except(customerFirstLetters);

        uniqueProductFirstLetters.Print();
        #endregion

        #region Question5
        //Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

        var productLastThree = ListGenerators.ProductList.Select(p => p.ProductName.Length >= 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName);
        var customerLastThree = ListGenerators.CustomerList.Select(c => c.CustomerName.Length >= 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName);
        var allLastThree = productLastThree.Concat(customerLastThree);

        allLastThree.Print();
        #endregion
        #endregion

        #region Partition operators

        #region Question1
        //Get the first 3 orders from customers in Washington
        var washingtonOrders = ListGenerators.CustomerList
    .Where(c => c.Region == "WA")
    .SelectMany(c => c.Orders)
    .Take(3);

        washingtonOrders.Print();
        #endregion

        #region Question2
        //Get all but the first 2 orders from customers in Washington.

        var firstTwoWashingtonOrders = ListGenerators.CustomerList
    .Where(c => c.Region == "WA")
    .SelectMany(c => c.Orders)
    .Skip(2);

        firstTwoWashingtonOrders.Print();
        #endregion

        #region Question3
        //Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
        var arr = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var result = arr.TakeWhile((n, i) => n >= i);

        result.Print();
        #endregion

        #region Question4
        //Get the elements of the array starting from the first element divisible by 3.
        var division = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var divisionResult = division.SkipWhile(n => n % 3 != 0).Skip(1);

        divisionResult.Print();
        #endregion

        #region Question5
        //Get the elements of the array starting from the first element less than its position.
        var pos = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var posResult = pos.SkipWhile((n, i) => n >= i).Skip(1);

        posResult.Print();
        #endregion
        #endregion

        #region Quantifiers

        #region Question1
        //Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.????
        var containWords = new string[] { "unsuppliable", "unslakeable", "unreworded", "unprognosticated" };
        var hasEi = containWords.Any(w => w.Contains("ei"));

        hasEi.Print();
        #endregion

        #region Question2
        //Return a grouped a list of products only for categories that have at least one product that is out of stock.

        var outOfStockCategories = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Where(g => g.Any(p => p.UnitsInStock == 0))
    .Select(g => new { Category = g.Key, Products = g });

        outOfStockCategories.Print();
        #endregion

        #region Question3
        //Return a grouped a list of products only for categories that have all of their products in stock.
        var allInStockCategories = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Where(g => g.All(p => p.UnitsInStock > 0))
    .Select(g => new { Category = g.Key, Products = g });

        allInStockCategories.Print();
        #endregion
        #endregion

        #region Grouping operators

        #region Question1
        //Use group by to partition a list of numbers by their remainder when divided by 5
        var groupNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        var groupedRemainder = groupNumbers.GroupBy(n => n % 5);

        groupedRemainder.Print();
        #endregion

        #region Question2
        //Uses group by to partition a list of words by their first letter.
        //Use dictionary_english.txt for Input
        var englishPls = new[] { "unoratorically", "unmistakably", "uniprocessor", "unhuddling"};
        var groupedByFirstLetter = englishPls.GroupBy(w => w[0]);

        groupedByFirstLetter.Print();
        #endregion

        #region Question3
        //3.	Consider this Array as an Input
        var compare = new[] { "from", "salt", "last", "earn", "near", "form" };
        var comparer = new CustomCharComparer();
        //var groupedByChars = compare.GroupBy(w => new string(w.OrderBy(c => c);
        //????

        #endregion

        #endregion

        #region Transformation operators

        #region Question1
        //Return a sequence of just the names of a list of products.
        var justProductNames = ListGenerators.ProductList.Select(p => p.ProductName);

        justProductNames.Print();
        #endregion

        #region Question2
        //Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
        var strange = new[] { "aPPLE", "BlUeBeRrY", "cHeRry" };
        var caseVersions = strange.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });

        caseVersions.Print();
        #endregion

        #region Question3
        //Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

        var productDetails = ListGenerators.ProductList.Select(p => new { p.ProductName, Price = p.UnitPrice, p.UnitsInStock });

        productDetails.Print();
        #endregion

        #region Question4
        var yarrs = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var matchesPosition = yarrs.Select((n, i) => new { Number = n, InPlace = n == i });

        matchesPosition.Print();
        #endregion
        #endregion
    }
}
public class CustomCharComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode([DisallowNull] string obj)
    {
        throw new NotImplementedException();
    }
}