namespace Core.Models
{
    /// <summary>
    /// Class to store and calculate deposit details for a customer.
    /// The interest rate is set as readonly and is fixed when a deposit is created. It should not change even if the interest rate of a customer type is changed in the future.
    /// </summary>
    internal class DepositDetails
    {
        internal DepositDetails(double amount, int durationInMonths, double interestRate)
        {
            this.Amount = amount;
            this.DurationInMonths = durationInMonths;
            _fixedInterestRate = interestRate;
        }

        private double Amount { get; set; }
        private int DurationInMonths { get; set; }
        private readonly double _fixedInterestRate;

        internal double CalculateReturns()
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
            var r = _fixedInterestRate / 100;
            var n = 1.0;
            var t = DurationInMonths / 12.0;

            double A = P * Math.Pow((1 + (r / n)), (n * t));
            return A;
        }

        internal double CalculateInterest()
        {

            // Interest Earned (I) = A - P;
            var P = Amount;
            var A = CalculateReturns();
            var I = A - P;
            return I;
        }
    }
}