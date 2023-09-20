using System.Security.Cryptography;

namespace Client.Models
{
    public sealed class Summary
    {
        private Summary() { }
        private static Summary? _instance = null;

        private int UserCount = 0;
        private double CumulativeReturns = 0;

        public static Summary GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Summary();
            }

            return _instance;
        }

        public void IncrementUserCount()
        {
            UserCount++;
        }

        public void UpdateCumulativeReturns(double returns)
        {
            CumulativeReturns += returns;
        }

        public void PrintSummary()
        {
            Console.WriteLine($"Summary");
            Console.WriteLine($"-------");
            Console.WriteLine($"Total Number of Users {UserCount}");
            Console.WriteLine($"Total Returns for all users {CumulativeReturns}");
            Console.WriteLine($"-------");
        }
    }
}