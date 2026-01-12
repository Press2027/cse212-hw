public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array that will store the multiples.
        // The size of the array should be equal to the value of 'length'.
        double[] result = new double[length];

        // Step 2: Loop through each position in the array.
        // We will use a for loop that runs from 0 to length - 1.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple for this position.
            // Since i starts at 0, we add 1 so the first value is number * 1.
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array of multiples.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the index where the list should be split.
        // The last 'amount' values will move to the front of the list.
        int splitIndex = data.Count - amount;

        // Step 2: Create a list that contains the last 'amount' elements.
        List<int> endSlice = data.GetRange(splitIndex, amount);

        // Step 3: Create a list that contains the elements from the start up to the split index.
        List<int> startSlice = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list so we can rebuild it.
        data.Clear();

        // Step 5: Add the sliced parts back into the list in rotated order.
        // First add the elements that were at the end.
        data.AddRange(endSlice);

        // Then add the elements that were originally at the beginning.
        data.AddRange(startSlice);
    }
}
