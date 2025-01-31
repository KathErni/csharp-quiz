using System.Xml.Serialization;
using NUnit.Framework;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest

{
    
    private Calculator _calculator { get; set; } = null;
    //Setup
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }
    [Test]
    //Testing

    //Successful Executions
    public void Add_Numbers()
    { 
        var result = _calculator.PerformOperation(2,3,"add");
        Assert.AreEqual(5, result);
    }
    [Test]
    public void Subtract_Numbers()
    {
        var result = _calculator.PerformOperation(12, 9, "subtract");
        Assert.AreEqual(3, result);
    }
    [Test]
    public void Multiply_Numbers()
    {
        var result = _calculator.PerformOperation(15, 4, "multiply"); 
        Assert.AreEqual(60, result);
    }
    [Test]
    public void Divide_Numbers()
    {
        var result = _calculator.PerformOperation(30,15, "divide");
        Assert.AreEqual(2, result);

    }
    //With Exceptions
    [Test]
    public void Num2toZero_DivideByZeroException()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(5, 0, "divide"));
        Assert.That(ex.Message, Is.EqualTo("Cannot divide by Zero."));
    }
    [Test]
    public void InputDifferentType_FormatException()
    {
        var ex = Assert.Throws<FormatException>(() => _calculator.ParseStringToDouble("abc"));
        Assert.That(ex.Message, Is.EqualTo("Invalid input. Please enter numeric values."));
    }
    [Test]
    public void OnlySelectedOperation_NotImplementedException()
    {
        var ex = Assert.Throws<NotImplementedException>(() => _calculator.PerformOperation(5, 3, "modulo"));
        Assert.That(ex.Message,Is.EqualTo("An error occurred: The specified operation is not supported."));
    }

}