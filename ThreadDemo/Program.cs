using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ThreadDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SemaphoreSlim:负责协调线程，限制资源被访问的线程数量
            Console.WriteLine("启动");


            Thread t = new Thread(c =>
            {
                using (FileStream fs = new FileStream(@"D:\我的mvc\C#异步\Synccallback\ThredDemo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {

                    using (StreamWriter stw = new StreamWriter(fs))
                    {
                        //Console.WriteLine("t线程启动");
                        stw.WriteLine("t线程启动");
                        //Thread.Sleep(10000);
                        for (int i = 0; i <= 100; i++)
                        {
                            stw.WriteLine(i);
                            //Console.WriteLine(i);
                        }

                    }
                }
            }) { IsBackground = true };
            t.Start();
            Thread.Sleep(5000);
            Console.WriteLine("结束");
        }
    }
}
