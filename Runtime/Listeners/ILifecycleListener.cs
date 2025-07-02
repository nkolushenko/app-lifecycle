#if ENABLE_LIFECYCLE_UPDATE
namespace Core.Lifecycle
{
    public interface ILifecycleListener<T> where T : struct
    {
        void OnEvent(in T data);
    }
}
#endif