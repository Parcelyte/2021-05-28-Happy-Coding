using System;

namespace _20210528HappyCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Lambda-Expression:
             * Linker Teil: Eingabe/Input-Parameter.
             * Mittelteil: "=>" Lambda-Operator. Trennt linken und rechten Teil.
             * Rechter Teil: Lambda-Body/Körper. Enthält einen Ausdruck (ein Statement) oder eine Abfolge von Statements ( Codeblock { ... } )
             */

            #region Delegates-Beispiel (Func)

            // Delegate nimmt einen Parameter vom Typ Integer und gibt einen Wert von Datentyp Int zurück.
            Func<int, int> quadratFlaeche = x => x * x;
            // Delegate nimmt zwei Parameter vom Typ Integer und gibt einen Wert von Datentyp Int zurück.
            Func<int, int, int> rechteckFlaeche = (x, y) => x * y;

            // Aufruf der Func-Delegates uns Ausgabe.
            Console.WriteLine("Quadratfläche in cm: " + quadratFlaeche(5) + "cm²");
            Console.WriteLine("Rechteckfläche in cm: " + rechteckFlaeche(5, 7) + "cm²");

            #endregion Delegates-Beispiel (Func)

            #region Delegates-Beispiel (Action)

            // Nimmt einen String-Parameter, gibt nichts zurück! (void)
            Action<string> ausgabeParameter = param =>
            {
                string parameter = $"Der übergebene Parameter lautet: {param}";
                Console.WriteLine(parameter);
            };

            // Aufruf des Action-Delegates.
            ausgabeParameter("Hallo Welt!");

            #endregion Delegates-Beispiel (Action)

            #region Delegates-Beispiel (Predicate)

            // Array, welcher Objekte vom Typ Person enthält.
            Person[] personen =
            {
                new Person { Name = "Alexander", Age = 25 },
                new Person { Name = "Daniel", Age = 17 },
                new Person { Name = "Christian", Age = 32 },
                new Person { Name = "Felix", Age = 18 },
                new Person { Name = "Jonathan", Age = 16 },
            };

            // Predicate-Delegate, welche eine Methode referenziert.
            Predicate<Person> predicatePerson = FindePersonenAelterAlsAchtzehn;

            // Neuer Array, welcher basierend auf den Kriterien unseres Predicate-Delegates Personen im personen-Array findet.
            Person[] personenAelterAlsAchtzehn = Array.FindAll(personen, predicatePerson);

            // Ausgabe der gefundenen Personen (basierend auf den Kriterien der Methode).
            Console.WriteLine("Gefundene Personen:\n");
            foreach (Person person in personenAelterAlsAchtzehn)
            {
                Console.WriteLine($"Name: {person.Name}" + $"Alter: {person.Age}");
            }

            #endregion Delegates-Beispiel (Predicate)

            #region Delegate-Ersatz durch Lambda-Ausdruck

            // Integer-Array, welcher Zahlen von 1-10 enthält.
            int[] zahlenArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Erstellt neuen Array basierend auf den Kriterien dargestellt durch unseren Lambda-Ausdruck. Ersetzt Predicate-Delegate (siehe vorheriges Beispiel)
            int[] zahlenGerade = Array.FindAll(zahlenArray, x => x % 2 == 0);
            int[] zahlenUngerade = Array.FindAll(zahlenArray, x => x % 2 != 0);

            // Ausgabe der Elemente in den geraden und ungeraden Zahlen-Arrays.
            Console.WriteLine("Gerade Zahlen: " + string.Join(", ", zahlenGerade));
            Console.WriteLine("Ungerade Zahlen: " + string.Join(", ", zahlenUngerade));

            #endregion Delegate-Ersatz durch Lambda-Ausdruck

            #region Array, bestehend aus Lambda-Ausdrücken

            // Erstellt einen Delegate-Array, welcher 2 Integer-Parameter besitzt und einen Wert von Typ Integer zurückgibt.
            // Anstatt eines Delegaten verwenden wir hier Lambda-Ausdrücke als Ersatz.
            Func<int, int, int>[] berechnungen = new Func<int, int, int>[]
            {
                (x, y) => x + y,
                (x, y) => x - y,
                (x, y) => x * y,
                (x, y) => x / y
            };

            // Ausgabe der einzelnen Berechnungen der Lambda-Ausdrücke durch Zugriff auf die einzelnen Array-Elemente.
            Console.WriteLine("Addition: " + berechnungen[0](5, 5));
            Console.WriteLine("Subtraktion: " + berechnungen[1](100, 50));
            Console.WriteLine("Multiplikation: " + berechnungen[2](5, 5));
            Console.WriteLine("Division: " + berechnungen[3](100, 5));

            #endregion Array, bestehend aus Lambda-Ausdrücken

            #region Multicast-Delegates

            /* Multicast-Delegates referenzieren mehr als nur eine Methode. Die Delegate wird instanziert und kann durch den Namen
             * aufgerufen werden. Multicast-Delegates dürfen nur auf Methoden verweisen, welche nichts (void) zurückgeben. 
             * Ansonsten kommt es zu einer Run-Time Exception.
             */

            // Erstellt eine neue Instanz des Calculations-Delegate (siehe unten).
            Calculations calc = new Calculations(Operations.Add);
            calc(5, 5);

            // Instanziert calc neu, referenziert aber diesmal eine andere Methode.
            calc = new Calculations(Operations.Subtract);
            calc(100, 50);

            // Instanziert calc neu, referenziert aber diesmal eine andere Methode.
            calc = new Calculations(Operations.Multiply);
            calc(5, 5);

            // Instanziert calc neu, referenziert aber diesmal eine andere Methode.
            calc = new Calculations(Operations.Division);
            calc(100, 5);

            #endregion Multicast-Delegates
        }

        // Delegate für das Multicast-Beispiel.
        private delegate void Calculations(int x, int y);

        // Methode für das Predicate-Beispiel.
        private static bool FindePersonenAelterAlsAchtzehn(Person person)
        {
            return person.Age >= 18;
        }
    }
}
