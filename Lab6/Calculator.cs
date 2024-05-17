namespace Calculating
{
    class Program
    {
        static void Main(string[] args)
        { 

        }
    }
}
public static class Calculator
{
    public static int SumNumbers(string input, char separator = ',')
    {
        // Разбить строку на числа
        string[] numbers = input.Split(separator);

        // Проверить наличие нецифровых символов
        foreach (string number in numbers)
        {
            if (!int.TryParse(number, out _))
            {
                throw new ArgumentException("Строка содержит нецифровые символы.");
            }
        }

        // Пропустить числа больше 10
        numbers = numbers.Where(n => int.Parse(n) <= 10).ToArray();

        // Взять только первые 5 чисел
        numbers = numbers.Take(5).ToArray();

        // Проверить наличие отрицательных чисел
        if (numbers.Any(n => int.Parse(n) < 0))
        {
            return 0;
        }

        // Рассчитать сумму
        int sum = 0;
        foreach (string number in numbers)
        {
            sum += int.Parse(number);
        }

        return sum;
    }
}