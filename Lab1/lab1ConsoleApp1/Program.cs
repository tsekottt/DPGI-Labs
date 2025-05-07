/// <summary>
/// Основний клас програми.
/// </summary>
class Program
{
    /// <summary>
    /// Головний метод, з якого починається виконання програми.
    /// </summary>
    /// <param name="args">Аргументи командного рядка.</param>
    static void Main(string[] args)
    {
        Hello.Greet();
    }
}

/// <summary>
/// Клас, який відповідає за виведення привітання.
/// </summary>
class Hello
{
    /// <summary>
    /// Виводить повідомлення "Hello, World!" у консоль.
    /// </summary>
    public static void Greet()
    {
        Console.WriteLine("Hello, World!");
    }
}
