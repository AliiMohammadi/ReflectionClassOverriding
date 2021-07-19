using System;
using System.Reflection;
using ReflectionClassOverriding;

namespace ReflectionClassOverridingSimple
{
    class Program
    {
        static ReflectionOverriding over;

        static void Main(string[] args)
        {
            Simple();
            CustomInterface();

            Console.ReadKey();
        }

        //This is how we call functions using OverridingClass.
        static void Simple()
        {
            over = new ReflectionOverriding(Assembly.GetExecutingAssembly());

            //To call functions from interface, <Use SendMessage()> method.
            over.SendMessage("Start");
            
            over.SendMessage("Update");
        }

        //This is how we call our own interface functions using OverridingClass.
        static void CustomInterface()
        {
            over = new ReflectionOverriding(Assembly.GetExecutingAssembly());

            //If you to use custom interface, after creating you need to set name of your interface in <ComponentName> variable.
            over.ComponentName = "MyInterface";// <MyInterface> is my custom interface name

            //To call functions from your interface, <Use SendMessage()> method.
            over.SendMessage("Start");
            over.SendMessage("Update");
        }
    }
    //This class using default-premade interface from OverridingClass library.
    public class MyClass : Behavior
    {
        void Start()
        {
            Console.WriteLine("Start function from MyClass.");
        }

        void Update()
        {
            Console.WriteLine("Update function from MyClass.");
        }
    }

    //This is our custom interface 
    public interface MyInterface
    {

    }
    public class MyClass2 : MyInterface
    {
        void Start ()
        {
            Console.WriteLine("Start function from MyClass2.");
        }
        
        void Update()
        {
            Console.WriteLine("Update function from MyClass2.");
        }
    }
}
