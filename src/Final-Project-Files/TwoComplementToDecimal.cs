using System;

namespace Final_Project_Files
{
    public class TwoComplementToDecimal : Conversion
    {
        public TwoComplementToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator())
        {
        }

        public override string Change(string input)
        {
            int number = Int32.Parse(input);

            int n = input.Length;
            bool isNegative = input[0] == '1';
            int result = 0;
            // Definig variables to determine the size of the number and weather it is positive or negative
            
            if(! isNegative)
            {
                for(int i = 0; i < n; i++)
                {
                    int bit = input[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }
                // If the number is not negative then, the conversion is simply donde like this
            } else {
                char[] inverted = new char[n];
                for(int i = 0; i < n; i++)
                {
                    inverted[i] = input[i] == '0' ? '1' : '0';
                }
                // If it is negative, then we must first invert the number like this.

                for(int i = n - 1; i >= 0; i--)
                {
                    if(inverted[i] == '0')
                    {
                        inverted[i] = '1';
                        break;
                    } else {
                        inverted[i] = '0';
                    }
                }
                // Then we change the ones for zeroes and the zeroes for ones in the inverted array.

                for(int i = 0; i < n; i++)
                {
                    int bit = inverted[i] - '0';
                    result += bit * (int)Math.Pow(2, n - i - 1);
                }

                // Finally we only convert the inverted array with the normal method.

                result *= -1;
            }

            return result.ToString();
        }
    }
}