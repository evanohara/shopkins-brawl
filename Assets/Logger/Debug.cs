using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Debug
{
    public static void Log(object message)
    {
        //UnityEngine.Debug.Log(message);
    }
    public static void Log(object message, Object context)
    {
        UnityEngine.Debug.Log(message, context);
    }

    public static void Log(object message, DLogType type = DLogType.Log)
    {
        UnityEngine.Debug.Log("[" + type + "] " + message);
    }
    //Continued for rest of functions & signatures...
}

public enum DLogType
{
    Assert,
    Error,
    Exception,
    Warning,
    System,
    Log,
    AI,
    Audio,
    Content,
    Logic,
    GUI,
    Input,
    Network,
    Physics
}