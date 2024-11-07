using DelegatesAndEvents;
using System.Diagnostics;

namespace Task
{
    public class Program
    {
        static void Main(string[] args)
        {
            BaseConsoleActions.PrepareConsole(Const.Title);
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            ConsoleMenu menu = new ConsoleMenu(Const.OperationCaption)
            {
                MenuItems =
                {
                    new ConsoleMenuItem(Const.SumT5, 0, (s, e) => { SumCalculation(100_000); }),
                    new ConsoleMenuItem(Const.SumT6, 0, (s, e) => { SumCalculation(1_000_000); }),
                    new ConsoleMenuItem(Const.SumT7, 0, (s, e) => { SumCalculation(10_000_000); }),
                    new ConsoleMenuItem(Const.SomeSum, 0, (s, e) =>
                        {
                            int count = BaseConsoleActions.AskForValidIntegerInput($"\n{Const.PutSomeCount} ");
                            SumCalculation(count);
                        }),
                    new ConsoleMenuItem(Const.DifferenceT5, 0, (s, e) => { DifferenceCalculation(100_000); }),
                    new ConsoleMenuItem(Const.DifferenceT6, 0, (s, e) => { DifferenceCalculation(1_000_000); }),
                    new ConsoleMenuItem(Const.DifferenceT7, 0, (s, e) => { DifferenceCalculation(10_000_000); }),
                    new ConsoleMenuItem(Const.SomeDifference, 0, (s, e) =>
                        {
                            int count = BaseConsoleActions.AskForValidIntegerInput($"\n{Const.PutSomeCount} ");
                            DifferenceCalculation(count);
                        }),
                    new ConsoleMenuItem(MessagesConst.Exit, 0, (s, e) =>  {
                           Process.GetCurrentProcess().Kill();
                        }),

                }
            };
            menu.OnItemAdded += (sender, e) =>
            {
                menu.DisplayMenu();
            };
            menu.DisplayMenu();
        }
        private static void SumCalculation(int size)
        {
            var calculator = new SumCalculator(size);

            Stopwatch stopwatch = Stopwatch.StartNew();
            var sequentialSum = calculator.Sum();
            stopwatch.Stop();
            var sequentialTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var parallelSum = calculator.CalculateSumParallel();
            stopwatch.Stop();
            var parallelTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var parallelThreadSum = calculator.CalculateSumUsingThreads();
            stopwatch.Stop();
            var parallelThreadTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var linqSum = calculator.CalculateSumLINQ();
            stopwatch.Stop();
            var linqTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var plinqSum = calculator.CalculateSumPLINQ();
            stopwatch.Stop();
            var plinqTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine();
            Console.WriteLine($"Размер массива: {size}");
            Console.WriteLine($"{Const.Sum} (последовательно): {sequentialSum}, время: {sequentialTime} мс");
            Console.WriteLine($"{Const.Sum} (параллельно): {parallelSum}, время: {parallelTime} мс");
            Console.WriteLine($"{Const.Sum} (параллельно Thread): {parallelThreadSum}, время: {parallelThreadTime} мс");
            Console.WriteLine($"{Const.Sum} (LINQ): {linqSum}, время: {linqTime} мс");
            Console.WriteLine($"{Const.Sum} (PLINQ): {plinqSum}, время: {plinqTime} мс");
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private static void DifferenceCalculation(int size)
        {
            var calculator = new SumCalculator(size);

            Stopwatch stopwatch = Stopwatch.StartNew();
            var sequentialSum = calculator.Difference();
            stopwatch.Stop();
            var sequentialTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var parallelSum = calculator.CalculateDifferenceParallel();
            stopwatch.Stop();
            var parallelTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var parallelThreadSum = calculator.CalculateDifferenceUsingThreads();
            stopwatch.Stop();
            var parallelThreadTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var linqSum = calculator.CalculateDifferenceLINQ();
            stopwatch.Stop();
            var linqTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var plinqSum = calculator.CalculateDifferencePLINQ();
            stopwatch.Stop();
            var plinqTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine();
            Console.WriteLine($"Размер массива: {size}");
            Console.WriteLine($"{Const.Difference} (последовательно): {sequentialSum}, время: {sequentialTime} мс");
            Console.WriteLine($"{Const.Difference} (параллельно): {parallelSum}, время: {parallelTime} мс");
            Console.WriteLine($"{Const.Difference} (параллельно Thread): {parallelThreadSum}, время: {parallelThreadTime} мс");
            Console.WriteLine($"{Const.Difference} (LINQ): {linqSum}, время: {linqTime} мс");
            Console.WriteLine($"{Const.Difference} (PLINQ): {plinqSum}, время: {plinqTime} мс");
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }
    }
}
