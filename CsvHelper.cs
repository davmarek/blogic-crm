using System.Text;

namespace BlogicCRM;

public class CsvHelper
{
    public static string BuildCsv<T>(IEnumerable<T> items, string header, Func<T, string> line)
    {

        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine(header);
        foreach (var item in items)
        {
            csvBuilder.AppendLine(line(item));
        }

        return csvBuilder.ToString();
    }
}