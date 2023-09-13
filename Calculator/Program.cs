// See https://aka.ms/new-console-template for more information

using Calculator;

Operace operace = new Operace();

Console.WriteLine("Zadejte první číslo: ");
double a = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Zadejte druhé číslo: ");
double b = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Operátor (+,-,*,/): ");
char op = Convert.ToChar(Console.ReadLine());

double result = 0;

switch (op)
{
    case '+':
        result = operace.Add(a, b);
        break;
    case '-':
        result = operace.Minus(a, b);
        break;
    case '*':
        result = operace.Multiply(a, b);
        break;
    case '/':
        result = operace.Divide(a, b);
        break;
    default:
        Console.WriteLine("Špatná operace");
        break;
}

Console.WriteLine($"Výsledek operace: {result}");