using System.IO;

namespace ShopApp
{
    public static class OutputReport
    {
        public static string CreateReport(string data)
        {
            string path = @"..\..\..\Отчёт.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(data);
                }

                return "Отчёт сформирован в папке проекта, с именем 'Oтчёт.txt'";
            }
            else return "Ошибка создания отчёта";
        }
    }
}