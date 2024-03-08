namespace Payment.Api.Helpers;

public class LuhnAlgorithm
{
    public static bool Validate(string number)
    {
        // Check if the input contains only digits
        if (!IsNumeric(number))
        {
            throw new ArgumentException("Card Number must contain only digits.");
        }

        // Convert the input string to an array of integers
        int[] digits = new int[number.Length];
        for (int i = 0; i < number.Length; i++)
        {
            digits[i] = int.Parse(number[i].ToString());
        }

        // Iterate through the digits from right to left, doubling every second digit
        for (int i = digits.Length - 2; i >= 0; i -= 2)
        {
            int doubledDigit = digits[i] * 2;
            digits[i] = doubledDigit > 9 ? doubledDigit - 9 : doubledDigit;
        }

        // Calculate the sum of all digits
        int sum = 0;
        foreach (int digit in digits)
        {
            sum += digit;
        }

        // If the sum is divisible by 10, the input is valid
        return sum % 10 == 0;
    }

    private static bool IsNumeric(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}