namespace MainService.Contracts
{
    /// <summary>
    /// interface for calculation methods.
    /// </summary>
    public interface ICalc
    {
        /// <summary>
        /// Gets the interest rate.
        /// </summary>
        /// <returns></returns>
        decimal GetInterestRate();

        /// <summary>
        /// Calculates the final ammount of a given initial ammount during a period of time.
        /// </summary>
        /// <param name="initialAmmount">the initial ammount.</param>
        /// <param name="periodInMonths">the period in months.</param>
        /// <returns>the calculated final ammount.</returns>
        decimal CalculateFinalAmmount(decimal initialAmmount, int periodInMonths);
    }
}
