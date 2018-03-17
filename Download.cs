using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;
using log4net;
namespace Asyncandawait
{
   

    
    /// <summary>
    /// AsyncAwait is a Main Class it Contain Main Method
    /// "T:Asyncandawait.Download"
    /// </summary>
    class Download
    {

        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Download));
        /// <summary>
        /// BigProcessAsync is a async method
        /// "M:Asyncandawait.Download.BigProcessAsync()"
        /// </summary>
        public async void BigProcessAsync()
        {
            Console.WriteLine("-----------Wait-----------");
            Task[] task = new Task[] { Process1(), Process2() };
            await Task.WhenAll(task);
            Console.WriteLine("-----------Complete-----------");
        }

        /// <summary>
        /// Process1 is a async method, return task
        ///  "M:Asyncandawait.Download.Process1()"
        /// </summary>
        /// <returns></returns>
        private async Task Process1()
        {
            await Task.Run(() => {
                int i;
                for ( i = 1; i <= 100; i=i+10)
                {
                    Console.WriteLine("\nFile 1");
                    Console.WriteLine("{0}% Download ",i);
                    Thread.Sleep(200);

                }
                Console.WriteLine("\nFile 1");
                Console.WriteLine("{0}% Download ", i-1);
                log.Info("File 1 Download Complete");
            });
        }

        /// <summary>
        /// Process2 is Async method ,return task
        ///  "M:Asyncandawait.Download.Process2()"
        /// </summary>
        /// <returns></returns>
        private async Task Process2()
        {
            await Task.Run(() => {
                for (int i = 0; i <= 100; i=i+10)
                {
                    
                    Console.WriteLine("\nFile 2");
                    Console.WriteLine("{0}% Download ",i);
                    i = i + 10;
                    Thread.Sleep(400);

                }
                log.Info("File 2 Download Complete");
            });
        }

        /// <summary>
        /// Main is a method, It is the entry point of program
        ///  "M:Asyncandawait.Download.Main(system.string[])"
        /// </summary>
        /// <param name="args">it is a string Array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            new Download().BigProcessAsync();
            Console.Read();
        }
    }
}
