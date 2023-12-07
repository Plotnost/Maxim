﻿using Maxim;

static string SubstringSerching(string inputStr)
{
    string vowels = "aeiouy";
    int fistVowel = -1;
    int lastVowel = -1;
    for (var i = 0; i < inputStr.Length; i++)
    {
        if (vowels.Contains(inputStr[i]))
        {
            if (fistVowel == -1)
            {
                fistVowel = i;
            }
            lastVowel = i;
        }

        if (fistVowel != -1)
        {
            return inputStr.Substring(fistVowel, lastVowel-fistVowel+1);
        }
    }

    return "";
}

var stringHandler = new StringHandler(Console.ReadLine());

if (stringHandler.CheckString())
{
    var doneString = stringHandler.Handling();
    Console.WriteLine(doneString);
    var charCounter = new CharCouter(doneString);
    charCounter.CountChar();
    charCounter.GetCount();
    Console.WriteLine(SubstringSerching(doneString));
}    