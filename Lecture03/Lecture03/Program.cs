using System;
using Lecture03.Models;

namespace Lecture03
{
    public enum LogLevel { Verbose, Debug, Warning, Error }

    public delegate void Logger(string input, LogLevel level);
    public delegate int Compute1(int x);
    public delegate int Compute2(int x, int y);
    public delegate bool Decide(int x);

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Utility
    {
        private readonly Logger _logger;

        public Utility(Logger logger)
        {
            _logger = logger;
        }

        public int Compute(Compute1 op, int x)
        {
            _logger.Invoke($"Invoking {op.Method.Name} with {x}", LogLevel.Debug);

            return op.Invoke(x);
        }

        public int Compute(Compute2 op, int x, int y)
        {
            _logger.Invoke($"Invoking {op.Method.Name} with {x} and {y}", LogLevel.Debug);

            return op.Invoke(x, y);
        }

        public int LogSafeCompute(Compute2 op, int x, int y)
        {
            _logger($"Invoking {op.Method.Name} with {x} and {y}", LogLevel.Debug);

            try
            {
                return op(x, y);
            }
            catch (Exception e)
            {
                _logger($"Exception: {e.Message}", LogLevel.Error);
                return -1;
            }
        }
    }
}
