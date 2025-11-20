using System;
public class StackEventArgs : EventArgs
{
    public string Message { get; }
    public object Item { get; }
    public int CurrentSize { get; }

    public StackEventArgs(string message, object item, int currentSize)
    {
        Message = message;
        Item = item;
        CurrentSize = currentSize;
    }
}