using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfo
{
    public string debugMessage;
    public DebugMessageLevel debugMessageLevel;
    public DebugMessageType debugMessageType;
    public static int DebugMessageLevelCount = 6;
    public static int DebugMessageTypeCount = 3;
    public enum DebugMessageLevel
    {
        None = 0,Log = 1,Safe = 2,Warning = 3 ,Error = 4,Bug = 5
    }
    public enum DebugMessageType
    {
        None = 0, LoadData = 1,ActionLoop = 2
    }

    public DebugInfo(string message)
        : this(message, DebugMessageLevel.None, DebugMessageType.None) { }
    public DebugInfo(string message, DebugMessageLevel level)
        : this(message, level, DebugMessageType.None) { }
    public DebugInfo(string message, DebugMessageType type) 
        : this(message, DebugMessageLevel.None, type) { }
    public DebugInfo(string message,DebugMessageLevel level,DebugMessageType type)
    {
        debugMessage = message;
        debugMessageLevel = level;
        debugMessageType = type;
    }
}
