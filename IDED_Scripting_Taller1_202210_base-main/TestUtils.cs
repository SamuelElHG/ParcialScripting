using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    internal static class TestUtils
    {
        internal static void Populate<T>(ref Stack<T> stack, T[] elements)
        {
            if (stack == null)
            {
                stack = new Stack<T>();
            }

            for (int i = 0; i < elements.Length; i++)
            {
                stack.Push(elements[i]);
            }
        }

        internal static void Populate<T1, T2>(this IDictionary<T1, T2> dict, T1[] keys, T2[] values)
        {
            if (keys == null || values == null || keys.Length != values.Length)
            {
                return;
            }

            for (int i = 0; i <= keys.Length; i++)
            {
                dict.TryAdd(keys[i], values[i]);
            }
        }

        internal static void Populate<T>(ref Queue<T> queue, T[] elements)
        {
            if (queue == null)
            {
                queue = new Queue<T>();
            }

            for (int i = 0; i < elements.Length; i++)
            {
                queue.Enqueue(elements[i]);
            }
        }

        internal static void InitializeQueueCollection<T>(this Queue<T>[] collection, int lenght)
        {
            if (collection == null)
            {
                collection = new Queue<T>[lenght];
            }

            for (int i = 0; i < collection.Length; i++)
            {
                collection[i] = new Queue<T>();
            }
        }

        internal static bool HasSameElementsAtIndeces<T>(this Queue<T> sourceCollection, Queue<T> targetCollection)
        {
            bool result = sourceCollection?.Count == targetCollection?.Count;

            if (result)
            {
                for (int i = 0; i < sourceCollection.Count; i++)
                {
                    result = sourceCollection.ElementAt(i).Equals(targetCollection.ElementAt(i));

                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        internal static bool HasSameElementsAtIndeces<T1, T2>(this IDictionary<T1, T2> sourceDict, IDictionary<T1, T2> targetDict)
        {
            bool result = sourceDict.Count == targetDict.Count;

            if (result)
            {
                for (int i = 0; i < sourceDict.Count; i++)
                {
                    result = sourceDict.ElementAt(i).Equals(targetDict.ElementAt(i));

                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        internal static bool HasSameElementsAtIndeces<T>(this Stack<T> sourceStack, Stack<T> targetStack)
        {
            bool result = sourceStack.Count == targetStack.Count;

            if (result)
            {
                for (int i = 0; i < sourceStack.Count; i++)
                {
                    result = sourceStack.ElementAt(i).Equals(targetStack.ElementAt(i));

                    if (!result)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}