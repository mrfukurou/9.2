using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				Console.Write("Введите путь к файлу для считывания: ");
				string fileName = Convert.ToString(Console.ReadLine());
				Console.Write("Введите путь к файлу для записи: ");
				string fileName1 = Convert.ToString(Console.ReadLine());
				StreamReader fileIn = new StreamReader(fileName);
				string text = fileIn.ReadToEnd();
				Console.WriteLine("\nТекст из файла (" + fileName + "): ");
				Console.WriteLine(text);
				fileIn.Close();
				Console.WriteLine("\nТекст записанный в файл (" + fileName1 + "): ");
				using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
				{				
					if (!String.IsNullOrWhiteSpace(fileName1))
					{
						string line;
						while ((line = sr.ReadLine()) != null)
						{
							Console.WriteLine(line + " - " + line.Length);

							FileStream aFile = new FileStream(fileName1, FileMode.OpenOrCreate);
							StreamWriter sw = new StreamWriter(aFile);
							aFile.Seek(0, SeekOrigin.End);
							sw.WriteLine(line+" - "+ line.Length);
							sw.Close();
						}					
					}
					else { throw new Exception(); }
				}
			}
			catch { Console.WriteLine("Некорректный ввод!"); }
		}
	}
}
