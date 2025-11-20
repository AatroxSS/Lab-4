using System;

public class StackOperations
{
    public delegate void StackOperation<T>(Stack<T> stack, T item);

    public static StackOperation<T> CreatePushOperation<T>()
    {
        return delegate (Stack<T> stack, T item)
        {
            stack.Push(item);
            Console.WriteLine($"Анонімний метод: Додано елемент {item}");
        };
    }

    public static StackOperation<T> CreatePopOperation<T>()
    {
        return (stack, item) =>
        {
            if (stack.Count > 0)
            {
                var popped = stack.Pop();
                Console.WriteLine($"Лямбда-вираз: Видалено елемент {popped}");
            }
            else
            {
                Console.WriteLine("Лямбда-вираз: Стек порожній!");
            }
        };
    }

    public static Action<Stack<T>> CreatePeekOperation<T>()
    {
        return (stack) =>
        {
            if (stack.Count > 0)
            {
                var top = stack.Peek();
                Console.WriteLine($"Верхній елемент: {top}");
            }
            else
            {
                Console.WriteLine("Стек порожній - немає верхнього елемента");
            }
        };
    }
}