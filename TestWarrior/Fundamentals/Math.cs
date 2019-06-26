using System.Collections.Generic;

namespace TestWarrior.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // When you use the yield contextual keyword in a statement, you indicate that the method, operator or get accessor in which it appears is an iterator.
        // Using yield to define an iterator removes the need for an explicit extra class.
        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i;
        }
    }
}
