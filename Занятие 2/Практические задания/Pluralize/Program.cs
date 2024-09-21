using NUnitLite;

namespace Pluralize;

public static class Program
{
    public static void Main(string[] args)
    {
        //Это магия запускает код из Pluralize_Should. В этом файле находятся тесты
        //Что такое тесты мы разберем в следующей теме
        new AutoRun().Execute(args);
    }
}