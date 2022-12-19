using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndividualTask2.Helpers;

namespace IndividualTask2
{
    class Program
    {
        private static readonly WordprocessingHelper _wordprocessingHelper = new();
        private static readonly DocumentService _documentService = new(_wordprocessingHelper);
        private static readonly ConsolePresenter _consolePresenter = new(_documentService);
        private static readonly MathService _mathService = new();

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            //var numbers = _consolePresenter.GetNumbers(90, 100);
            var numbers = "3.54; 3.58; 3.61; 3.67; 3.75"
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            Console.WriteLine(numbers.Length);

            var mathData = _mathService.CalculateAllNeededData(numbers);

            _consolePresenter.DisplayAllCalculation(mathData);
            //_documentService.GenerateResultDocument(mathData);

            /*var t = 2.58;
            var n = 100;
            var m = 60;
            var W = m / (decimal)n;

            var onePart = n / (Math.Pow(t, 2) + n);
            var secondPart = t * Math.Pow((double)((W * (1 - W) / n) + (decimal)Math.Pow(t/(2*n), 2)), 0.5);
            var thirdPart = Math.Pow((double)W, 2) + (Math.Pow(t, 2) / (2 * n)) - secondPart;
            var p1 = onePart * thirdPart;
            
            //List<ICalculator> value = new List<>()


            var p1_second = W - (decimal)(t * Math.Pow((double)(W * (1 - W) / n), 0.5));

            Console.WriteLine(p1);
            Console.WriteLine(p1_second);*/
        }
    }
}