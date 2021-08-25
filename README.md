***Reflection Class Overriding***  will help you to override classes with just single method and name of the function. Just like scripting system in Unity and functions like 
Update , Start , Fixed Update and other Unity functions. Using this library you can call functions with no any references. It is easy to use. First we need to 
add reference to DLL file. In your project you need to creat instance of **<ReflectionOverriding>** class and give it **<System.Reflection.Assembly.GetExecutingAssembly()>**
as input parameter.
Then herit which class you need to overrid functions. You can herit the class with default interface <Behavior> or you can creat your custom interface.
To call your functions you just need to write <SendMessage> method and give it the name of the your functions as string.
Example:
	
``` Csharp
//main class
class Program{
	void Main (){
		ReflectionOverriding re = new ReflectionOverriding(System.Reflection.Assembly.GetExecutingAssembly());
	
		re.Sendmessage("MyFunction");
	}
}
//class 2
class MyClass : Behavior{
	void MyFunction() {
		console.writeline("Hello Function Form MyClass.");
	}
}
	
```
	
If you want to overrid you own interface, First you need to creat your interface, Then herit it with any class you want.
At the start calling you need to set "re.ComponentName" variable to your interface name as string.
Example:
	
``` Csharp
//main class
class Program{
	void Main (){
		ReflectionOverriding re = new ReflectionOverriding(System.Reflection.Assembly.GetExecutingAssembly());
		re.ComponentName = "Myinterface";
		re.Sendmessage("MyFunction");
	}
}
//your interface
interface Myinterface{

}
//class 2
class MyClass : Behavior{
	void MyFunction() {
		console.writeline("Hello Function Form MyClass.");
	}
}
```
