namespace ServiceUtils
{
    /// <summary>
    /// Interface to implement for service
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// The fuction called when service starts
        /// </summary>
        /// <param name="args"></param>
        void OnStart(string[] args);
        /// <summary>
        /// The function called when service stops
        /// </summary>
        void OnStop();
        /// <summary>
        /// A flag to indicate if exe is running in service or console mode
        /// </summary>
        bool ConsoleMode { get; set; }
    }
}
