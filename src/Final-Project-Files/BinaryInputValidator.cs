using System;

namespace Final_Project_Files
{
    public class BinaryInputValidator : InputValidator
    {
        public override void validate(string input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] != '0' && input[i] != '1')
                {
                    throw new FormatException("Bad format: input is not a valid binary number");
                }
            }
        }
    }
}