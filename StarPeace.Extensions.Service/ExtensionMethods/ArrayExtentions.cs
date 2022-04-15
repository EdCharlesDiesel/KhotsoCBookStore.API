using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Service.Extensions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Write a program, which creates an array of 20 elements of type integer 
        /// and initializes each of the elements with a value equals to the index 
        /// of the element multiplied by 5. Print the elements to the console.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] IndexMultipliedByFive(this int[] array)
        {
            var newArray = new int[array.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = i * 5;
            }

            return newArray;
        }        
    }
}
