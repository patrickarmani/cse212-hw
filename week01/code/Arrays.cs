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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Part 1: Arrays
        // PLAN (step by step):
        // 1) Create a double array with the size "length".
        // 2) Fill each position i of the array with the appropriate multiple:
        //    - The first element (index 0) should be "number" (that is, number * 1).
        //    - The second element (index 1) should be "number * 2", and so on...
        //    - General formula: result[i] = number * (i + 1).
        // 3) Return the array.
        //
        // Notes:
        // - It is assumed that "length" > 0 (as stated in the problem).
        // - The type is double to allow fractional "number" if necessary.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        //return []; // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1) Normalize amount: amount %= data.Count (avoids unnecessary full rotations).
        // 2) If amount == 0, there is nothing to do.
        // 3) Capture the "tail" of size 'amount' at the end of the list.
        // 4) Remove this tail from the end.
        // 5) Insert this tail at the beginning (position 0).

        int n = data.Count;
        amount %= n;
        if (amount == 0) return;

        //tail = last 'amount' elements
        var tail = data.GetRange(n - amount, amount);
        // remove them from the end   
        data.RemoveRange(n - amount, amount);
        // insert them at the beginning
        data.InsertRange(0, tail);
    }
}
