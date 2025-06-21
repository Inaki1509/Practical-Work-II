using System;
using System.Collections;

namespace Final_Project_Files
{
    public class Converter
    {

        private List<Conversion> operations;

        public Converter()
        {
            this.operations = new List<Conversion>();

            this.operations.Add(new DecimalToBinary("Binary", "Decimal to binary"));
            this.operations.Add(new DecimalToOctal("Octal", "Decimal to octal"));
            this.operations.Add(new DecimalToHexadecimal("Hexadecimal", "Decimal to hexadecimal"));
            this.operations.Add(new DecimalToTwoComplement("TwoComplement", "Decimal to binary (Two complement)"));
            this.operations.Add(new BinaryToDecimal("Decimal", "Binary to decimal"));
            this.operations.Add(new TwoComplementToDecimal("Decimal", "Binary (Two complement) to decimal"));
            this.operations.Add(new OctalToDecimal("Decimal", "Octal to decimal"));
            this.operations.Add(new HexadecimalToDecimal("Decimal", "Hexadecimal to decimal"));
        }

        public int Exit()
        {
            return this.operations.Count + 1;
        }

        public int GetNumberOperations()
        {
            return this.operations.Count;
        }

        public string PerformConversion(int op, string input, int? bits = null)
        {
            this.operations[op - 1].validate(input);

            if (this.operations[op - 1].NeedBitSize())
            {
                if (bits == null)
                {
                    throw new ArgumentException("You need to specify a bitsize for this operation.");
                }
                return this.operations[op - 1].Change(input, bits.Value);
            }
            return this.operations[op - 1].Change(input);
        }
            
        
    }
}