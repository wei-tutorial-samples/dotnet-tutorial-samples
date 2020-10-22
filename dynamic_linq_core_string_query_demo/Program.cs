using System.Linq;
using System;
using System.Linq.Dynamic.Core;

namespace dynamic_linq_core_string_query_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = Enumerable.Range(1,20).Select(s=>new{id=s,val=Guid.NewGuid()});
            {
                System.Console.WriteLine("where string query with parameter");
                var r = d.AsQueryable().Where("id >= @0 && id <= @1",10,15);
                foreach (var item in r)
                {
                    System.Console.WriteLine(item);
                }
            }
            {
                System.Console.WriteLine("select string query");
                var r = d.AsQueryable().Where("id >= @0 && id <= @1",10,15).Select("val");
                foreach (var item in r)
                {
                    System.Console.WriteLine(item);
                }
            }  
            {
                System.Console.WriteLine("select string query new object with function");
                var r = d.AsQueryable().Where("id >= @0 && id <= @1",10,15).Select("new {val,val.ToString().Replace(\"-\",\"\") as newVal}");
                foreach (var item in r)
                {
                    System.Console.WriteLine(item);
                }
            }                          
        }
    }
}
