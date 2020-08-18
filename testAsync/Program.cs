using System;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;

namespace testAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main {nameof(Test)} begin - {DateTime.Now}");
            
            Test().SafeFireAndForget(Console.WriteLine);  
            
            Console.WriteLine($"Main {nameof(Test)} end - {DateTime.Now}");
            
            Console.WriteLine($"Main {nameof(Test2)} begin - {DateTime.Now}");
            
            Test2().SafeFireAndForget(ex =>
            {
                Console.WriteLine("EX " + Thread.CurrentThread.ManagedThreadId); 
                Console.WriteLine(ex);
            });  
            
            Console.WriteLine($"Main {nameof(Test2)} end - {DateTime.Now}");
            
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }

        static async Task Test()
        {
            Console.WriteLine($"{nameof(Test)} begin {Thread.CurrentThread.ManagedThreadId} - {DateTime.Now}");
            
            await Task.Delay(TimeSpan.FromSeconds(10));
            
            Console.WriteLine($"{nameof(Test)} end {Thread.CurrentThread.ManagedThreadId} - {DateTime.Now}");
        }
        
        static async Task Test2()
        {
            Console.WriteLine($"{nameof(Test2)} begin {Thread.CurrentThread.ManagedThreadId} - {DateTime.Now}");
            
            await Task.Delay(TimeSpan.FromSeconds(3));
            
            throw new Exception("TEST 123"); 
        }
    }
}