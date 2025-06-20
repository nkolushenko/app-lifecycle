using System.Collections.Generic;

namespace Core.Lifecycle
{
    public static class AppLifecycleRegistry
    {
        private static readonly List<IOnApplicationFocusedListener> _focus = new();
        private static readonly List<IOnApplicationPausedListener> _pause = new();
        private static readonly List<IOnApplicationQuitListener> _quit = new();
        private static readonly List<IUpdateListener> _update = new();

        public static void Register(IOnApplicationFocusedListener listener)
        {
            if (!_focus.Contains(listener))
            {
                _focus.Add(listener);
            }
        }

        public static void Register(IOnApplicationPausedListener listener)
        {
            if (!_pause.Contains(listener))
            {
                _pause.Add(listener);
            }
        }

        public static void Register(IOnApplicationQuitListener listener)
        {
            if (!_quit.Contains(listener))
            {
                _quit.Add(listener);
            }
        }

        public static void Register(IUpdateListener listener)
        {
            if (!_update.Contains(listener))
            {
                _update.Add(listener);
            }
        }

        public static void Unregister(IOnApplicationFocusedListener listener) => _focus.Remove(listener);
        public static void Unregister(IOnApplicationPausedListener listener) => _pause.Remove(listener);
        public static void Unregister(IOnApplicationQuitListener listener) => _quit.Remove(listener);
        public static void Unregister(IUpdateListener listener) => _update.Remove(listener);

        public static void InvokeFocus(bool hasFocus)
        {
            for (int i = 0; i < _focus.Count; i++)
            {
                _focus[i]?.OnApplicationFocused(hasFocus);
            }
        }

        public static void InvokePause(bool isPaused)
        {
            for (int i = 0; i < _pause.Count; i++)
            {
                _pause[i]?.OnApplicationPaused(isPaused);
            }
        }

        public static void InvokeQuit()
        {
            for (int i = 0; i < _quit.Count; i++)
            {
                _quit[i]?.OnApplicationQuit();
            }
        }

        public static void InvokeUpdate()
        {
            for (int i = 0; i < _update.Count; i++)
            {
                _update[i]?.OnUpdate();
            }
        }
        
        public static void ClearAll()
        {
            _focus.Clear();
            _pause.Clear();
            _quit.Clear();
            _update.Clear();
        }
    }
}

