/*  Program.cs – консольний тест класу IntMatrix  */

using IndexersLib;

class Program
{
    static void Main()
    {
        var m = new IntMatrix(2, 3, fill: 1);

        Console.WriteLine($"Матриця {m.Size.Rows}×{m.Size.Cols}");
        m[0, 2] = 42;
        Console.WriteLine($"m[0,2] = {m[0,2]}");

        try { var fail = m[5, 0]; }
        catch (Exception ex) { Console.WriteLine($"Очікувана помилка: {ex.Message}"); }
    }
}
