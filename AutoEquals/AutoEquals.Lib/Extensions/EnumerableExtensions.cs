// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="AutoEquals">
//   AutoEquals Library. Licence: GNU GPL 2.0. No warranty granted, use at your own risk.
// </copyright>
// <summary>
//   Class containing static extension methods for the <see cref="IEnumerable{T}" /> type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AutoEquals.Lib.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class containing static extension methods for the <see cref="IEnumerable{T}"/> type.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// The unsorted sequences equal.
        /// </summary>
        /// <param name="first">
        /// The first.
        /// </param>
        /// <param name="second">
        /// The second.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool UnsortedSequencesEqual(this IEnumerable first, IEnumerable second)
        {
            return UnsortedSequencesEqual(first, second, null);
        }

        /// <summary>
        /// The unsorted sequences equal.
        /// </summary>
        /// <param name="first">
        /// The first.
        /// </param>
        /// <param name="second">
        /// The second.
        /// </param>
        /// <param name="comparer">
        /// The comparer.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// In case any of collections are null.
        /// </exception>
        public static bool UnsortedSequencesEqual(
            this IEnumerable first,
            IEnumerable second,
            IEqualityComparer comparer)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null)
            {
                return false;
            }

            if (second == null)
            {
                return false;
            }

            var counts = new Dictionary<object, int>((IEqualityComparer<object>)comparer);

            foreach (var i in first)
            {
                int c;
                if (counts.TryGetValue(i, out c))
                {
                    counts[i] = c + 1;
                }
                else
                {
                    counts[i] = 1;
                }
            }

            foreach (var i in second)
            {
                int c;
                if (!counts.TryGetValue(i, out c))
                {
                    return false;
                }

                if (c == 1)
                {
                    counts.Remove(i);
                }
                else
                {
                    counts[i] = c - 1;
                }
            }

            return counts.Count == 0;
        }

        /// <summary>
        /// The get collection hash code.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public static int GetCollectionHashCode(this IEnumerable collection)
        {
            unchecked
            {
                return collection.Cast<object>()
                    .Aggregate(0, (current, elem) => (current * 397) ^ (elem != null ? elem.GetHashCode() : 0));
            }
        }
    }
}
