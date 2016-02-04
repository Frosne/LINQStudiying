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
            ExampleTwelwe();
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
            List<int> lst = new List<int>() { 1, 2, 3 };
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
        public static void ExampleSixCreatingXMLWithLINQ()
        {
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Objects",
                    new XElement("Person",
                        new XAttribute("Property1", "value"),
                        new XAttribute("Property2", "value")
                        ),
                        new XElement("Person",
                            new XAttribute("Property1", "value1"),
                            new XAttribute("Property3", "value")
                            )
                        )
                        );

            System.Console.WriteLine(xdoc.Declaration);
            System.Console.Write(xdoc);
            xdoc.Save(@"test.xml");






        }
        /// <summary>
        /// Returns the MethodInfo[] (array)
        /// </summary>
        public static void ExampleSevenStringStatic()
        {
            var query = from m in typeof(string).GetMethods()
                        where m.IsSecurityCritical
                        select m;

         
        }
        public static void ExampleEightMethod()
        {
            var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path2 =  AppDomain.CurrentDomain.BaseDirectory;
            ExampleEight.Test();
            ExampleEight.Test2();
        }
        public static void ExampleNineMethod()
        {
            ExampleNine ex = new ExampleNine();
            
        }
        public static void ExampleTen()
        {
            HashSet<int> hs = new HashSet<int> { 1, 2, 3, 4 };
            if (hs.Add(1))
                System.Console.WriteLine("The same value added");
            else
                System.Console.WriteLine("The struucture is designed such way not to have the same element");

            hs.Clear();

            List<int> lst = new List<int>();
            Random rnd = new Random();
            System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
            st.Start();
            for (int i = 0; i < 10000000; i++)
                lst.Add(i);
            st.Stop();
            var memory = st.ElapsedTicks;
            System.Console.WriteLine("For list putting the 100000000 values took {0} ticks", st.ElapsedTicks);

            st.Restart();
            for (int i = 0; i < 10000000; i++)
                hs.Add(i);
            st.Stop();
            System.Console.WriteLine("For hashset putting the 100000000 values took {0} ticks {1} percents", st.ElapsedTicks, memory > st.ElapsedTicks ? (st.ElapsedTicks / memory) : (st.ElapsedTicks / memory)*-1);

            lst.Clear();
            hs.Clear();
            st.Restart();
            for (int i = 0; i < 10000000; i++)
                lst.Add(rnd.Next(int.MaxValue));
            st.Stop();
            memory = st.ElapsedTicks;
            System.Console.WriteLine("For list putting the 100000000 random values took {0} ticks and size {1}", st.ElapsedTicks, lst.Count);

            st.Restart();
            for (int i = 0; i < 10000000; i++)
                hs.Add(rnd.Next(int.MaxValue));
            st.Stop();
            System.Console.WriteLine("For hashset putting the 100000000 random values took {0} ticks and size {1} in percent {2} time, in percent space {3}", st.ElapsedTicks, hs.Count, memory > st.ElapsedTicks ? (st.ElapsedTicks / memory) : (st.ElapsedTicks / memory) * -1, lst.Count > hs.Count ? (lst.Count / hs.Count) : (lst.Count / hs.Count) * -1);

            //Stack dont have an Add method
            //Stack<int> st = new Stack<int> { 1, 2, 3 };

            System.Console.Read();
        }
        public static void ExampleEleven()
        {
            var anontype = new { IntegerVar = 1, StringVar = "cat" };
            System.Console.WriteLine(anontype.GetType());
            var anontype2 = new { IntegerVar = 1, StringVar = "cat" };
            System.Console.WriteLine("{0}\n{1}",anontype2.GetType(),anontype.GetType().ToString() == anontype2.GetType().ToString());
            
            

        }
        public static void ExampleTwelwe()
        {
            DelegateExample.DelegateTest();
        }
        

   }
    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
    public static partial class ExampleEight
    {
        public static void Test()
        {
            System.Console.WriteLine("meow");
        }
    }
    public static partial class ExampleEight
    {
        public static void Test2()
        {
            System.Console.WriteLine("Meow2");
        }
    }
    public partial class ExampleNine {
      
      partial void Method();

      public void Test()
      {
          Method();
      }

        
    }
    public partial class ExampleNine
    {
        partial void Method()
        {
            System.Console.WriteLine("Hello World");
        }
    }
    public static class DelegateExample
    {
        public delegate int Delegate(int a, int b);
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static void CallDelegate(Delegate d)
        {
            System.Console.WriteLine(d(1, 2));
        }

        public static void DelegateTest()
        {
            Delegate d = Add;
            CallDelegate(d);
            System.Console.WriteLine(d(0, 0));
        }
    }


}
