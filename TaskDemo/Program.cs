using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task<int>.Run<int>(() =>
            {
                Console.WriteLine("task线程启动");
                return 1;
            });
            //Console.WriteLine(t.Result);
            //Console.WriteLine(t.IsCompleted);
            //ContinueWith（）让该后台线程继续执行新的任务
            Task<string> t2=t.ContinueWith<string>(c =>
            {
                return "hello";
            });
            //做到异步回调
            t.GetAwaiter().OnCompleted(() => {
                Console.WriteLine(t.Result+" word");
                Console.WriteLine(t2.Result+" word");
            });
            
            Console.ReadKey();
        }
    }
}
