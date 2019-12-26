using System;
using System.Collections.Generic;
using System.Text;

namespace PluginsScanner
{
    public class ConsoleProgress<T> : IProgress<T>
    {
        private Action<T> _action;

        public ConsoleProgress(Action<T> action)
        {
            _action = action;
        }
        public void Report(T value)
        {
            _action(value);
        }
    }
}
