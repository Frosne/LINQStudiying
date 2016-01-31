using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQStudiying
{
    class Program
    {
        static void Main(string[] args)
        {
           
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
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{ City = "", ContactName="", CustomerID = ""},
                new Customer{CustomerID="", ContactName="", City = ""}
            };
        }
        public static void ExampleFour()
        {
            var query = from c in GetCustomers()
                        where c.City == ""
                        select new { City = c.City, ContactName = c.ContactName };
            foreach (var elem in query)
                System.Console.WriteLine(elem);


        }
        public static void ExampleFiveUsingXMLWithLINQ()
        {
            XDocument xdoc = XDocument.Load(@"D:\Alt\Professional.xml");
            var xml = from x in xdoc.Descendants("component")
                      where x.Attribute("processorArchitecture").Value == "x86"
                      select x.Attribute("name");
            foreach (var elem in xml)
                System.Console.WriteLine(elem);
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
}
