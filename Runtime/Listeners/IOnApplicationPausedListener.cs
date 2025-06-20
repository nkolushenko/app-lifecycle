namespace Core.Lifecycle
{
    public interface IOnApplicationPausedListener
    {
        void OnApplicationPaused(bool isPaused);
    }
}