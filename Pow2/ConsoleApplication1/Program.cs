using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Step2 : IEnumerable
    {
        internal int m_step;
        internal double m_2;
        public Step2(int init)
        {
            m_step = init;
            m_2 = Math.Pow(2.0, m_step);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public Step2Enum GetEnumerator()
        {
            return new Step2Enum(m_2);
        }
    }

    public class Step2Enum : IEnumerator
    {
        double m_s2;

        public Step2Enum(double s2)
        {
            m_s2 = s2;
        }

        public bool MoveNext()
        {
            m_s2 *= 2; 
            return true;
        }

        public void Reset()
        {
            m_s2 = 0.5;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public double Current
        {
            get
            {
                    return m_s2;
            }
        }
    }

    class App
    {
        static void Main()
        {
            Step2 MyStep = new Step2(-1);

            foreach (var p in MyStep)
                if(p < 1000000)
                Console.WriteLine(p);

        }
    }
}
