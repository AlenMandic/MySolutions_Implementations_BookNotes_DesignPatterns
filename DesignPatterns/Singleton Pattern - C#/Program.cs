using SimpleAsyncTaskExample;
using SimpleAsyncTaskExample.AbstractClasses_Interfaces;
using SimpleAsyncTaskExample.TestingFolder1;

class Program
{    
    public static async Task<int> GetWebPageLengthAsync(string endpoint)
    {
        var client = new HttpClient();
        var uri = new Uri(endpoint);

        byte[] WebPageContent = await client.GetByteArrayAsync(uri);
        return WebPageContent.Length;

    }

    public static async Task OutputWebPageLengthAsync()
    {

        int getWebsiteBytes = await GetWebPageLengthAsync("https://github.com/alenmandic");

        Console.WriteLine("Length of my personal Github in bytes: " + getWebsiteBytes.ToString());

    }

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
