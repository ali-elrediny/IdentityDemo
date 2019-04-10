// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionsExtensions.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Framework.Core.Extensions
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Dynamic;
    using System.Linq;

    #endregion

    /// <summary>
    ///     The enumerable queryable extensions.
    /// </summary>
    public static class CollectionsExtensions
    {
        /// <summary>
        /// The rnd.
        /// </summary>
        private static readonly Random rnd = new Random();

        /// <summary>
        /// Gets the paged.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="pageNum">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// Size of the page.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList{T}"/>.
        /// </returns>
        public static PagedList<T> AsPagedList<T>(this IEnumerable<T> query, int pageNum, int pageSize)
        {
            return new PagedList<T>(query, pageNum, pageSize);
        }

        /// <summary>
        /// The contains all items.
        /// </summary>
        /// <param name="a">
        /// The a.
        /// </param>
        /// <param name="b">
        /// The b.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ContainsAllItems<T>(this List<T> a, List<T> b)
        {
            return !b.Except(a).Any();
        }

        /// <summary>
        /// The get value.
        /// </summary>
        /// <param name="coll">
        /// The coll.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="defaultVal">
        /// The default val.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T GetValue<T>(this NameValueCollection coll, string key, T defaultVal = default(T))
        {
            return coll[key].To(defaultVal);
        }

        /// <summary>
        /// The get value or default.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary.
        /// </param>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <typeparam name="TKey">
        /// </typeparam>
        /// <typeparam name="TValue">
        /// </typeparam>
        /// <returns>
        /// The <see cref="TValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public static TValue GetValueOrDefault<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultValue = default(TValue))
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        /// <summary>
        /// Partitions the IEnumerable to sets of specified size.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int size)
        {
            T[] array = null;
            var count = 0;
            foreach (var item in source)
            {
                if (array == null)
                {
                    array = new T[size];
                }

                array[count] = item;
                count++;
                if (count != size)
                {
                    continue;
                }

                yield return new ReadOnlyCollection<T>(array);
                array = null;
                count = 0;
            }

            if (array == null)
            {
                yield break;
            }

            Array.Resize(ref array, count);
            yield return new ReadOnlyCollection<T>(array);
        }

        /// <summary>
        /// The random select item.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T RandomSelectItem<T>(this List<T> list)
        {
            var r = rnd.Next(list.Count);
            return list[r];
        }

        /// <summary>
        /// The to anonymous object.
        /// </summary>
        /// <param name="this">
        /// The this.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public static object ToAnonymousObject(this IDictionary<string, object> @this)
        {
            var obj = new ExpandoObject();
            var dic = (IDictionary<string, object>)obj;

            foreach (var keyValuePair in @this)
            {
                dic.Add(keyValuePair);
            }

            return dic;
        }

        /// <summary>
        /// The to comma separated string.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToCommaSeparatedString(this List<string> items, string separator = " ,")
        {
            return string.Join(separator, items);
        }

        public static string FormatAsList(this List<string> items)
        {
            string message = "<ul>";
            foreach (var item in items)
            {
                message += "<li>" + item + "</li>";
            }
            message += "</ul>";
            return message;
        }

        /// <summary>
        /// The to dictionary.
        /// </summary>
        /// <param name="list">
        /// The list.
        /// </param>
        /// <typeparam name="TK">
        /// </typeparam>
        /// <typeparam name="TV">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public static IDictionary<TK, TV> ToDictionary<TK, TV>(this IEnumerable<KeyValuePair<TK, TV>> list)
        {
            return list.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        /// <summary>
        /// Withes the key.
        /// </summary>
        /// <typeparam name="TK">
        /// </typeparam>
        /// <typeparam name="TV">
        /// </typeparam>
        /// <param name="kv">
        /// The kv.
        /// </param>
        /// <param name="newKey">
        /// The new key.
        /// </param>
        /// <returns>
        /// The <see cref="KeyValuePair"/>.
        /// </returns>
        public static KeyValuePair<TK, TV> WithKey<TK, TV>(this KeyValuePair<TK, TV> kv, TK newKey)
        {
            return new KeyValuePair<TK, TV>(newKey, kv.Value);
        }

        /// <summary>
        /// Withes the value.
        /// </summary>
        /// <typeparam name="TK">
        /// </typeparam>
        /// <typeparam name="TV">
        /// </typeparam>
        /// <param name="kv">
        /// The kv.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        /// <returns>
        /// The <see cref="KeyValuePair"/>.
        /// </returns>
        public static KeyValuePair<TK, TV> WithValue<TK, TV>(this KeyValuePair<TK, TV> kv, TV newValue)
        {
            return new KeyValuePair<TK, TV>(kv.Key, newValue);
        }

        public static RadioButtonList ToRadioButtonList<T>(this IEnumerable<T> items, Expression<Func<T, object>> dataValueField, Expression<Func<T, object>> dataLabelField, object selectedValue = null)
        {

            return new RadioButtonList(items, dataValueField.GetPropertyName(), dataLabelField.GetPropertyName(), selectedValue);
        }

        public static string GetPropertyName<T>(this Expression<Func<T, Object>> expression)
        {
            if (expression.Body is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

        public static IQueryable<T> IncludeHierarchy<T>(this IQueryable<T> source,
            uint depth, string propertyName) where T : class
        {
            var temp = source;
            for (var i = 1; i <= depth; i++)
            {
                var sb = new StringBuilder();
                for (var j = 0; j < i; j++)
                {
                    if (j > 0)
                    {
                        sb.Append(".");
                    }
                    sb.Append(propertyName);
                }

                var path = sb.ToString();
                temp = temp.Include(path);
            }

            var result = temp;
            return result;
        }
    }
    public sealed class RadioButtonList
    {
        #region Constructs
        public RadioButtonList(IEnumerable items, string dataValueField, string dataLabelField, object selectedValue = null)
        {
            Items = items;
            DataValueField = dataValueField;
            DataLabelField = dataLabelField;
            SelectedValue = selectedValue;
        }

        #endregion Constructs

        #region Property
        public string DataValueField { get; private set; }
        public string DataLabelField { get; private set; }
        public object SelectedValue { get; set; }
        public IEnumerable Items { get; private set; }
        #endregion Property

    }

}