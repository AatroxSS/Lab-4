using System;
using System.Collections.Generic;

public class Stack<T>
{
    private List<T> items = new List<T>();

    public event EventHandler<StackEventArgs> ItemPushed;
    public event EventHandler<StackEventArgs> ItemPopped;
    public event EventHandler<StackEventArgs> StackEmpty;
    public event EventHandler<StackEventArgs> StackOverflow;

    public int Count => items.Count;

    public void Push(T item)
    {
        items.Add(item);
        OnItemPushed(new StackEventArgs($"Елемент додано до стеку", item, Count));
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            OnStackEmpty(new StackEventArgs("Стек порожній!", null, 0));
            throw new InvalidOperationException("Стек порожній");
        }

        T item = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        OnItemPopped(new StackEventArgs($"Елемент видалено зі стеку", item, Count));

        return item;
    }

    public T Peek()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Стек порожній");
        return items[items.Count - 1];
    }

    public void Clear()
    {
        items.Clear();
        Console.WriteLine("Стек очищено");
    }

    protected virtual void OnItemPushed(StackEventArgs e)
    {
        ItemPushed?.Invoke(this, e);
    }

    protected virtual void OnItemPopped(StackEventArgs e)
    {
        ItemPopped?.Invoke(this, e);
    }

    protected virtual void OnStackEmpty(StackEventArgs e)
    {
        StackEmpty?.Invoke(this, e);
    }

    protected virtual void OnStackOverflow(StackEventArgs e)
    {
        StackOverflow?.Invoke(this, e);
    }
}