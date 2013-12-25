using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace NevaCloud.FalconConverters
{
    /// <summary>
    /// Web converters that perform conversion to T class 
    /// By Alexander Lvovich @ 25/12/2013
    /// </summary>
    public static class Web
    {
        #region MEMBERS
        /// <summary>
        /// 
        /// </summary>
        public static HttpContext CurrentContext
        {
            get { return (null != HttpContext.Current) ? HttpContext.Current : null; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static HttpRequest Request
        {
            get { return (null != HttpContext.Current && null != HttpContext.Current.Request) ? HttpContext.Current.Request : null; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static HttpSessionState Session
        {
            get { return (null != HttpContext.Current && null != HttpContext.Current.Session) ? HttpContext.Current.Session : null; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static HttpServerUtility Server
        {
            get { return (null != HttpContext.Current && null != HttpContext.Current.Server) ? HttpContext.Current.Server : null; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static HttpApplicationState Application
        {
            get { return (null != HttpContext.Current && null != HttpContext.Current.Application) ? HttpContext.Current.Application : null; }
        } 
        #endregion

        #region CONTEXT
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetContextItemValue<K, T>(K key, T defaultVal)
        {
            return (null == CurrentContext || null == CurrentContext.Items || 0 == CurrentContext.Items.Count || null == key || key.Equals(default(K))) ? defaultVal : Generic.Turn<T>(CurrentContext.Items[key], defaultVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetContextItemValue<K, T>(string key)
        {
            return GetContextItemValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetContextItemValue(object key, object value)
        {
            if (null != key && null != value && null != Session)
            {
                CurrentContext.Items.Add(key, value);
                return true;
            }
            else
            {
            }
            return false;
        }
        
        #endregion

        #region SESSION
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetSessionValue<T>(string key, T defaultVal)
        {
            return (string.IsNullOrEmpty(key) || null == Session) ? defaultVal : Generic.Turn<T>(Session[key], defaultVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetSessionValue<T>(string key)
        {
            return GetSessionValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetSessionValue(string key, object value)
        {
            if (!string.IsNullOrEmpty(key) && null != value)
            {
                if (null != Session)
                {
                    Session[key] = value;
                    return true;
                }
            }
            else
            {
            }
            return false;
        }
        
        #endregion

        #region APPLICATION
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetApplicationValue<T>(string key, T defaultVal)
        {
            return (string.IsNullOrEmpty(key) || null == Application) ? defaultVal : Generic.Turn<T>(Application[key], defaultVal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetApplicationValue<T>(string key)
        {
            return GetApplicationValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool SetApplicationValue(string key, object value)
        {
            if (!string.IsNullOrEmpty(key) && null != value && null != Application)
            {
                Application.Lock();
                Application[key] = value;
                Application.UnLock();
                return true;
            }
            else
            {
            }
            return false;
        }
        
        #endregion
       
        #region QUERYSTRING
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetRequestQueryValue<T>(string key)
        {
            return GetRequestQueryValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetRequestQueryValue<T>(string key, T defaultVal)
        {
            return Generic.Turn(Request.QueryString, key, defaultVal);
        } 
        #endregion

        #region FORM
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetRequestFormValue<T>(string key)
        {
            return GetRequestFormValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetRequestFormValue<T>(string key, T defaultVal)
        {
            return Generic.Turn(Request.Form, key, defaultVal);
        } 
        #endregion

        #region REQUEST
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetRequestValue<T>(string key)
        {
            return GetRequestValue(key, default(T));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T GetRequestValue<T>(string key, T defaultVal)
        {
            T val = GetRequestFormValue(key, defaultVal);
            if ((null == val) || (null != val && val.Equals(defaultVal)))
                val = GetRequestQueryValue(key, defaultVal);
            return null == val ? defaultVal : val;
        } 
        #endregion

        #region COOKIES

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="val"></param>
        public static void SetCookie(string name, string val)
        {
            SetCookie(name, val, null, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="val"></param>
        /// <param name="expired"></param>
        public static void SetCookie(string name, string val, DateTime expired)
        {
            SetCookie(name, val, expired, string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="val"></param>
        /// <param name="expired"></param>
        /// <param name="domain"></param>
        public static void SetCookie(string name, string val, DateTime? expired, string domain)
        {
            HttpContext context = HttpContext.Current;
            //
            // check if browser supports cookies
            //
            if (!context.Request.Browser.Cookies)
                return;

            HttpCookie cookie = new HttpCookie(name);
            if(expired.HasValue)
                cookie.Expires = expired.Value;
            if (!string.IsNullOrEmpty(domain))
                cookie.Domain = domain;
            cookie.Value = val;

            SaveCookie(name, cookie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cookie"></param>
        private static void SaveCookie(string name, HttpCookie cookie)
        {
            //
            // check if cookie exists
            //
            if (HttpContext.Current.Request.Cookies[name] == null)
                //
                // cookie not exists
                //
                HttpContext.Current.Response.Cookies.Add(cookie);
            else
            {
                //
                // cookie exists - remove it
                //
                HttpContext.Current.Response.Cookies.Remove(name);
                //
                // set a cookie
                //
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// Get cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetCookie<T>(string name)
        {
            return GetCookie(name, default(T));
        }

        /// <summary>
        /// Get cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetCookie<T>(string name, T defaultVal)
        {
            HttpContext context = HttpContext.Current;
            if (context.Request.Cookies[name] != null)
                return Generic.Turn<T>(context.Request.Cookies[name].Value, defaultVal);
            return default(T);
        }

        /// <summary>
        /// Remove cookie
        /// </summary>
        /// <param name="cookieName">cookie name</param>
        public static void RemoveCookie(string name)
        {
            //
            // cookie exists - remove it
            //
            SetCookie(name, string.Empty, DateTime.Now.AddMonths(-1));
        }

        #endregion
    }
}
