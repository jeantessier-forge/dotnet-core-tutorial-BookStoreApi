namespace BookStoreApi.Services
{
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteLine Message: {message}");
        }
    }
}
