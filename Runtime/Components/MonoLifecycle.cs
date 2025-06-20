using UnityEngine;

namespace Core.Lifecycle
{
    public class MonoLifecycle : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void EnsureExists()
        {
            var existing = FindObjectOfType<MonoLifecycle>();
            if (existing != null)
                return;

            var go = new GameObject("[MonoLifecycle]");
            go.AddComponent<MonoLifecycle>();
            DontDestroyOnLoad(go);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            AppLifecycleRegistry.InvokeFocus(hasFocus);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            AppLifecycleRegistry.InvokePause(pauseStatus);
        }

        private void OnApplicationQuit()
        {
            AppLifecycleRegistry.InvokeQuit();
        }

        private void Update()
        {
            AppLifecycleRegistry.InvokeUpdate();
        }
    }
}