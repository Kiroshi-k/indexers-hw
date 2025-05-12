/*  IntMatrix.cs – двовимірний масив з індексатором і властивістю
 *  Варіант 4, Автор: Marchenko Kyryl
 */
namespace IndexersLib
{
    /// <summary>Двовимірний int‑масив із захистом від виходу за межі.</summary>
    public class IntMatrix
    {
        private readonly int[,] _data;
        public int Rows { get; }
        public int Cols { get; }

        public IntMatrix(int rows, int cols, int fill = 0)
        {
            if (rows <= 0 || cols <= 0)
                throw new ArgumentException("Розміри мають бути додатні");

            Rows = rows;
            Cols = cols;
            _data = new int[rows, cols];

            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    _data[r, c] = fill;
        }

        /// <summary>Read‑only властивість, що повертає розміри.</summary>
        public (int Rows, int Cols) Size => (Rows, Cols);

        /// <summary>Двовимірний індексатор.</summary>
        public int this[int r, int c]
        {
            get => IsInside(r, c) ? _data[r, c] : throw Out(r, c);
            set
            {
                if (!IsInside(r, c)) throw Out(r, c);
                _data[r, c] = value;
            }
        }

        private bool IsInside(int r, int c) =>
            r >= 0 && r < Rows && c >= 0 && c < Cols;

        private Exception Out(int r, int c) =>
            new IndexOutOfRangeException($"[{r},{c}] поза межами {Rows}×{Cols}");
    }
}
