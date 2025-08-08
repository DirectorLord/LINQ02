using LINQ01;

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
        var words = new string[] {"a", "b", "c", "d"};
        var totalWords = words.Sum( w => w.Length );
        totalWords.Print();
        //??
        #endregion

        #region Question6
        //Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var shortWords = new string[] {"ali", "ahmed", "mona", "abdulallah"};
        var shortestLength = shortWords.Min(w => w.Length);
        shortestLength.Print();
        #endregion

        #region Question7
        //Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var longWords = new string[] { "ali", "ahmed", "mona", "abdulallah" };
        var longestLength = longWords.Min(w => w.Length);
        longestLength.Print();
        #endregion

        #region Question8
        //Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
        var avgWords = new string[] { "ali", "ahmed", "mona", "abdulallah" };
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

        #endregion
    }
}