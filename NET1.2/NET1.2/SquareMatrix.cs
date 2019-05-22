using System;
using System.Text;

namespace NET1._2
{
    /// <summary>
    ///     This class create square matrix.
    /// </summary>
    /// <remarks>
    ///     This class can change the values of the matrix
    /// </remarks>
    /// <typeparam name="T">This generic parameter</typeparam>
    public class SquareMatrix<T>
    {
        protected T[] Data;

        public event EventHandler<MatrixEventArgs<T>> Changed;

        /// <value>Returns the _size of the matrix</value>
        public int Size { get; }


        /// <summary>
        ///     This is indexer
        /// </summary>
        /// <param name="i">The index of the row </param>
        /// <param name="j">The index of the column </param>
        public virtual T this[int i, int j]
        {
            get
            {
                CheckIndex(i, j);
                return Data[Size * i + j];
            }

            set
            {
                CheckIndex(i, j);
                if (!Equals(Data[Size * i + j], value))
                {
                    OnChanged(new MatrixEventArgs<T>(i, j, Data[Size * i + j], value));
                    Data[Size * i + j] = value;
                }
            }
        }

        /// <summary>
        ///     The constructor creates a matrix
        /// </summary>
        /// <param name="size"> Matrix size </param>
        public SquareMatrix(int size)
        {
            Size = size;
            Data = new T[Size * Size];
        }

        /// <summary>
        ///     Displays the matrix
        /// </summary>
        /// <returns>Returns the matrix</returns>
        public override string ToString()
        {
            var result = new StringBuilder();

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    result.Append($"{this[i, j],-10}");
                }
                result.AppendLine();
            }

            return result.ToString();
        }

        /// <summary>
        ///     The method checks the output beyond the matrix
        /// </summary>
        /// <param name="i">The index of the row </param>
        /// <param name="j">The index of the column </param>
        protected void CheckIndex(int i, int j)
        {
            if (i > Size || j > Size)
            {
                throw new IndexOutOfRangeException("Going beyond the matrix!");
            }

            if (i < 0 || j < 0)
            {
                throw new IndexOutOfRangeException("Matrix size can't be less than 0!");
            }
        }

        /// <summary>
        ///     Event generation code
        /// </summary>
        /// <param name="value"> </param>
        protected virtual void OnChanged(MatrixEventArgs<T> value)
        {
            Changed?.Invoke(this, value);
        }
    }
}