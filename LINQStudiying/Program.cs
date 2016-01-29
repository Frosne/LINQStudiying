using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQStudiying
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleOne();
            System.Console.Read();
        }

        public static void ExampleOne()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var quesry = from num in list
                         where num > 4
                         select num;
            foreach (var elem in quesry)
                System.Console.WriteLine(elem);
        }
        public static void ExampleTwo()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            IEnumerable<int> quesry = from num in list
                                      where num > 4
                                      select num;

            foreach (var elem in quesry)
                System.Console.WriteLine(elem);
        }
        public static void ExampleThree()
        {
            List<int> lst = new List<int>(){1,2,3};
            List<int>.Enumerator e = lst.GetEnumerator();

            while (e.MoveNext())
            {
                System.Console.WriteLine(e.Current);
            }
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
}
