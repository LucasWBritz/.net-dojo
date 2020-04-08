using System;
using System.Collections.Generic;

namespace MethodChaining
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myNumberCollection = new List<int>()
            {
                1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10 
            };

            var filteredNumbers = new FilterChain(myNumberCollection)
                                        .RemoveValue(1)
                                        .RemoveDuplicated()
                                        .RemoveEven()
                                        .GetNumbers();
                                        
            foreach(var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
