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
    /// Demo is a Class
    /// "T:Asyncandawait.Demo"
    /// </summary>
    public class Demo
    {
        /// <summary>
        /// IsComplete is boolean Property
        /// "P:Asyncandawait.Demo.IsComplete"
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// DoWorkAsync is Method
        /// "M:Asyncandawait.Demo.DoWorkAsync()"
        /// </summary>
        public async void DoWorkAsync()
        {
            this.IsComplete = false;
            Console.WriteLine("WelCome");

            await Task.WhenAll(LongOperation(), LongOperation1(), LongOperation2());
          
            Console.WriteLine("\nGood Bye");

            IsComplete = true;
        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Demo.LongOperation()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(5000);
                Console.WriteLine("First");
            });
        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Demo.LongOperation1()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation1()
        {
            return Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(1000);
                Console.WriteLine("Second");
            });

        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Demo.LongOperation2()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation2()
        {

            return Task.Factory.StartNew(() =>
            {
                
                Thread.Sleep(3000);
                Console.WriteLine("Third");
            });

        }
    }

    /// <summary>
    /// AsyncAwait2 is a Class
    /// "T:Asyncandawait.AsyncAwait2"
    /// </summary>
    class AsyncAwait2
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AsyncAwait2));

        /// <summary>
        /// Main Method
        /// "M:Asyncandawait.AsyncAwait2.Main(System.string[])"
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("Begin");

            var demo = new Demo();
            demo.DoWorkAsync();

            while (!demo.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            log.Info("End");
            Console.Read();
        }
    }
}
