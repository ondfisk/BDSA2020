using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Lecture08.Models.Iterator
{
    public class CountToInfinity : IEnumerable<BigInteger>
    {
        private readonly BigInteger _startNumber;

        public IEnumerator<BigInteger> GetEnumerator() => new CountToInfinityEnumerator(_startNumber);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public CountToInfinity()
        {
        }

        private CountToInfinity(BigInteger startNumber)
        {
            _startNumber = startNumber;
        }

        public IEnumerable<BigInteger> Skip(BigInteger count) => new CountToInfinity(_startNumber + count);

        class CountToInfinityEnumerator : IEnumerator<BigInteger>
        {
            private readonly BigInteger _startNumber;

            public BigInteger Current { get; private set; }

            object IEnumerator.Current => Current;

            public CountToInfinityEnumerator()
                : this(0)
            {
            }

            public CountToInfinityEnumerator(BigInteger startNumber)
            {
                _startNumber = startNumber;
                Reset();
            }

            public bool MoveNext()
            {
                Current++;

                return true;
            }

            public void Reset() => Current = _startNumber - 1;

            public void Dispose()
            {
            }
        }
    }
}