using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class LogRepository
    {
        public void WriteLog(string message)
        {
            Directory.CreateDirectory("DataFiles");
            using (var writer = File.AppendText(@"DataFiles/logs.txt"))
            {
                writer.WriteLine(message);
            }
        }
    }
}
