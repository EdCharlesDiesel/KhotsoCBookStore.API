using System;

namespace StarPeace.Core
{
    public static class ArrayExtensions
    {
        public static MergeSort(this Array array)
        {
            throw new NotImplementedException();
        }
    }
    
    public static bool CompareTwoArrays(int [] firstArray,int secondArray)
    {
        int[] secondArray = new int[secondArrayLength];
        
        for (int i = 0; i < secondArrayLength; i++)
        {
            secondArray[i] = firstArray[i];
        }

        for (int i = 0; i < firstArrayLength; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                return false;
            }
        }       

        return true;
    }
}
