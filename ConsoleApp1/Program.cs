using System;

namespace ConsoleApp1
{

    class Date
    {
        //Поля
        public Year Year {get;}
        
        public Month Month { get; }

        public Day Day { get; }
        //Методы

        public Date(int day, int month, int year) //инициализир. конструктор
        {
            Year = new Year(year);
            Month = new Month(month);
            Day = new Day(day);
        }

        public DayOfWeek GetDayOfWeek() //возвращает название дня в зависимости от даты 
        {
            DateTime dt = new DateTime(Year.Num_Year, Month.Num_Month, Day.day_dat); //структура дата
            return dt.DayOfWeek; //возвращает день соответствующий указанной дате
        }

        public void GetDayOfYear(int dney) //по количеству дней печатает дату
        {
            int Time_year = 1, Time_month = 1, Time_day = 1, days = 0, t = 1;

            while (days < dney)
            {
                if ((days += 1461) < dney) Time_year += 4;
            }
            days -= 1461;

            //============00000000000============

            while (days < dney)
            {
                if (t == 4) { days += 366; t = 1; }
                else { days += 365; t++; }

                if (days < dney) Time_year++;
            }
            if (t == 1) days -= 366;
            else days -= 365;

            //============00000000000============

            bool Flag_leap = Year.LeapYear(Time_year);

            int mes = 1;

            while (mes != 13 && days < dney)
            {
                if ((days += Month.getDays(mes, Flag_leap)) < dney)
                {
                    Time_month++;
                    mes++;
                }
            }
            days -= Month.getDays(mes, Flag_leap);

            Time_day = dney - days;

            Console.WriteLine($"{Time_day}.{Time_month}.{Time_year}");
        } 

        public override bool Equals(object obj) 
        {
            {
                Date D1 = obj as Date;

                if (D1 != null)//eсли не пустой

                    return D1.Year.Equals(Year);
                else 
                    return false;



                
            }
        } //пока не понятно

        public override string ToString() 
        { 
            return "the Date: " + Day.day_dat + "." + Month.Num_Month + "." + Year.Num_Year +" this is " + GetDayOfWeek(); 
        }

        public int daysBetween(Date date) 
        {
            //int a;

            DateTime endDate = new DateTime(Year.Num_Year, Month.Num_Month, Day.day_dat);
            DateTime startDate = new DateTime(date.Year.Num_Year, date.Month.Num_Month, date.Day.day_dat);


            int a = (int)((endDate - startDate).TotalDays);
            return a;
            
        }
    }


    public class Year
    {
        public int Num_Year;
        public bool leapYear;

        public Year(int year) //инициализирующий конструктор с проверкой высокосности
        {
            Num_Year = year;

            leapYear = LeapYear(year);

            /*



            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))                     
                    leapYear = true; //высокосный если делится на 4 но не на 100
                else
                leapYear = false; //если на 4 не делится - не высокосн
            */

        }

        public static bool LeapYear(int year) 
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                return true; //высокосный если делится на 4 но не на 100
            else
                return false; //если на 4 не делится - не высокосн
        }



    }

    public class Month
    {
        public int Num_Month; //номер месяца
        public int Days;      //кол-во дней

        public Month(int monthNumber) //конструктор
        {
            if (monthNumber >= 1 && monthNumber <= 12)
                Num_Month = monthNumber; 
        } 
        public static int getDays(int monthNumber, bool leapYear)//возвращает кол-во дней месяца 
        {
            if (monthNumber == 2)
                if (leapYear == true) return 29;
                else return 28;

            if (monthNumber == 4 || monthNumber == 6 || monthNumber == 9 || monthNumber == 11)
                return 30;
            else return 31;

        }
    }
    public class Day
    {
        public int day_dat;
      
        public Day(int day) 
        {
            if (day >= 1 && day <= 31)
                day_dat = day;
            else
                day_dat = 1; 
        }

        public static DayOfWeek valueOf(int index) //возвращает день с соотв. индексом
        {
            if (index >= 0 && index <7)
                return (DayOfWeek)index;
            else
                throw new ArgumentException();
        }//пока не понятно
    }


    class Program
    {
        static void Main(string[] args)
        {

            //Date A = new Date(21, 10, 2021);
            //Console.WriteLine($"{A.GetDayOfWeek()}" );
            //Date D = new Date(21, 9, 2021);

            // Console.WriteLine($"{Day.valueOf(6)}");

            //var bac= A.daysBetween(D);
            //Console.WriteLine($"{A.ToString()}");


            //int dney = 364;
            //int dney = 1462;

        }
    }
}
