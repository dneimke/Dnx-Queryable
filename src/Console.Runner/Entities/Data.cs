using System.Collections.Generic;
using System.Linq;

namespace Console.Runner.Entities
{
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public static Data Create(int id = 1, string name = "A")
        {
            return new Data { Id = id, Name = name };
        }

        public static IQueryable<Data> CreateOrderedCollection(int id = 1, string name = "A")
        {
            return Queryable.AsQueryable(new List<Data>
            {
                Create(),
                Create(2, "B"),
                Create(3, "C"),
                Create(4, "D"),
                Create(5, "E"),
                Create(6, "F")
            });
        }


        public static IQueryable<Data> CreateUnorderedCollection(int id = 1, string name = "A")
        {
            return Queryable.AsQueryable(new List<Data>
            {
                Create(),
                Create(4, "D"),
                Create(2, "B"),
                Create(5, "E"),
                Create(3, "C"),
                Create(6, "F")
            });
        }
    }
}
