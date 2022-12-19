using System;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace IntervalAssessmentPracticalTask
{
    class Program
    {
        private static readonly ITask task = new Task14();
        
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
                //task.CalculateTask();
           // Console.WriteLine(StudentDistribution.GetFunctionValue(0.95, 10));

           var h = 5.5m;
           var values = new decimal[]
           {
               7 / 30m / h, 
               3 / 30m / h, 
               6 / 30m / h, 
               6 / 30m / h, 
               5 / 30m / h, 
               3 / 30m / h,
           };

           Console.WriteLine(h*values.Sum());

           Console.WriteLine(string.Join('\n', values));
        }
    }
}