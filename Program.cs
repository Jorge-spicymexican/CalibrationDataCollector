using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;


namespace CalibrationDataCollector
{
    internal static class Program
    {
        private const string filepath = @"C:\Users\jjurado\Documents\Troy\HGP0040A.csv";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //declaration of a boolean variable named end of data
            bool bExelStop = false;

            StreamReader reader = null;

            if (File.Exists(filepath))
            {
                reader = new StreamReader(File.OpenRead(filepath));
                List<string> listA = new List<string>();

                while (!reader.EndOfStream && bExelStop == false)
                {
                    var line = reader.ReadLine();

                    //check if we are at the end of the code if so don't slit
                    //and set boolean variable as true
                    if (line == "log,")
                    {
                        bExelStop = true;
                    }
                    else
                    {
                        var values = line.Split(',');
                        foreach (var item in values)
                        {
                            listA.Add(item);
                        }
                        foreach (var coloumn1 in listA)
                        {
                            Console.WriteLine(coloumn1);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist");
            }
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
