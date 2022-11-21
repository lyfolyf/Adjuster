using System;

namespace Adjuster.Tools
{
    public interface ILog
    {
        event Action<string> Info;
        event Action<string> Warn;
        event Action<string> Error;
    }
}
