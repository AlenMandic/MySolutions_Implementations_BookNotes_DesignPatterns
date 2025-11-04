/*
 THE SINGLETON PATTERN:
Used to ensure a class can only be instantied once, with a global point of access to it. Useful for sharing persistent state.

IMPORTANT NOTE: Static fields and methods belong to the class itself, not object instances of the class. So when we do static SingletonPattern _instance, _instance is the same for every single SingletonPattern class.
 */

namespace SimpleAsyncTaskExample
{
    internal class SingletonPattern
    {
        private static SingletonPattern _instance; // Property which holds the main object reference, of which only 1 should exist

        private Random _random;
        private int _randomNumber;

        // initialize data we might need inside the constructor. In this case a random number to demonstrate the pattern.
        // private SingletonPattern() { } // Private constructor ensures new object instances cannot be instantiated.
        private SingletonPattern()
        {
            _random = new Random();
            _randomNumber = GenerateRandomNumber();
        }

        public int GenerateRandomNumber()
        {
            return _random.Next(10000);
        }

        public int ReturnRandomNumber()
        {
            Console.WriteLine($"Our shared random number is: {_randomNumber}");
            return _randomNumber;
        }

        // Property creates the first instance, and returns the instance. Only has a getter, to retrieve the instance.
        public static SingletonPattern Instance
        {
            get
            {
                if (_instance == null) _instance = new SingletonPattern(); // Initial main instance
                return _instance;
            }
        }

    }
}
