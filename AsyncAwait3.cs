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
    /// Hello is a Class
    /// "T:Asyncandawait.Operation"
    /// </summary>
    public class Hello
    {
        /// <summary>
        /// IsComplete is boolean Property
        /// "P:Asyncandawait.Hello.IsComplete"
        public bool IsComplete { get; set; }

        /// <summary>
        /// DoWorkAsync is Method
        /// "M:Asyncandawait.Hello.DoWorkAsync()"
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
        /// "M:Asyncandawait.Hello.LongOperation()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("First");
            });
        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Hello.LongOperation1()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation1()
        {
            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Second");
            });

        }

        /// <summary>
        /// LongOperation1 is Method
        /// "M:Asyncandawait.Hello.LongOperation2()"
        /// </summary>
        /// <returns>return task </returns>
        private Task LongOperation2()
        {

            return Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Third");
            });

        }
    }

    /// <summary>
    ///  AsyncAwait3 is a Class
    /// "T:Asyncandawait.AsyncAwait3"
    /// </summary>
    class AsyncAwait3
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(AsyncAwait3));
        
        /// <summary>
        /// Main Method
        /// "M:Asyncandawait.AsyncAwait3.Main(System.string[])"
        /// </summary>
        /// <param name="args">string array</param>
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            log.Info("Begin");

            var hello = new Hello();
            hello.DoWorkAsync();

            while (!hello.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            log.Info("End");
            Console.Read();
        }
    }
}
