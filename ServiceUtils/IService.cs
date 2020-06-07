namespace ServiceUtils
{
    public interface IService
    {
        void OnStart(string[] args);
        void OnStop();
    }
}
