using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        if (_root == null)
            _root = new Node(value);
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST.
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
    
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            // Para ir en reversa: Derecha, Nodo, Izquierda
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedList)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(bst, sortedList, 0, sortedList.Length - 1);
        return bst; // <--- ESTA LÍNEA ES VITAL. Si no está, el árbol siempre llega vacío.
    }

    private static void InsertMiddle(BinarySearchTree bst, int[] list, int first, int last)
    {
        if (first > last) return;

        int middle = (first + last) / 2;
        bst.Insert(list[middle]);

        InsertMiddle(bst, list, first, middle - 1);
        InsertMiddle(bst, list, middle + 1, last);
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}