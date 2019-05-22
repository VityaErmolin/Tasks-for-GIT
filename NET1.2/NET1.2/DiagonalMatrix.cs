using System;

namespace NET1._2
{
    /// <summary>
    ///     This class create Diagonal matrix.
    /// </summary>
    /// <remarks>
    ///     This class can change the values of the matrix
    /// </remarks>
    /// <typeparam name="T">This generic parameter</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        ///     The constructor creates a matrix
        /// </summary>
        /// <param name="size"> Matrix size </param>
        public DiagonalMatrix(int size) : base(size)
        {
            Data = new T[size];
        }

        /// <summary>
        ///     This is indexer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public override T this[int i, int j]
        {
            get
            {
                CheckIndex(i, j);
                return (i==j)? Data[i]: default(T);
            }

            set
            {
                CheckIndex(i, j);

                if (i != j)
                {
                    throw new ArgumentException("Diagonal matrix have elements only on the main diagonal(i==j)");
                }

                if (!Equals(Data[i], value))
                {
                    Data[i] = value;
                    OnChanged(new MatrixEventArgs<T>(i, j, Data[i], value));
                }
            }
        }
    }
}