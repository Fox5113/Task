using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface ICalculatorSum
    {
        public abstract long Sum();
    }

    public interface ICalculatorMultiplication
    {
        public abstract long Multiplication();
    }

    public interface ICalculatorDifference
    {
        public abstract long Difference();
    }
}
