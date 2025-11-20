using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ДЕМОНСТРАЦІЯ РОБОТИ СТЕКУ З ПОДІЯМИ ===");

        Stack<int> stack = new Stack<int>();

        stack.ItemPushed += StackEventHandlers.OnItemPushed;
        stack.ItemPopped += StackEventHandlers.OnItemPopped;
        stack.StackEmpty += StackEventHandlers.OnStackEmpty;

        stack.ItemPushed += StackEventHandlers.OnStackActionLogged;
        stack.ItemPopped += StackEventHandlers.OnStackActionLogged;

        DemonstrateEvents(stack);

        Console.WriteLine("\n\n=== ДЕМОНСТРАЦІЯ ЛЯМБДА-ВИРАЗІВ ТА АНОНІМНИХ МЕТОДІВ ===");

        DemonstrateLambdaAndAnonymousMethods();

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }

    static void DemonstrateEvents(Stack<int> stack)
    {
        try
        {
            Console.WriteLine("\n--- Демонстрація подій ---");
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Pop();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static void DemonstrateLambdaAndAnonymousMethods()
    {
        var stack = new Stack<int>();

        var pushOperation = StackOperations.CreatePushOperation<int>();
        var popOperation = StackOperations.CreatePopOperation<int>();
        var peekOperation = StackOperations.CreatePeekOperation<int>();

        Console.WriteLine("\n--- Демонстрація анонімних методів та лямбда-виразів ---");

        pushOperation(stack, 10);
        pushOperation(stack, 20);
        pushOperation(stack, 30);

        popOperation(stack, 0);
        popOperation(stack, 0);

        peekOperation(stack);

        popOperation(stack, 0);
        popOperation(stack, 0);
    }
}