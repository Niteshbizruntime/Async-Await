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
    /// Process is a Class
    /// "T:Asyncandawait.Process"
    /// </summary>
    public class Process
    {
        /// <summary>
        /// IsComplete is boolean Property
        /// "P:Asyncandawait.Process.IsComplete"
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        ///  DoWorkAsync is Method
        /// "M:Asyncandawait.Process.DoWorkAsync()"
        /// </summary>
        public async void DoWorkAsync()
        {
            this.IsComplete = false;
            Console.WriteLine("Good");

            LongOperation();
            Console.WriteLine("\nBad");

            IsComplete = true;
        }
        /// <summary>
        /// LongOperation is Method
        /// "M:Asyncandawait.Process.LongOperation()"
        /// </summary>
        /// <returns>return task</returns>
        private void LongOperation()
        {
            
                Console.WriteLine("Nice");
                Thread.Sleep(2000);
       
        }
    }

    /// <summary>
    /// AsyncAwait is a Class
    /// "T:Asyncandawait.AsyncAwait"
    /// </summary>
    class AsyncAwait
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AsyncAwait));

        /// <summary>
        /// Main Method
        /// "M:Asyncandawait.AsyncAwait.Main(System.string[])"
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("Begin");

            var process = new Process();
            process.DoWorkAsync();

            while (!process.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            log.Info("End");
            Console.Read();
        }
    }
}
