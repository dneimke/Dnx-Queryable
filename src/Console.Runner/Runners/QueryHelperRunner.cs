using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Console.Runner.Entities;
using Parliament.Common;

namespace Console.Runner.Runners
{
    public class QueryHelperRunner
    {
        public void Run()
        {
            ShouldFindProperty();
            ShouldNotFindProperty();
            ShouldCreateValidPropertyExpression();
        }


        public void ShouldFindProperty()
        {
            var data = Data.Create();
            var result = QueryHelper.PropertyExists<Data>("Name");

            // System.Console.WriteLine("Result: result = ", result);

            if (result != true)
                throw new Exception("Property was not found");
        }

        public void ShouldNotFindProperty()
        {
            var data = Data.Create();
            var result = QueryHelper.PropertyExists<Data>("X");

            // System.Console.WriteLine("Result: result = ", result);

            if (result != false)
                throw new Exception("Property was found");
        }

        public void ShouldCreateValidPropertyExpression()
        {
            var data = Data.CreateUnorderedCollection();
            var propertyExpression = QueryHelper.GetPropertyExpression<Data>("Name");

            var item = data.OrderBy(propertyExpression).Skip(3).Take(1).Single();

            // System.Console.WriteLine("Result: Id = {0}", item.Id);

            if (item.Id != 4)
                throw new Exception("Sort did not work");

        }

    }
}
