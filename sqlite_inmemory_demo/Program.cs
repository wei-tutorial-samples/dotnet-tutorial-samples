using System;
using System.Data.SQLite;
using Dapper;

namespace sqlite_inmemory_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var cn = new SQLiteConnection("Data Source=:memory:"))
            {
                cn.Open();
                // query
                {
                    var r = cn.QueryFirst("select 'Hello World'");
                    System.Console.WriteLine(r);
                }

                // create / insert 
                {
                    cn.Execute("create table t (id int,val varchar(20))");
                    for (int i = 0; i < 10; i++)
                    {
                        cn.Execute("insert into t (id,val) values (@id,@val)",new{id=i,val=Guid.NewGuid().ToString("D")});                        
                    }
                    var r = cn.Query("select * from t");
                    foreach (var item in r)
                    {
                        System.Console.WriteLine(item);
                    }
                }
            }
        }
    }
}
