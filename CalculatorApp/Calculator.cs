using System.Linq.Expressions;

namespace CalculatorApp;

public class Calculator
{
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
                    throw new DivideByZeroException($"Cannot divide by Zero");
                }

                    return num1 / num2;
            }
        
        
        //Implement the PerformOperation method
       

    
        throw new NotImplementedException($"An error occurred: The specified operation is not supported.");
    }
}