using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace test_3_26
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = { 1, 2, 3, 4, 5 };
            ArrayList num2 = new ArrayList() { 1, 2, 3, 4, 5 };
            //Console.WriteLine(Sum(num1));
            //Console.WriteLine(Sum(num2));

        }
    }
    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;
        public ReadOnlyCollection(int[] array) 
        {
            _array = array;
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;
            private int _head;
            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }
            public object Current 
            {
                get { object o = this._collection._array[_head]; return o; }
            }

            public bool MoveNext()
            {
                if(++_head< this._collection._array.Length) return true;
                else return false;
            }

            public void Reset()
            {
                _head=-1;
            }
        }
    }
}
