using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeoFigure
{
    abstract class GeoFigure
    {
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public abstract decimal Square();
        public abstract decimal Perimeter();

    }
    class Rectangle : GeoFigure
    {
        public Rectangle()
        {
            name = "Прямоугольник";
            Console.Write("Введите длину: ");
            Lengh = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите ширину: ");
            Heigth = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();
        }
        public override decimal Square()
        {
            decimal _square = this.lengh * this.heigth;
            return _square;
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.lengh + this.lengh + this.heigth + this.heigth;
            return _perimeter;
        }
        private decimal Lengh;

        public decimal lengh
        {
            get { return Lengh; }
            set { Lengh = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }
    class Squere_2 : GeoFigure
    {
        public Squere_2()
        {
            bool Correcten = false;
            name = "Квадрат";
            do
            {
                Console.Write("Введите 1-ую строну квадрата: ");
                Lengh = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Введите 2-ую строну квадрата: ");
                Heigth = Convert.ToDecimal(Console.ReadLine());
                if (Lengh == Heigth)
                    Correcten = true;
            } while (Correcten != true);
            Console.WriteLine();
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.lengh * 4;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal _square = this.lengh * this.heigth;
            return _square;
        }
        private decimal Lengh;

        public decimal lengh
        {
            get { return Lengh; }
            set { Lengh = value; }
        }
        private decimal Heigth;

        public decimal heigth
        {
            get { return Heigth; }
            set { Heigth = value; }
        }
    }

    class Triangle : GeoFigure
    {
        public Triangle()
        {
            name = "Tреугольник";
            Console.Write("Введите 1-ую строну треугольника: ");
            A = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите 2-ую строну треугольника: ");
            B = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Введите 3-ую строну треугольника: ");
            C = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();
        }
        private decimal A;

        public decimal a
        {
            get { return A; }
            set { A = value; }
        }
        private decimal B;

        public decimal b
        {
            get { return B; }
            set { B = value; }
        }
        private decimal C;

        public decimal c
        {
            get { return C; }
            set { C = value; }
        }
        public override decimal Perimeter()
        {
            decimal _perimeter = this.A + this.C + this.B;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal P = (this.A + this.C + this.B) / 2;
            return (decimal)Math.Sqrt((double)(P * (P - this.A) * (P - this.B) * (P - this.C)));
        }
    }
    class Сircle : GeoFigure
    {
        public Сircle()
        {
            name = "Круг";
            Console.Write("Введите радиус круга: ");
            R = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();
             Constant = 3.14m;
        }
        private decimal R;
        public decimal radius
        {
            get { return R; }
            set { R = value; }
        }
        private decimal Constant;

        public decimal pi
        {
            get { return Constant; }
            set { Constant = value; }
        }

        public override decimal Perimeter()
        {
            decimal _perimeter = 2 * this.R * this.Constant;
            return _perimeter;
        }
        public override decimal Square()
        {
            decimal _squere = this.Constant * (this.R * this.R);
            return _squere;
        }
    }
    class createFigure
    {
        private int number, count = 0;
        private GeoFigure[] Array;
        private string request;
        private bool Correcten;
        private int Request()
        {
            do
            {
                Console.Write("Сколько  хотите создать фигур?:\n");
                request = Console.ReadLine();
                Correcten = Int32.TryParse(request, out int res);
                if (Correcten)
                {
                    number = Convert.ToInt32(request);
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте ещё раз: ");
                    Correcten = false;
                }
            } while (Correcten == false);
            return number;
        }
        private GeoFigure[] CreateFigure()
        {
            int param = 0;
            number = Request();
            Console.WriteLine();
            Array = new GeoFigure[number];
            do 
            {
                Console.WriteLine("Какую фигуру хотите создать?:\n" +
                    "1 - Прямоугольник\n" +
                    "2 - Квадрат\n" +
                    "3 - Tреугольник\n" +
                    "4 - Круг\n" +
                    "5 - Выход \n");

                Console.Write("Ввод -> ");
                param = Convert.ToInt32(Console.ReadLine());

                switch (param)
                {
                    case 1:
                        Rectangle Rectangle = new Rectangle();
                        Array[count] = Rectangle;
                        count++;
                        break;

                    case 2:
                        Squere_2 Squere = new Squere_2();
                        Array[count] = Squere;
                        count++;
                        break;

                    case 3:
                        Triangle Triangle = new Triangle();
                        Array[count] = Triangle;
                        count++;
                        break;

                    case 4:
                        Сircle Сircle = new Сircle();
                        Array[count] = Сircle;
                        count++;
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;
                }

            } while (count < number) ;

            return Array;
        }

            public void PrintFigure()
            {
            Array = CreateFigure();
                for (int i = 0; i < Array.Length; i++)
                {
                    Console.WriteLine("{0}) {1} -> площадь - {2} и периметр - {3} ",
                        i + 1, Array[i].name, Array[i].Square(), Array[i].Perimeter());
                }
                Console.WriteLine();
            }


        class Program
        {
            static void Main(string[] args)
            {
                createFigure Figure = new createFigure();
                Figure.PrintFigure();
            }
        } 
    }
}

