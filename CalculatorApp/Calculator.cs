using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

public class Calculator
{
    private readonly ILogger<Calculator> _logger;

    public Calculator(ILogger<Calculator> logger)
    {
        _logger = logger;
    }
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
                    _logger.LogError("LogError: Cannot Divide By Zero.");
                    throw new DivideByZeroException($"Cannot divide by Zero.");
                }

                    return num1 / num2;
            default:
                {
                    _logger.LogError("LogError: Specified Operation is not Supported.");
                    throw new NotImplementedException($"An error occurred: The specified operation is not supported.");
                }
        }
        
        
    //For Test: Implement String to Double Method since Parameter can only accept (double, double , string)
       
    }
    public double ParseStringToDouble(string input)
    {
        if (!double.TryParse(input, out double result))
        {
            _logger.LogError("LogError: Format shoud be numeric.");
            throw new FormatException($"Invalid input. Please enter numeric values.");
        }
        return result; 
    }
}