using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace C;

internal class Program
{
    private static void Main(string[] args)
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "countries.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            return;
        }

        var lines = File.ReadAllLines(filePath);

        var outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "countries.xlsx");
        SaveToExcel(lines, outputFilePath);

        Console.WriteLine($"Преобразование завершено. Таблица сохранена в {outputFilePath}");
    }

    private static void SaveToExcel(string[] lines, string filePath)
    {
        using var package = new ExcelPackage();

        var worksheet = package.Workbook.Worksheets.Add("Countries");

        var row = 1;
        foreach (var line in lines)
        {
            var formattedLine = ConvertToTabSeparated(line);

            var columns = formattedLine.Split('\t');

            for (var col = 0; col < columns.Length; col++) worksheet.Cells[row, col + 1].Value = columns[col].Trim();
            row++;
        }

        package.SaveAs(new FileInfo(filePath));
    }

    private static string ConvertToTabSeparated(string input)
    {
        var pattern = @"[\s,;:-]+";
        return Regex.Replace(input.Trim(), pattern, "\t");
    }
}