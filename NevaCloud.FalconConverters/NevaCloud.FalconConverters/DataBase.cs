using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevaCloud.FalconConverters
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
            return Convert.IsDBNull(o) ? defaultVal : Generic.Turn<T>(o, defaultVal);
        }

    }
}
