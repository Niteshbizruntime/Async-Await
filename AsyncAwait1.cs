using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Config;

namespace Asyncandawait
{
    /// <summary>
    /// Worker is a Class
    /// "T:Asyncandawait.Worker"
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// IsComplete is boolean Property
        /// "P:Asyncandawait.Worker.IsComplete"
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// DoWorkAsync is Method
        /// "M:Asyncandawait.Worker.DoWorkAsync()"
        /// </summary>
        public async void DoWorkAsync()
        {
            this.IsComplete = false;
            Console.WriteLine("WelCome");

            await LongOperation();
            Console.WriteLine("\nBye");

            IsComplete = true;
        }

        /// <summary>
        /// LongOperation is Method
        /// "M:Asyncandawait.Worker.LongOperation()"
        /// </summary>
        /// <returns>return task</returns>
        private static Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(2000);
                Console.WriteLine("Nice");
            });
        }
    }

    /// <summary>
    ///  AsyncAwait1 is a Class
    /// "T:Asyncandawait.AsyncAwait1"
    /// </summary>
    class AsyncAwait1
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AsyncAwait1));

        /// <summary>
        /// Main Method
        /// "M:Asyncandawait.AsyncAwait1.Main(System.string[])"
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("Begin");

            var worker = new Worker();
            worker.DoWorkAsync();

            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            log.Info("End");
            Console.Read();
        }
    }
}
