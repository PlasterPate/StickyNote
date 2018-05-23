using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public interface IState
    {
        IState EnterZeroDigit();
        IState EnterNonZeroDigit(char c);
        IState EnterOperator(char c);
        IState EnterPoint();
        IState EnterEqual();
    }
}
