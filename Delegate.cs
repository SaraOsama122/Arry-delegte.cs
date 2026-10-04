namespace DeleteaeG1
{
    public delegate bool CheckNumberDelegate(int n);
    public delegate int CalculationDelegate(int a, int b);

    public static class CheckNumber
    {
        public static bool Positive(int n) 
          => n > 0;
        public static bool Negative(int n)
          => n < 0;
        public static bool Even(int n)
          => n % 2 == 0;
        public static bool Odd(int n)
          => n % 2 != 0;
        public static bool DivBy3(int n)
          => n % 3 == 0;

        public static int Sum(int x, int y)
          => x + y;
        public static int Multiply(int x, int y)
          => x * y;

        public static void Check(this int[] arr, CheckNumberDelegate del)
        {
            foreach (var item in arr)
            {
                if (del(item))
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void CheckBuiltIn(this int[] arr, Func<int, bool> del)
        {
            foreach (var item in arr)
            {
                if (del(item))
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { -5, -2, 0, 1, 2, 3, 4, 6, 9, 10 };

          
            numbers.Check(CheckNumber.Positive);
            numbers.Check(CheckNumber.Negative);
            numbers.Check(CheckNumber.Even);
            numbers.Check(CheckNumber.Odd);
            numbers.Check(CheckNumber.DivBy3);
            numbers.CheckBuiltIn(n => n > 0);
            numbers.CheckBuiltIn(n => n < 0);
            numbers.CheckBuiltIn(n => n % 2 == 0);
            numbers.CheckBuiltIn(n => n % 2 != 0);
            numbers.CheckBuiltIn(n => n % 3 == 0);

            CalculationDelegate calc1 = CheckNumber.Sum;
            Console.WriteLine(calc1(10, 5));

            calc1 = CheckNumber.Multiply;
            Console.WriteLine(calc1(10, 5));

            Func<int, int, int> calc2 = CheckNumber.Sum;
            Console.WriteLine(calc2(10, 5));

            calc2 = CheckNumber.Multiply;
            Console.WriteLine(calc2(10, 5));
        }
    }
}
