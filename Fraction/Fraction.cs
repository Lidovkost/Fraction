using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public int numerator;
        public int denumerator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        public int Denumerator
        {
            get
            {
                return denumerator;
            }
            set
            {
                if (value == 0) { throw new ArgumentException("Знаменатель не может быть равен нулю!"); }
                denumerator = value;
            }
        }

        /// <summary>
        /// Создать объект класса Fraction
        /// </summary>
        /// <param name="_numerator">числитель</param>
        /// <param name="_denumerator">знаменатель</param>
        public Fraction(int _numerator, int _denumerator)
        {
            numerator = _numerator;
            denumerator = _denumerator;
            this.Simplification();
        }

        /// <summary>
        /// вывод объекта класса Дробь
        /// </summary>
        public void Print()
        {
            if (Denumerator == 1 || numerator == 0)
            {
                Console.WriteLine($"{numerator}");
            }
            else
            {
                Console.WriteLine($"{numerator}/{Denumerator}");
            }
        }

        /// <summary>
        /// Сложение
        /// </summary>
        /// <param name="frac1"> дробь №1</param>
        /// <param name="frac2">дробь №2</param>
        /// <returns>дробь</returns>
        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.Denumerator + frac2.numerator * frac1.Denumerator;
            int denum = frac1.Denumerator * frac2.Denumerator;
            return new Fraction(num, denum);
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        /// <param name="frac1"> дробь№1</param>
        /// <param name="frac2">дробь №2</param>
        /// <returns>дробь</returns>
        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.Denumerator - frac2.numerator * frac1.Denumerator;
            int denum = frac1.Denumerator * frac2.Denumerator;
            return new Fraction(num, denum);
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="frac1"> дробь№1</param>
        /// <param name="frac2">дробь №2</param>
        /// <returns>дробь</returns>
        public static Fraction operator *(Fraction frac1, Fraction frac2)
        {
            int num = frac1.numerator * frac2.numerator;
            int denum = frac1.Denumerator * frac2.Denumerator;
            return new Fraction(num, denum);
        }

        /// <summary>
        /// деление
        /// </summary>
        /// <param name="frac1"> дробь№1</param>
        /// <param name="frac2">дробь №2</param>
        /// <returns>дробь</returns>
        public static Fraction operator /(Fraction frac1, Fraction frac2)
        {
            frac2.Reverse();
            return frac1 * frac2;
        }

        /// <summary>
        /// конвертация дроби
        /// </summary>
        /// <returns>десятичное значение дроби</returns>
        public double ConvertToDouble()
        {
            double number = numerator / denumerator;
            return number;
        }

        /// <summary>
        /// сокращение дроби
        /// </summary>
        public void Simplification()
        {
            int i = 2;
            int min = this.Min();
            this.PartialSimplification(min);
            while (i <= Math.Sqrt(min))
            {
                if (!this.PartialSimplification(i))
                {
                    i++;
                }

            }
        }
        //privates
        private bool PartialSimplification(int i)
        {
            if (numerator % i == 0 && denumerator % i == 0)
            {
                denumerator /= i;
                numerator /= i;
                return true;
            }
            return false;
        }
        private int Min()
        {
            if (Math.Abs(numerator) >= Math.Abs(denumerator)) { return Math.Abs(denumerator); }
            return Math.Abs(numerator);
        }
        private void Reverse()
        {
            int temp = numerator;
            numerator = denumerator;
            denumerator = temp;
        }

    }
}
