using System;
using System.Collections.Generic;

namespace skillbox_cs_13.Utils
{
    /// <summary>
    /// Random number generator
    /// </summary>
    public static class Randomizer
    {
        /// <summary>
        /// Random instance
        /// </summary>
        private static readonly Random R = new Random();

        /// <summary>
        /// Gives next int from Min to Max value (inclusive sides)
        /// </summary>
        /// <param name="min">Minimum value (inclusive)</param>
        /// <param name="max">Maximum value (inclusive)</param>
        /// <returns>Random int in defined voundaries</returns>
        public static int Next(int min, int max)
        {
            if (max <= min) return min;
            return R.Next(min, max + 1);
        }

        /// <summary>
        /// Gives random item from given list
        /// </summary>
        /// <param name="list">List to pick item from</param>
        /// <typeparam name="T">Type of item</typeparam>
        /// <returns>Random item of T type</returns>
        public static T Next<T>(List<T> list)
        {
            var rand = Next(0, list.Count - 1);
            return list[rand];
        }
        
        /// <summary>
        /// Gives random item from given array
        /// </summary>
        /// <param name="array">Array to pick item from</param>
        /// <typeparam name="T">Type of item</typeparam>
        /// <returns>Random item of T type</returns>
        public static T Next<T>(T[] array)
        {
            var rand = Next(0, array.Length - 1);
            return array[rand];
        }
    }
}