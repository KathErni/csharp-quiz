# Coding Activity: Error Handling and Unit Testing in C#

## Objective

To practice implementing error handling and unit testing in C#.

## Activity Description

You will create a simple console application that simulates a basic calculator. This calculator should handle exceptions that might occur during user input and calculation. 

The following operations should be supported: 
- addition
- subtraction
- multiplication
- division

**Exception Handling**

Update the sample code to handle the following scenarios using exception handling:

**Successful Calculation (any operation)**

```
Enter the first number:
10
Enter the second number:
5
Enter the operation (add, subtract, multiply, divide):
add
The result is: 15
Calculation attempt finished.
```

**Invalid Input (non-numeric value in any number)**

```
Enter the first number:
abc
Invalid input. Please enter numeric values.
Calculation attempt finished.
```

**Division by Zero**

```
Enter the first number:
10
Enter the second number:
0
Enter the operation (add, subtract, multiply, divide):
divide
Cannot divide by zero.
Calculation attempt finished.
```

**Unsupported Operation**

```
Enter the first number:
10
Enter the second number:
5
Enter the operation (add, subtract, multiply, divide):
modulo
An error occurred: The specified operation is not supported.
Calculation attempt finished.
```

**Unit Testing**

Create unit tests for the calculator class to verify that the calculations are correct and that exceptions are handled properly.
