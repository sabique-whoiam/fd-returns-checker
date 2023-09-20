namespace Core.Models
{
    public class DepositDetails
    {
        public DepositDetails(double amount, int durationInMonths)
        {
            Amount = amount;
            DurationInMonths = durationInMonths;
        }

        private double Amount { get; set; }
        private int DurationInMonths { get; set; }

        public double CalculateReturns(double interestRate)
        {
            /*
                Maturity Amount (A) = P × (1 + r/n)^(n*t)
                Where:
                A = Maturity Amount (the total amount you'll receive after the FD matures)
                P = Principal Amount (the initial deposit)
                r = Annual Interest Rate (in decimal form, e.g., 6% as 0.06)
                n = Number of times interest is compounded per year
                t = Tenure or duration of the FD in years
            */

            var P = Amount;
            var r = interestRate / 100;
            var n = 1.0;
            var t = DurationInMonths / 12.0;

            double A = P * Math.Pow((1 + (r / n)), (n * t));
            return A;
        }

        public double CalculateInterest(double interestRate) 
        {

            // Interest Earned (I) = A - P;
            var P = Amount;
            var A = CalculateReturns(interestRate);
            var I = A  - P;
            return I;
        }
    }
}