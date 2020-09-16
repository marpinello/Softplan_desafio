namespace MainService.Services
{
    using MainService.Contracts;

    /// <summary>
    /// service that implements the contract IExtra.
    /// </summary>
    public class ExtraService : IExtra
    {
        private readonly string projectRepository = "https://github.com/marpinello/Softplan_Desafio";

        /// <summary>
        /// Gets the GIT repository URL.
        /// </summary>
        /// <returns></returns>
        public string ShowMeTheCode()
        {
            return this.projectRepository;
        }
    }
}
