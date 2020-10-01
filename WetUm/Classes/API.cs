using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WetUm
{
    public class API
    {
        static API()
        {
            lang = "en";
        }

        #region Свойства
        private static string _apikey;
        /// <summary>
        /// API ключ
        /// </summary>
        public static string Key
        {
            set { _apikey = value; }
        }
        public static string lang { get; set; }

        /// <summary>
        /// Единицы измерения
        /// </summary>
        public static string units { get; set; }
        #endregion

        /// <summary>
        /// Возвращает JSON строку при заранее заданом API ключе
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="part">Исключённые разделы данных</param>
        /// <returns>JSON</returns>
        public static string GetJSON(string lat, string lon, string part)
        {
            WebClient web = new WebClient();
            string json = Encoding.UTF8.GetString(web.DownloadData($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude={part}&appid={_apikey}&units={units}&lang={lang}"));
            return json;
        }

        #region Перегрузки
        /// <summary>
        /// Возвращает JSON строку при заранее заданом API ключе
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <returns>JSON</returns>
        public static string GetJSON(string lat, string lon)
        {
            return GetJSON(lat, lon, "");
        }
        /// <summary>
        /// Возвращает JSON строку
        /// </summary>
        /// <param name="lat">Широта</param>
        /// <param name="lon">Долгота</param>
        /// <param name="part">Исключённые разделы данных</param>
        /// <param name="ApiKey">Задаёт API ключ</param>
        /// <returns>JSON</returns>
        public static string GetJSON(string lat, string lon, string part, string ApiKey)
        {
            Key = ApiKey;
            return GetJSON(lat, lon, part);
        }
        #endregion
    }
}
