using System;

namespace Final_Project_Files
{
    public class HexadecimalToDecimal : Conversion
    {
        public HexadecimalToDecimal(string name, string definition) : base(name, definition, new HexadecimalInputValidator())
        {
        }

        public override string Change(string input)
        {
           int decimalValue = 0;
           int length = input.Length;

           for(int i = 0; i < length; i++)
           {
            char digitChar = input[i];
            int digit;
            if (char.IsDigit(digitChar))
            {
                digit = digitChar - '0';
            } else if (char.ToUpper(digitChar) >= 'A' && char.ToUpper(digitChar) <= 'F'){
                digit = char.ToUpper(digitChar) - 'A' + 10;
            } else {
                throw new ArgumentException("Invalid input, you can only enter hexadecimal characters");
            }
            int power = length -i -1;

            decimalValue += digit * (int) Math.Pow(16, power);
           }

           return decimalValue.ToString();
        }
    }
}