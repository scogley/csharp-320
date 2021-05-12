using System;

public class MyStack<T>
{
    readonly T[] stack;
    int sp;

    public void Push(T item)
    {
        stack[sp++] = item;
    }

    public T Pop()
    {
        return stack[--sp];
    }
    
    public bool IsEmpty
    {
        get {
            if (stack.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();

        stack.Push(1);
        stack.Push(2);

        while (!stack.IsEmpty)
        {
            int number = stack.Pop();
            Console.WriteLine("Last value popped = {0}", number);
        }

        Console.ReadLine();
    }
}
