#if ENABLE_LIFECYCLE_UPDATE
namespace Core.Lifecycle
{
    public readonly struct ApplicationFocus
    {
        public readonly bool HasFocus;
        public ApplicationFocus(bool hasFocus) => HasFocus = hasFocus;
    }
}
#endif