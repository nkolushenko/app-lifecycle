#if ENABLE_LIFECYCLE_UPDATE
namespace Core.Lifecycle
{
    public readonly struct ApplicationPause
    {
        public readonly bool IsPaused;
        public ApplicationPause(bool isPaused) => IsPaused = isPaused;
    }
}
#endif