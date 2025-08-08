using LINQ01;

namespace LINQ02;
internal class Program
{
    public static void Main(string[] args)

    {
        #region Element operators

        #region Question1
        var firstOutOfStock = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
        firstOutOfStock.Print();
        #endregion

        #region Question2
        var firstPrice = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
        firstPrice.Print();
        #endregion

        #region Question3
        var numbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var secondGreaterThanFive = numbers.Where(n => n > 5).Skip(1).FirstOrDefault();
        secondGreaterThanFive.Print();
        #endregion

        #endregion

        #region Aggregate Operators

        #region Question1
        var oddNumbers = new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        var oddCount = oddNumbers.Count(n => n % 2 != 0);
        oddCount.Print();
        #endregion

        #region Question2
        var customerOrder = ListGenerators.CustomerList
    .Select(c => new { CustomerName = c.CustomerName, OrderCount = c.Orders.Length });
        customerOrder.Print();
        #endregion

        #region Question3
        var categoryProduct = ListGenerators.ProductList
    .GroupBy(p => p.Category)
    .Select(g => new { Category = g.Key, ProductCount = g.Count() });
        categoryProduct.Print();
        #endregion

        #region Question4

        #endregion

        #region Question5

        #endregion

        #region Question6

        #endregion

        #region Question7

        #endregion

        #region Question8

        #endregion

        #region Question9

        #endregion

        #region Question10

        #endregion

        #region Question11

        #endregion

        #region Question12

        #endregion

        #region Question13

        #endregion

        #region Question14

        #endregion
        #endregion
    }
}