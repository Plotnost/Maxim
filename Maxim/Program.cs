using Maxim;

var stringHandler = new StringHandler(Console.ReadLine());

if (stringHandler.CheckString())
{
    var doneString = stringHandler.Handling();
    Console.WriteLine(doneString);
}    