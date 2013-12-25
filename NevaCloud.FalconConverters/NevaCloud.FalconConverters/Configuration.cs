using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NevaCloud.FalconConverters
{
    /// <summary>
    /// Config element converters that perform conversion to T class 
    /// By Alexander Lvovich @ 25/12/2013
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetAppConfig<T>(string key)
        {
            return GetAppConfig(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetAppConfig<T>(string key, T defaultVal)
        {
            if (null == ConfigurationManager.AppSettings[key])
                return defaultVal;

            return (string.IsNullOrEmpty(key)) ? defaultVal : Generic.Turn<T>(ConfigurationManager.AppSettings[key], defaultVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionStringConfig(string key)
        {
            return GetConnectionStringConfig(key, default(string));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string GetConnectionStringConfig(string key, string defaultVal)
        {
            if (null == ConfigurationManager.ConnectionStrings[key] || string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[key].ConnectionString))
                return defaultVal;

            return (string.IsNullOrEmpty(key)) ? defaultVal : Generic.Turn<string>(ConfigurationManager.ConnectionStrings[key].ConnectionString, defaultVal);
        }

    }
}
