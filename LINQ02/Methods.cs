using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ01;

internal static class Methods
{
    public static void Print(this object obj)
    {
        Console.WriteLine(obj);
    }
    public static void Print<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
