namespace MaximWeb.Models;

public class TreeSort
{
    private char[] _charsArray;
    public TreeSort(string inputStr)
    {
        _charsArray = inputStr.ToCharArray();
    }
    //простая реализация бинарного дерева
    public class TreeNode
    {
        public TreeNode(char data)
        {
            Data = data;
        }

        //данные
        public char Data { get; set; }

        //левая ветка дерева
        public TreeNode Left { get; set; }

        //правая ветка дерева
        public TreeNode Right { get; set; }

        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        //преобразование дерева в отсортированный массив
        public char[] Transform(List<char> elements = null)
        {
            if (elements == null)
            {
                elements = new List<char>();
            }

            if (Left != null)
            {
                Left.Transform(elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }

    public string Sort()
    {
        var treeNode = new TreeNode(_charsArray[0]);
        for (int i = 1; i < _charsArray.Length; i++)
        {
            treeNode.Insert(new TreeNode(_charsArray[i]));
        }

        return new string(treeNode.Transform());
    }
}
