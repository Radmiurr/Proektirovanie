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
        // ������� ������ �� �����
        string[] numbers = input.Split(separator);

        // ��������� ������� ���������� ��������
        foreach (string number in numbers)
        {
            if (!int.TryParse(number, out _))
            {
                throw new ArgumentException("������ �������� ���������� �������.");
            }
        }

        // ���������� ����� ������ 10
        numbers = numbers.Where(n => int.Parse(n) <= 10).ToArray();

        // ����� ������ ������ 5 �����
        numbers = numbers.Take(5).ToArray();

        // ��������� ������� ������������� �����
        if (numbers.Any(n => int.Parse(n) < 0))
        {
            return 0;
        }

        // ���������� �����
        int sum = 0;
        foreach (string number in numbers)
        {
            sum += int.Parse(number);
        }

        return sum;
    }
}