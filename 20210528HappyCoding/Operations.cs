using System;

namespace _20210528HappyCoding
{
    /// <summary>
    /// Klasse für das Multicast-Delegate Beispiel.
    /// </summary>
    class Operations
    {
        #region Public Methods

        public static void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public static void Subtract(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }

        public static void Multiply(int x, int y)
        {
            Console.WriteLine($"{x} * {y} = {x * y}");
        }

        public static void Division(int x, int y)
        {
            Console.WriteLine($"{x} / {y} = {x / y}");
        }

        #endregion Public Methods
    }
}
