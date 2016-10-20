using System;

namespace FC
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T Turn<T>(object o)
        {
            return Turn(o, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T Turn<T>(object o, T defaultVal)
        {
            return o == null ? defaultVal : Generic.Turn<T>(o, defaultVal);
        }

    }
}
