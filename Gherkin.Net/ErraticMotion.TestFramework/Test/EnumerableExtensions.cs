// ---------------------------------------------------------------------------
// (C) 2016 Parkeon Limited.
// 
//  No part of this source code may be reproduced, digitised, stored in a 
//  retrieval system, communicated to the public or caused to be seen or heard 
//  in public, made publicly available or publicly performed, offered for sale 
//  or hire or exhibited by way of trade in public or distributed by way of trade 
//  in any form or by any means, electronic, mechanical or otherwise without the 
//  written permission of Parkeon Limited.
// 
// ---------------------------------------------------------------------------

namespace ErraticMotion.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains extension methods for the <see cref="IEnumerable{T}"/> interface.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs an action for each element in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="source">An IEnumerable to walk.</param>
        /// <param name="action">The action to perform.</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static void ForAll<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source is null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action", "action is null.");
            }

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// Reverses the collection.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="source">An IEnumerable to walk.</param>
        /// <returns>An enumerable collection.</returns>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source is null.");
            }

            var enumerable = source as T[] ?? source.ToArray();
            for (var i = enumerable.Count() - 1; i >= 0; i--)
            {
                yield return enumerable.ElementAt(i);
            }
        }

        /// <summary>
        /// Converts the collection.
        /// </summary>
        /// <typeparam name="T1">The type of each input element in the sequence.</typeparam>
        /// <typeparam name="T2">The type of each output element in the sequence.</typeparam>
        /// <param name="source">An IEnumerable to walk.</param>
        /// <param name="action">The conversion action.</param>
        /// <returns>An enumerable collection.</returns>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static IEnumerable<T2> Convert<T1, T2>(this IEnumerable<T1> source, Func<T1, T2> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "source is null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action", "action is null.");
            }

            return source.Select(action);
        }

        /// <summary>
        /// Performs an action on each element in a sequence using the element's index.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="items">An IEnumerable to walk.</param>
        /// <param name="action">The action to perform.</param>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static void ForIndex<T>(this IEnumerable<T> items, Action<int, T> action)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            var index = 0;
            foreach (var item in items)
            {
                action(index, item);
                index++;
            }
        }

        /// <summary>
        /// Takes from the end of the collection.
        /// </summary>
        /// <typeparam name="T">The type of each element in the sequence.</typeparam>
        /// <param name="items">An IEnumerable to walk.</param>
        /// <param name="count">The number of elements to take.</param>
        /// <returns>An enumerable collection.</returns>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        public static IEnumerable<T> TakeFromEnd<T>(this IEnumerable<T> items, int count)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            var enumerable = items as T[] ?? items.ToArray();
            if (enumerable.Count() <= count)
            {
                foreach (var t in enumerable)
                {
                    yield return t;
                }
            }
            else
            {
                var c = enumerable.Count() - count;
                for (var i = 0; i < count; i++)
                {
                    yield return enumerable.ElementAt(c);
                    c++;
                }
            }
        }

        /// <summary>
        /// <para>
        /// Breaks apart an input sequence into chunks of the given size.
        /// </para>
        /// <para>
        /// If the sequence does not contain enough elements to break evenly,
        /// the last chunk will be less than the given size.
        /// </para>
        /// </summary>
        /// <typeparam name="TSource">The type of the source sequence.</typeparam>
        /// <param name="source">The source sequence.</param>
        /// <param name="chunkSize">The size of each chunk.</param>
        /// <returns>Chunks of data as sequences of lists.</returns>
        /// <exception cref="ArgumentNullException"><c>source</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>chunkSize</c> must be greater than zero.</exception>
        public static IEnumerable<IList<TSource>> Chunk<TSource>(this IEnumerable<TSource> source, int chunkSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", @"source is null.");
            }

            if (chunkSize < 1)
            {
                throw new ArgumentException(@"chunk size must be greater than 0.", "chunkSize");
            }

            return ChunkHelper(source, enumerator => BreakOffChunk(enumerator, chunkSize));
        }

        private static IEnumerable<IList<TSource>> ChunkHelper<TSource>(IEnumerable<TSource> source, Func<IEnumerator<TSource>, IEnumerable<TSource>> chunker)
        {
            using (var enumerator = source.GetEnumerator())
            {
                var currentChunk = chunker(enumerator).ToList();

                while (currentChunk.Any())
                {
                    yield return currentChunk;
                    currentChunk = chunker(enumerator).ToList();
                }
            }
        }

        private static IEnumerable<T> BreakOffChunk<T>(IEnumerator<T> enumerator, int chunkSize)
        {
            for (var i = 0; i < chunkSize && enumerator.MoveNext(); i++)
            {
                yield return enumerator.Current;
            }
        }
    }
}