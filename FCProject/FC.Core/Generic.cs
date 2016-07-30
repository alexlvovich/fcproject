using System;
using System.Collections;
using System.Collections.Specialized;

namespace FC
{
    /// <summary>
    /// Generic conver methods that perform conversion to T class 
    /// By Alexander Lvovich @ 25/12/2013
    /// </summary>
    public static class Generic
    {
        /// <summary>
        /// Covert item in name value collection by key, if null set default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T Turn<T>(NameValueCollection container, string key, T defaultVal)
        {
            return (string.IsNullOrEmpty(key) || null == container) ? defaultVal : Turn<T>(container[key], defaultVal);
        }

        /// <summary>
        /// convert, if object is null set default for the T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T Turn<T>(object o)
        {
            return Turn(o, default(T));
        }

        /// <summary>
        /// Convert, if null set default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T Turn<T>(object o, T defaultVal)
        {
            try
            {
                return o == null ? defaultVal : (T)Convert.ChangeType(o, typeof(T));
            }
            catch
            {
                return defaultVal;
            }
        }

        public static T Turn<T>(Hashtable hashtable, string key, T defaultVal)
        {
            return (string.IsNullOrEmpty(key) || null == hashtable || !hashtable.ContainsKey(key)) ? defaultVal : Turn<T>(hashtable[key], defaultVal);
        }

    }
}
