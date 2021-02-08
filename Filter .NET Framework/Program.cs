using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filter.NET_Framework
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var fileContent = string.Empty;
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Lets find some Bad words!");
            Console.WriteLine("u have to open TXT files!");
            Console.ReadLine();

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\";
                openFile.Filter = "TEXT FILES (*.txt)|*.txt";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = openFile.OpenFile();

                    using(StreamReader read = new StreamReader(fileStream))
                    {
                        fileContent = read.ReadToEnd();
                        foreach(string x in SwearWords.swearWords)
                        {
                            if (fileContent.Contains(x))
                            {
                                Console.WriteLine(" Bad Words in that file: " + x);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Now the actual content is gonna be shown");
                        Console.WriteLine();

                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            Console.WriteLine();
            Console.WriteLine(fileContent);
            Console.ReadLine();
        }
    }
}
