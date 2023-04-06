using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Auxiliar
{
    public static class DateTimeExtensions
    {

        public static DateTime PrimerDiaDelMes(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static int DiasEnElMes(this DateTime value)
        {
            return DateTime.DaysInMonth(value.Year, value.Month);
        }

        public static DateTime UltimoDiaDelMes(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DiasEnElMes());
        }


        public static void ExtremarFechas(ref DateTime desde, ref DateTime hasta)
        {
            desde = desde.Date;
            hasta = hasta.Date.AddDays(1).AddTicks(-1);
        }

        public static void PrimerYUltimoDiaMes(ref DateTime primerDiaMes, ref DateTime UltimoDiaMes)
        {
            primerDiaMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            UltimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);
        }
        //public static DateTime FirstDayOfMonth_AddMethod(this DateTime value)
        //{
        //    return value.Date.AddDays(1 - value.Day);
        //}

        //public static DateTime FirstDayOfMonth_NewMethod(this DateTime value)
        //{
        //    return new DateTime(value.Year, value.Month, 1);
        //}

        //public static DateTime LastDayOfMonth_AddMethod(this DateTime value)
        //{
        //    return value.FirstDayOfMonth_AddMethod().AddMonths(1).AddDays(-1);
        //}

        //public static DateTime LastDayOfMonth_AddMethodWithDaysInMonth(this DateTime value)
        //{
        //    return value.Date.AddDays(DateTime.DaysInMonth(value.Year, value.Month) - value.Day);
        //}

        //public static DateTime LastDayOfMonth_SpecialCase(this DateTime value)
        //{
        //    return value.AddDays(DateTime.DaysInMonth(value.Year, value.Month) - 1);
        //}

        //public static int DaysInMonth(this DateTime value)
        //{
        //    return DateTime.DaysInMonth(value.Year, value.Month);
        //}

        //public static DateTime LastDayOfMonth_NewMethod(this DateTime value)
        //{
        //    return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        //}

        //public static DateTime LastDayOfMonth_NewMethodWithReuseOfExtMethod(this DateTime value)
        //{
        //    return new DateTime(value.Year, value.Month, value.DaysInMonth());
        //}

        //2257 ms for FirstDayOfMonth_AddMethod()
        //2406 ms for FirstDayOfMonth_NewMethod()
        //6342 ms for LastDayOfMonth_AddMethod()
        //4037 ms for LastDayOfMonth_AddMethodWithDaysInMonth()
        //4160 ms for LastDayOfMonth_NewMethod()
        //4212 ms for LastDayOfMonth_NewMethodWithReuseOfExtMethod()
        //2491 ms for LastDayOfMonth_SpecialCase()

        //void Main()
        //{
        //    Random rnd = new Random();
        //    DateTime[] sampleData = new DateTime[10000000];

        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        sampleData[i] = new DateTime(1970, 1, 1).AddDays(rnd.Next(0, 365 * 50));
        //    }

        //    GC.Collect();
        //    System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].FirstDayOfMonth_AddMethod();
        //    }
        //    string.Format("{0} ms for FirstDayOfMonth_AddMethod()", sw.ElapsedMilliseconds).Dump();

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].FirstDayOfMonth_NewMethod();
        //    }
        //    string.Format("{0} ms for FirstDayOfMonth_NewMethod()", sw.ElapsedMilliseconds).Dump();

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].LastDayOfMonth_AddMethod();
        //    }
        //    string.Format("{0} ms for LastDayOfMonth_AddMethod()", sw.ElapsedMilliseconds).Dump();

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].LastDayOfMonth_AddMethodWithDaysInMonth();
        //    }
        //    string.Format("{0} ms for LastDayOfMonth_AddMethodWithDaysInMonth()", sw.ElapsedMilliseconds).Dump();

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].LastDayOfMonth_NewMethod();
        //    }
        //    string.Format("{0} ms for LastDayOfMonth_NewMethod()", sw.ElapsedMilliseconds).Dump();

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].LastDayOfMonth_NewMethodWithReuseOfExtMethod();
        //    }
        //    string.Format("{0} ms for LastDayOfMonth_NewMethodWithReuseOfExtMethod()", sw.ElapsedMilliseconds).Dump();

        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        sampleData[i] = sampleData[i].FirstDayOfMonth_AddMethod();
        //    }

        //    GC.Collect();
        //    sw.Restart();
        //    for (int i = 0; i < sampleData.Length; i++)
        //    {
        //        DateTime test = sampleData[i].LastDayOfMonth_SpecialCase();
        //    }
        //    string.Format("{0} ms for LastDayOfMonth_SpecialCase()", sw.ElapsedMilliseconds).Dump();

        //}
    }
}
