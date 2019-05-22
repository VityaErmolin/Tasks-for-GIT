using System;

namespace NET1._2
{
    /// <summary>
    ///     A class to represent the data
    /// </summary>
    /// <typeparam name="T">"T" is the parameter type</typeparam>
    public class MatrixEventArgs<T> : EventArgs
    {
        public T Old { get; }
        public T New { get; }
        public int I { get; }
        public int J { get; }

        public MatrixEventArgs(int i, int j, T old, T _new)
        {
            I = i;
            J = j;
            Old = old;
            New = _new;
        }
    }
}