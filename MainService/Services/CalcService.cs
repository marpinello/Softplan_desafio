namespace MainService.Services
{
    using System;
    using MainService.Contracts;

    public class CalcService : ICalc
    {
        private readonly int decimalPlacesToTruncate = 2;
        private readonly decimal interestRate = 0.01M;

        public decimal GetInterestRate()
        {
            return this.interestRate;
        }

        public decimal CalculateFinalAmmount(decimal initialAmmount, int periodInMonths)
        {
            try
            {
                Validate(initialAmmount, periodInMonths);

                var finalAmmount = (double)initialAmmount * Math.Pow((double)(1 + this.interestRate), periodInMonths);

                return TruncateWithDecimalPlaces((decimal)finalAmmount);
            }
            catch (Exception ex)
            {
                // do some logging
                throw ex;
            }
        }

        protected void Validate(decimal initialAmmount, int periodInMonths)
        {
            if (periodInMonths <= 0)
            {
                throw new ArgumentException("Número de meses não pode ser 0 ou inferior");
            }

            if (initialAmmount <= 0)
            {
                throw new ArgumentException("Valor inicial não pode ser 0 ou inferior");
            }
        }

        protected decimal TruncateWithDecimalPlaces(decimal value)
        {
            var truncPart = decimal.Truncate(value);

            var decimalPart = decimal.Truncate((value - truncPart) * (decimal)Math.Pow(10, this.decimalPlacesToTruncate)) /
                                (decimal)Math.Pow(10, this.decimalPlacesToTruncate);

            return truncPart + decimalPart;
        }
    }
}
