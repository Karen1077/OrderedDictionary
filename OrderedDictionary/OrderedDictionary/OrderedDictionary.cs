using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OrderedDictionary
{
    public class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> dictionary;
        private readonly List<TKey> keyList;

        public OrderedDictionary()
        {
            dictionary = new Dictionary<TKey, TValue>();
            keyList = new List<TKey>();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var key in keyList)
            {
                yield return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (!dictionary.ContainsKey(item.Key))
            {
                keyList.Add(item.Key);
            }
            dictionary[item.Key] = item.Value;
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (dictionary.ContainsKey(key))
            {
                throw new ArgumentException("Key has already been added.");
            }

            keyList.Add(key);
            dictionary.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }

        public ICollection<TKey> Keys => keyList;

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (!dictionary.ContainsKey(key))
            {
                return false;
            }

            keyList.Remove(key);
            dictionary.Remove(key);

            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public ICollection<TValue> Values => dictionary.Values;

        public TValue this[TKey key]
        {
            get => dictionary[key];
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }

                dictionary[key] = value;
            }
        }

        public void Clear()
        {
            dictionary.Clear();
            keyList.Clear();
        }

        public int Count => dictionary.Count;

        public bool IsReadOnly => false;

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "The array cannot be null.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The index cannot be less than zero.");
            }

            if (arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The index cannot be greater than the length of the array.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The number of elements in the source dictionary is greater than the available space from arrayIndex to the end of the array.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("The destination array is not large enough to store the elements from the source dictionary starting at the specified index.");
            }

            int i = arrayIndex;
            foreach (var key in keyList)
            {
                array[i] = new KeyValuePair<TKey, TValue>(key, dictionary[key]);
                i++;
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!dictionary.Contains(item))
            {
                return false;
            }
            keyList.Remove(item.Key);
            return dictionary.Remove(item.Key);
        }
    }
}