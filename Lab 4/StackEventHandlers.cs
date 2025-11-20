using System;

public class StackEventHandlers
{
    public static void OnItemPushed(object sender, StackEventArgs e)
    {
        Console.WriteLine($"\n[PUSH] {e.Message}");
        Console.WriteLine($"Елемент: {e.Item}, Розмір стеку: {e.CurrentSize}");
    }

    public static void OnItemPopped(object sender, StackEventArgs e)
    {
        Console.WriteLine($"\n[POP] {e.Message}");
        Console.WriteLine($"Елемент: {e.Item}, Розмір стеку: {e.CurrentSize}");
    }

    public static void OnStackEmpty(object sender, StackEventArgs e)
    {
        Console.WriteLine($"\n[УВАГА!] {e.Message}");
        Console.WriteLine("Стек порожній! Неможливо видалити елемент.");
    }

    public static void OnStackActionLogged(object sender, StackEventArgs e)
    {
        Console.WriteLine($"[ЛОГ] {DateTime.Now:HH:mm:ss} - {e.Message}");
    }
}