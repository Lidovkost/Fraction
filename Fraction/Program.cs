namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction drob = new Fraction(1, 2);
            Fraction other = new Fraction(2, 6);
            drob.Print();
            Console.WriteLine(drob.Denumerator);
            Console.WriteLine(drob.Numerator);
            other.Print();
            drob = drob / other * drob + (other - drob);
            drob.Print();
            Console.ReadKey();
        }
    }
}