using System;

namespace EcommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Laptop", "Electronics"),
                new Product(102, "Mobile", "Electronics"),
                new Product(103, "Shoes", "Fashion"),
                new Product(104, "Watch", "Accessories"),
                new Product(105, "Book", "Education")
            };

            int targetId = 104;

            Product linearResult = SearchAlgorithms.LinearSearch(products, targetId);

            if (linearResult != null)
            {
                Console.WriteLine("Linear Search Found:");
                Console.WriteLine(linearResult.ProductName);
            }

            Product binaryResult = SearchAlgorithms.BinarySearch(products, targetId);

            if (binaryResult != null)
            {
                Console.WriteLine("Binary Search Found:");
                Console.WriteLine(binaryResult.ProductName);
            }
        }
    }
}