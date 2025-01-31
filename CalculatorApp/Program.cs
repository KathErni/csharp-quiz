namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        //Try the given codes if it'll throw an exception during user input
            try
            {
                Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator();

                double result = calculator.PerformOperation(num1, num2, operation);
                Console.WriteLine($"The result is: {result}");

            }

            //Catch an error that is in the wrong format
            catch (FormatException e )
            {
                Console.WriteLine(e.Message);
            }
            //Catch an error that when a number is divided by zero
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            //Catch an error that invalidates the operation when there is different output
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
            }
        finally
        {
            //Finally to execute last code
            Console.WriteLine("Calculation attempt finished.");
        }

       

    }
   
}