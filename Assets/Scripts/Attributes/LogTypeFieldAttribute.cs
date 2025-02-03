using System;

[AttributeUsage(AttributeTargets.Field)]
public class LogTypeFieldAttribute : Attribute
{
    public LogType LogType { get; }

    public LogTypeFieldAttribute(LogType logType)
    {
        LogType = logType;
    }
}
