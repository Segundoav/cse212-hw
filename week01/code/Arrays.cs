public static class Arrays
{
    
    public static double[] MultiplesOf(double number, int length)
    {
        // Create a double array of size 'length'.
        // Loop through each index to calculate multiples.
        // Store 'number' multiplied by(i+1) in each slot.
        // Return the completed array.

        double[] result = new double[length];
        for (int i=0; i< length; i++)
        {
            result[i]= number*(i+1);
        }

        return result; // replace this return statement with your own
    }

    
    public static void RotateListRight(List<int> data, int amount)
    {
        // Calculate the starting index: Count minus amount.
        // Extract the last 'amount' elements using GetRange.
        // Delete those elements from the end using RemoveRange.
        // Insert the extracted block at start (index 0).

        int indexToStart=data.Count-amount;

        List<int> partToMove=data.GetRange(indexToStart, amount);

        data.RemoveRange(indexToStart,amount);

        data.InsertRange(0, partToMove);
    }
}
