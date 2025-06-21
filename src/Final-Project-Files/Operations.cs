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

        public void AddOperation(string input, string output, int conversion, int error, string errorMessage, int? bits = null)
        {
            //We add a nullable parameter that is null by defect for the bits
            string operation = "";

            operation += input + separator;
            operation += output + separator;
            operation += conversion.ToString() + separator;
            operation += error.ToString() + separator;
            operation += errorMessage;
            
            if (bits != null)
            {
                operation += separator + bits.Value;
            } // If the bits parameter is not null, then we add them to the operation.

            this.operations.Add(operation);
        }

        public void SaveOperations(string filePath)
        {

            try
            {

                var lines = File.ReadAllLines(filePath).ToList();
                //We read all of the lines of the csv file and add them to a list

                string separator = ",";
                

                for (int i = 0; i < lines.Count; i++)
                {
                    var fields = lines[i].Split(separator);

                    if (fields.Length == 3)
                    {
                        int index = i + 1;
                        // If the number of fields separated by a coma is 3, then the line is a user, and the program remembers its location

                        while (index < lines.Count && lines[index].Contains(";"))
                        {
                            index++;
                        }
                        // Verificamos para cada fila si contiene ";" y luego actualizamos el index de la linea

                        lines.InsertRange(index, this.operations);
                        File.WriteAllLines(filePath, lines);
                        return;

                    }
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
            
        }

        public void IncrementOperationCount(string filePath, string username)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            //We read all of the lines of the csv file and add them to a list
            string separator = ",";

            for (int i = 0; i < lines.Count; i++)
            {
                var fields = lines[i].Split(separator);

                if (fields.Length >= 3 && fields[0] == username)
                {

                    if (int.TryParse(fields[2], out int current))
                    // int.TryParse tries to parse of the field number 3 of the line (operation count) to an int but manages potential errors
                    {
                        current++;
                        fields[2] = current.ToString();
                        lines[i] = string.Join(separator, fields);
                        //We update the operation count by spliting it, identifyingn the count field and then joining it again
                        //with string.Join
                    }
                    break;
                }
            }

            File.WriteAllLines(filePath, lines); // Reescribir el archivo completo


        }

    }
}