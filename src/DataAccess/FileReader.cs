using System.Collections;
using System.Collections.Generic;
using Intercom.Interfaces;

namespace Intercom.DataAccess
{
    public class FileReader : IFileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;            
        }

        public IList<string> ReadAllLines()
        {
            IList<string> lines = new List<string>();
            string currentLine;  
  
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(_filePath);
            
            while((currentLine = file.ReadLine()) != null)  
            {  
                lines.Add(currentLine);
            }  
            
            file.Close();

            return lines;

        }
    }
}