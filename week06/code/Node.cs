public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data) // Ir a la izquierda
        {
            if (Left is null) 
                Left = new Node(value);
            else
                Left.Insert(value);    
                
        }
        else if (value > Data) // Ir a la derecha
        {
            if (Right is null) 
                Right = new Node(value);
            else
                Right.Insert(value);    
        }
        // Si value == Data, no hacemos nada (esto elimina el fallo del 7 duplicado)
    }

    public bool Contains(int value)
    {
        if (value == Data) return true; // Lo encontramos
        if (value < Data) // Buscar a la izquierda
        {
            return Left != null && Left.Contains(value);
        }
        else // Buscar a la derecha
        {
            return Right != null && Right.Contains(value);
        }
    }
    public int GetHeight()
    {
        // Calculamos la altura de los hijos; si no existen, su altura es 0
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Sumamos 1 (por el nodo actual) al máximo de las dos ramas
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}