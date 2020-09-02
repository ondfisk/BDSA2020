using System;
using System.Collections.Generic;

namespace Lecture02
{
    public class Variance
    {
        public class Person { }
        public class Student : Person { }

        public void ArrayTypeCovariance()
        {
            Person[] people = new Student[9];

            // What happens here?
            people[3] = new Person();
        }

        public void Covariance()
        {
            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = strings;
        }

        public void Covariance2()
        {
            // IEnumerable<object> objects = new List<object>();
            // IEnumerable<string> strings = objects;
        }

        public class ObjectComparer : IComparer<object>
        {
            public int Compare(object x, object y)
            {
                throw new NotImplementedException();
            }
        }

        public class StringComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                throw new NotImplementedException();
            }
        }

        public void Contravariance()
        {
            IComparer<string> compareString = new ObjectComparer();
        }

        public void Contravariance2()
        {
            // IComparer<object> compareObject = new StringComparer();
        }
    }
}
