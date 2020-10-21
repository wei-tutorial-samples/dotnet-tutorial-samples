using System;
using System.Data.SQLite;
using Dapper;
using Newtonsoft.Json;

namespace sqlite_inmemory_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var cn = new SQLiteConnection("Data Source=:memory:"))
            {
                // query
                {
                    var r = cn.QueryFirst("select 'Hello World'");
                    System.Console.WriteLine(r);
                }

                // create / insert 
                {
                    cn.Open();
                    cn.Execute(@"create table T (ID int,Val varchar(20))");
                    for (int i = 0; i < 10; i++)
                    {
                        cn.Execute("insert into T (ID,Val) values (@ID,@Val)",new{ID=i,Val=Guid.NewGuid().ToString("D")});                        
                    }
                    var r = cn.Query("select * from T");
                    System.Console.WriteLine( JsonConvert.SerializeObject(r,Formatting.Indented) );
                }
            }
        }
    }
}
