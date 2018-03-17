using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asyncandawait
{
    /// <summary>
    /// Operation is a Class
    /// "T:Asyncandawait.Operation"
   /// </summary>
    public class Operation
    {
        /// <summary>
        /// IsComplete is boolean Property
        /// "P:Asyncandawait.Operation.IsComplete"
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// DoWorkAsync is Method
        /// "M:Asyncandawait.Operation.DoWorkAsync()"
        /// </summary>
        public async void DoWorkAsync()
        {
            this.IsComplete = false;
            Console.WriteLine("Welcome");
            Task[] tasks = new[] { LongOperation(), LongOperation1() };
            await Task.WhenAny(tasks);
            Console.WriteLine("\nGood Bye");
            IsComplete = true;
        }

        /// <summary>
        /// LongOperation is Method
        /// "M:Asyncandawait.Operation.LongOperation()"
        /// </summary>
        /// <returns>return task</returns>
        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Bad Performance");
               
            });
        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Operation.LongOperation1()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation1()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Good Performance");
                
            });

        }

    }

    /// <summary>
    ///  AsyncAwait4 is a Class
    /// "T:Asyncandawait.AsyncAwait4"
    /// </summary>
    class AsyncAwait4
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Download));

        /// <summary>
        /// Main Method
        /// "M:Asyncandawait.AsyncAwait4.Main(System.string[])"
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("Begin");

            var operation = new Operation();
            operation.DoWorkAsync();

            while (!operation.IsComplete)
            {
                Console.Write("Hi");
                Thread.Sleep(100);
            }

            log.Info("End");
            Console.Read();
        }
    }
}
