using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class ArrayReversal
{
    public static T[] ReverseArray<T>(T[] array)
    {
        Stack<T> stack = new Stack<T>();

        foreach (T item in array)
        {
            stack.Push(item);
        }

        T[] reversedArray = new T[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            reversedArray[i] = stack.Pop();
        }

        return reversedArray;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] originalArray = { 1, 2, 3, 4, 5 };
        int[] reversedArray = ArrayReversal.ReverseArray(originalArray);

        Console.WriteLine("Original Array: " + string.Join(", ", originalArray));
        Console.WriteLine("Reversed Array: " + string.Join(", ", reversedArray));
        Console.WriteLine("______________________");
        TaskScheduler scheduler = new TaskScheduler();

        scheduler.EnqueueTask(() => Console.WriteLine("Task 1 executed"));
        scheduler.EnqueueTask(() => Console.WriteLine("Task 2 executed"));
        scheduler.EnqueueTask(() => Console.WriteLine("Task 3 executed"));

        Console.WriteLine("Executing tasks...");
        scheduler.ExecuteTasks();
    }
}

class TaskScheduler
{
    private Queue<Action> taskQueue = new Queue<Action>();

    public void EnqueueTask(Action task)
    {
        taskQueue.Enqueue(task);
    }

    public void ExecuteTasks()
    {
        while (taskQueue.Count > 0)
        {
            Action task = taskQueue.Dequeue();
            task.Invoke();
        }
    }
}
