using System.Linq.Expressions;

namespace CalculatorApp;

public class Calculator
{
    //Implement the PerformOperation method
    public double PerformOperation(double num1, double num2, string operation)
    {
      
            switch (operation)
            {
                case "add":
                    return num1 + num2;

                case "subtract":
                    return num1 - num2;
                case "multiply":
                    return num1 * num2;
            case "divide":
                if (num2 == 0)
                {
                    throw new DivideByZeroException($"Cannot divide by Zero.");
                }

                    return num1 / num2;
            default:   
                throw new NotImplementedException($"An error occurred: The specified operation is not supported.");
        }
        
        
    //For Test: Implement String to Double Method since Parameter can only accept (double, double , string)
       
    }
    public double ParseStringToDouble(string input)
    {
        if (!double.TryParse(input, out double result))
        {
            throw new FormatException($"Invalid input. Please enter numeric values.");
        }
        return result; 
    }
}