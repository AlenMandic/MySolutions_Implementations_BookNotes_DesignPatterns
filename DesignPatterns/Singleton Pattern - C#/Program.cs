
class Program
{    

        static void Main(string[] args)
    {
        var singleton1 = SingletonPattern.Instance;
        var singleton2 = SingletonPattern.Instance;
        var singleton3 = SingletonPattern.Instance;

        // Outputs the same random number for each singleton variable.
        singleton1.ReturnRandomNumber();
        singleton2.ReturnRandomNumber();
        singleton3.ReturnRandomNumber();

        Console.WriteLine(Object.ReferenceEquals(singleton1, singleton2)); // TRUE
        Console.WriteLine(Object.ReferenceEquals(singleton2, singleton3)); // TRUE

    }
}
