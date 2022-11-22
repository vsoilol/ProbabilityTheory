using System;
using System.Text;
using Common.Extensions;
using IndividualTask2.Helpers;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Integration;

namespace IndividualTask2
{
    class Program
    {
        private static readonly WordprocessingHelper _wordprocessingHelper = new WordprocessingHelper();
        private static readonly DocumentService _documentService = new DocumentService(_wordprocessingHelper);
        private static readonly ConsolePresenter _consolePresenter = new ConsolePresenter(_documentService);
        private static readonly MathService _mathService = new MathService();

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var numbers = _consolePresenter.GetNumbers(90, 100);

            //var mathData = _mathService.CalculateAllNeededData(numbers);

            //_consolePresenter.DisplayAllCalculation(mathData);
            //_documentService.GenerateResultDocument(mathData);

            var t = 2.58;
            var n = 100;
            var m = 60;
            var W = m / (decimal)n;

            var onePart = n / (Math.Pow(t, 2) + n);
            var secondPart = t * Math.Pow((double)((W * (1 - W) / n) + (decimal)Math.Pow(t/(2*n), 2)), 0.5);
            var thirdPart = Math.Pow((double)W, 2) + (Math.Pow(t, 2) / (2 * n)) - secondPart;
            var p1 = onePart * thirdPart;


            var p1_second = W - (decimal)(t * Math.Pow((double)(W * (1 - W) / n), 0.5));

            Console.WriteLine(p1);
            Console.WriteLine(p1_second);
        }
    }
}