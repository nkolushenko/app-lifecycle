#if ENABLE_LIFECYCLE_UPDATE
using UnityEngine;

namespace Core.Lifecycle
{
    public class MonoLifecycle : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap()
        {
            if (FindObjectOfType<MonoLifecycle>() != null)
            {
                return;
            }

            var go = new GameObject("[MonoLifecycle]");
            DontDestroyOnLoad(go);
            
            go.AddComponent<MonoLifecycle>();
        }

#if ENABLE_LIFECYCLE_UPDATE
        private void Update()
        {
            if (AppLifecycleRegistry<FrameUpdate>.HasSubscribers)
            {
                AppLifecycleRegistry<FrameUpdate>.Raise(new FrameUpdate());
            }
        }
#endif

#if ENABLE_LIFECYCLE_PAUSE
        private void OnApplicationPause(bool pause)
        {
            if (AppLifecycleRegistry<ApplicationPause>.HasSubscribers)
            {
                AppLifecycleRegistry<ApplicationPause>.Raise(new ApplicationPause(pause));
            }
        }
#endif

#if ENABLE_LIFECYCLE_FOCUS
        private void OnApplicationFocus(bool hasFocus)
        {
            if (AppLifecycleRegistry<ApplicationFocus>.HasSubscribers)
            {
                AppLifecycleRegistry<ApplicationFocus>.Raise(new ApplicationFocus(hasFocus));
            }
        }
#endif

#if ENABLE_LIFECYCLE_QUIT
        private void OnApplicationQuit()
        {
            if (AppLifecycleRegistry<ApplicationQuit>.HasSubscribers)
            {
                AppLifecycleRegistry<ApplicationQuit>.Raise(new ApplicationQuit());
            }
        }
#endif
    }
}
#endif