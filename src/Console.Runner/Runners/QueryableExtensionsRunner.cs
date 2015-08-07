using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console.Runner.Entities;
using Parliament.Common;

namespace Console.Runner.Runners
{
    public class QueryableExtensionsRunner
    {
        public void Run()
        {
            ShouldSortStrings();
        }


        public void ShouldSortStrings()
        {
            var data = Data.CreateOrderedCollection();


            var result = data.SetOrder("Name", true).ToArray();
            var foo = result.FirstOrDefault();          
            
        }


        public void ShouldNotBeCaseSensitive()
        {
            // TODO 
        }
    }
}
