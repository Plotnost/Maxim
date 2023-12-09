namespace MaximWeb.Models;

public class QuickSort
{
    private char[] _charsArray;
    
    public QuickSort(string inputStr)
    {
        _charsArray = inputStr.ToCharArray();
    }

    static void Swap(ref char x, ref char y)
    {
        (x, y) = (y, x);
    }

    int Partition(int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (_charsArray[i] < _charsArray[maxIndex])
            {
                pivot++;
                Swap(ref _charsArray[pivot], ref _charsArray[i]);
            }
        }

        pivot++;
        Swap(ref _charsArray[pivot], ref _charsArray[maxIndex]);
        return pivot;
    }

    char[] QSort(int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return _charsArray;
        }

        var pivotIndex = Partition(minIndex, maxIndex);
        QSort(minIndex, pivotIndex - 1);
        QSort(pivotIndex + 1, maxIndex);

        return _charsArray;
    }

    public string QSort()
    {
        return new string(QSort(0, _charsArray.Length - 1));
    }
    
    
}