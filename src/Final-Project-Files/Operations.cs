using System;
using System.Collections;

namespace Final_Project_Files
{
    public class Operations
    {
        private List<string> operations;
        private string separator;

        public Operations(string separator)
        {
            this.operations = new List<string>();
            this.separator = separator;
        }

        public void AddOperation(string input, string output, int conversion, int error, string errorMessage)
        {
            string operation = "";

            operation += input + separator;
            operation += output + separator;
            operation += conversion.ToString() + separator;
            operation += error.ToString() + separator;
            operation += errorMessage;

            this.operations.Add(operation);
        }

        public void SaveOperations(string filePath)
        {
           
            StreamWriter sw = new StreamWriter(filePath, append: true);

            try
            {
                sw.Write("input" + this.separator);
                sw.Write("output" + this.separator);
                sw.Write("conversion" + this.separator);
                sw.Write("error" + this.separator);
                sw.Write("error_message");

                foreach (string line in this.operations)
                {
                    sw.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                sw.Close();
            }
        }

    }
}