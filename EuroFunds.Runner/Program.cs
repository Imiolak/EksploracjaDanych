namespace EuroFunds.Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader.DataLoader();

            loader.Load();
        }
    }
}
