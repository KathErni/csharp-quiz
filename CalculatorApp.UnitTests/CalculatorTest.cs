using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest

{

    private Calculator _calculator { get; set; } = null;
    private ILogger<Calculator> _logger;
    //Setup
    [SetUp]
    public void Setup()
    {
        _logger = Mock.Of<ILogger<Calculator>>();
        _calculator = new Calculator(_logger);
    }
    [Test]
    //Testing

    //Successful Executions
    public void Add_Numbers()
    {
        var result = _calculator.PerformOperation(2, 3, "add");
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
        var result = _calculator.PerformOperation(30, 15, "divide");
        Assert.AreEqual(2, result);

    }
    //With Exceptions
    [Test]
    public void Num2toZero_DivideByZeroException()
    {
        var mockLogger_Zero = Mock.Get(_logger);
        var ex = Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(5, 0, "divide"));
        mockLogger_Zero.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("LogError: Cannot Divide By Zero")),
                It.IsAny<DivideByZeroException>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);

        Assert.That(ex.Message, Is.EqualTo("Cannot divide by Zero."));


    }
    [Test]
    public void InputDifferentType_FormatException()
    {
        var mockLogger_Input = Mock.Get(_logger);
        var ex = Assert.Throws<FormatException>(() => _calculator.ParseStringToDouble("abc"));
        mockLogger_Input.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("LogError: Format shoud be numeric.")),
                It.IsAny<FormatException>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);
        Assert.That(ex.Message, Is.EqualTo("Invalid input. Please enter numeric values."));
    }
    [Test]
    public void OnlySelectedOperation_NotImplementedException()
    {
        var mockLogger_Opt = Mock.Get(_logger);
        var ex = Assert.Throws<NotImplementedException>(() => _calculator.PerformOperation(5, 3, "modulo"));
        mockLogger_Opt.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("LogError: Specified Operation is not Supported.")),
                It.IsAny<NotImplementedException>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
            Times.Once);
        Assert.That(ex.Message, Is.EqualTo("An error occurred: The specified operation is not supported."));
    }
  
}