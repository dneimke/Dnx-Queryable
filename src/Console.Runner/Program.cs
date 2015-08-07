using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console.Runner.Runners;

namespace Console.Runner
{
    public class Program
    {
        public void Main(string[] args)
        {
            var runner1 = new QueryHelperRunner();
            var runner2 = new QueryableExtensionsRunner();

            runner1.Run();
            runner2.Run();

            // System.Console.ReadKey();
        }
    }
}
