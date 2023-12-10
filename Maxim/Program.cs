using Maxim;

Console.WriteLine("Введите строку для обработки:");
var stringHandler = new StringHandler(Console.ReadLine());

if (stringHandler.CheckString())
{
    //Обработка строки
    var doneString = stringHandler.Handling();
    Console.WriteLine($"Строка после обработки: {doneString}");
    
    //Счёт символов в обработанной строке
    var charCounter = new CharCouter(doneString);
    charCounter.CountChar();
    charCounter.GetCount();
    
    //Поиск наибольшей подстроки ограниченной гласными
    Console.WriteLine(stringHandler.SubstringSerching());
    
    //Сортировка строки
    Console.WriteLine("Выберете вид сортировки(1 - Quick Sort, 2 - Tree Sort): ");
    switch (Console.ReadLine())
    {
        case "1":
            var sortedStrArray = new QuickSort(doneString);
            Console.WriteLine($"Отсортированная строка: {sortedStrArray.QSort()}");
            break;
        case "2":
            var treeSort = new TreeSort(doneString);
            Console.WriteLine($"Отсортированная строка: {treeSort.Sort()}");
            break;
        default:
            Console.WriteLine("Некорректный ввод.");
            break;
    }
    
    //Удаление случайного символа в строке
    var randomDel = new RandomDel(doneString);
    string strWithoutChar = randomDel.DelRandomChar();
    Console.WriteLine($"Строка без одного слуайного символа:{strWithoutChar}");
}