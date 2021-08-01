using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvToHtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "oscar_age_male.csv");
            var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "oscar_age_male.html");

            var lines = File.ReadAllLines(filePath);
            if (File.Exists(filePath2)) {
                System.IO.File.WriteAllText(filePath2, "");
            }

            using (var outfs = File.AppendText(filePath2))
            {
                outfs.Write("<!DOCTYPE html><html><head><style> " +
                    "table {font-family: arial, sans-serif;border-collapse:collapse;width:50%;margin: 0 auto;}" +
                    "td, th { border: 1px solid #dddddd;  padding: 8px; text-align: center;} tr:first-child { font-weight: bold }" +
                    "tr:nth-child(even){background-color: #dddddd;}</style></head><body><table> ");
                foreach (var line in lines)
                    outfs.Write("<tr><td>" + string.Join("</td><td>", line.Split(',')) + "</td></tr>");
                outfs.Write("</table></body></html>");
            }
            Console.WriteLine("Plik wejściowy i wyjściowy znajduje się w folderze \\Debug");
        }
    }
}
