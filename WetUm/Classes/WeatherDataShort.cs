using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WetUm
{
    /// <summary>
    /// Класс для хранения погодных данных
    /// </summary>
    public class WeatherDataShort
    {
        /// <summary>
        /// Конвертирует JSON строку в WeatherData
        /// </summary>
        /// <param name="jsonData">Входная JSON строка</param>
        /// <returns></returns>
        public static Root Parse(string jsonData)
        {
            Root root = JsonConvert.DeserializeObject<Root>(jsonData.Replace("1h", "lastHour"));
            return root;
        }

        /// <summary>
        /// Класс погодных условий
        /// </summary>
        public class Weather
        {
            /// <summary>
            /// Идентификационный номер погоды
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// Группа погодных параметров
            /// </summary>
            public string main { get; set; }
            /// <summary>
            /// Погодные условия
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// Идентификационный номер иконки
            /// </summary>
            public string icon { get; set; }
        }

        /// <summary>
        /// Дождь
        /// </summary>
        public class Rain
        {
            /// <summary>
            /// Количество выпавших осадков за последний час в миллиметрах
            /// </summary>
            public double lastHour { get; set; }
        }

        /// <summary>
        /// Снег
        /// </summary>
        public class Snow
        {
            /// <summary>
            /// Количество выпавших осадков за последний час в миллиметрах
            /// </summary>
            public double lastHour { get; set; }
        }

        /// <summary>
        /// Текущая погодная информация
        /// </summary>
        public class Current : Notifier
        {
            /// <summary>
            /// Текущее время
            /// </summary>
            public int dt { get; set; }
            /// <summary>
            /// Время восхода
            /// </summary>
            public int sunrise { get; set; }
            /// <summary>
            /// Время заката
            /// </summary>
            public int sunset { get; set; }
            private  double temp;
            /// <summary>
            /// Температура
            /// </summary>
            public double Temp
            {
                get => temp;
                set
                {
                    temp = value;
                    Notify(nameof(Temp));
                }
            }
            /// <summary>
            /// Температура по ощущениям
            /// </summary>
            public double feels_like { get; set; }
            /// <summary>
            /// Атмосферное давление
            /// </summary>
            public int pressure { get; set; }
            /// <summary>
            /// Влажность
            /// </summary>
            public int humidity { get; set; }
            /// <summary>
            /// Атмосферная температура
            /// </summary>
            public double dew_point { get; set; }
            /// <summary>
            /// Полуденный УФ-индекс
            /// </summary>
            public double uvi { get; set; }
            /// <summary>
            /// Облачность в процентах
            /// </summary>
            public int clouds { get; set; }
            /// <summary>
            /// Видимость
            /// </summary>
            public int visibility { get; set; }
            /// <summary>
            /// Скорость ветра
            /// </summary>
            public int wind_speed { get; set; }
            /// <summary>
            /// Порыв ветра
            /// </summary>
            public int wind_gust { get; set; }
            /// <summary>
            /// Направление ветра в градусах
            /// </summary>
            public int wind_deg { get; set; }
            /// <summary>
            /// Погодные условия
            /// </summary>
            public List<Weather> weather { get; set; }
            /// <summary>
            /// Дождь
            /// </summary>
            public Rain rain { get; set; }
            /// <summary>
            /// Снег
            /// </summary>
            public Snow snow { get; set; }
        }

        /// <summary>
        /// Поминутный прогноз
        /// </summary>
        public class Minutely
        {
            /// <summary>
            /// Текущее время
            /// </summary>
            public int dt { get; set; }
            /// <summary>
            /// Количество осадков в миллиметрах
            /// </summary>
            public double precipitation { get; set; }
        }

        /// <summary>
        /// Почасовой прогноз
        /// </summary>
        public class Hourly
        {
            /// <summary>
            /// Время
            /// </summary>
            public int dt { get; set; }
            /// <summary>
            /// Температура
            /// </summary>
            public double temp { get; set; }
            /// <summary>
            /// Температура по ощущениям
            /// </summary>
            public double feels_like { get; set; }
            /// <summary>
            /// Атмосферное давление
            /// </summary>
            public int pressure { get; set; }
            /// <summary>
            /// Влажность
            /// </summary>
            public int humidity { get; set; }
            /// <summary>
            /// Атмосферная температура
            /// </summary>
            public double dew_point { get; set; }
            /// <summary>
            /// Облачность в процентах
            /// </summary>
            public int clouds { get; set; }
            /// <summary>
            /// Видимость
            /// </summary>
            public int visibility { get; set; }
            /// <summary>
            /// Скорость ветра
            /// </summary>
            public double wind_speed { get; set; }
            /// <summary>
            /// Порыв ветра
            /// </summary>
            public int wind_gust { get; set; }
            /// <summary>
            /// Направление ветра в градусах
            /// </summary>
            public int wind_deg { get; set; }
            /// <summary>
            /// Погодные условия
            /// </summary>
            public List<Weather> weather { get; set; }
            /// <summary>
            /// Вероятность выпадения осадков
            /// </summary>
            public double pop { get; set; }
            /// <summary>
            /// Дождь
            /// </summary>
            public Rain rain { get; set; }
            /// <summary>
            /// Снег
            /// </summary>
            public Snow snow { get; set; }
        }

        /// <summary>
        /// Температура
        /// </summary>
        public class Temp
        {
            /// <summary>
            /// Дневная температура
            /// </summary>
            public double day { get; set; }
            /// <summary>
            /// Минимальная температура
            /// </summary>
            public double min { get; set; }
            /// <summary>
            /// Максимальная температура
            /// </summary>
            public double max { get; set; }
            /// <summary>
            /// Ночная температура
            /// </summary>
            public double night { get; set; }
            /// <summary>
            /// Вечерняя температура
            /// </summary>
            public double eve { get; set; }
            /// <summary>
            /// Утренняя температура
            /// </summary>
            public double morn { get; set; }
        }

        /// <summary>
        /// Температура по ощущениям
        /// </summary>
        public class FeelsLike
        {
            /// <summary>
            /// Дневная температура
            /// </summary>
            public double day { get; set; }
            /// <summary>
            /// Ночная температура
            /// </summary>
            public double night { get; set; }
            /// <summary>
            /// Вечерняя температура
            /// </summary>
            public double eve { get; set; }
            /// <summary>
            /// Утренняя температура
            /// </summary>
            public double morn { get; set; }
        }

        /// <summary>
        /// Ежедневный прогноз
        /// </summary>
        public class Daily
        {

            /// <summary>
            /// Текущее время
            /// </summary>
            public int dt { get; set; }
            /// <summary>
            /// Время восхода
            /// </summary>
            public int sunrise { get; set; }
            /// <summary>
            /// Время заката
            /// </summary>
            public int sunset { get; set; }
            /// <summary>
            /// Температура
            /// </summary>
            public Temp temp { get; set; }
            /// <summary>
            /// Температура по ощущениям
            /// </summary>
            public FeelsLike feels_like { get; set; }
            /// <summary>
            /// Атмосферное давление
            /// </summary>
            public int pressure { get; set; }
            /// <summary>
            /// Влажность
            /// </summary>
            public int humidity { get; set; }
            /// <summary>
            /// Атмосферная температура
            /// </summary>
            public double dew_point { get; set; }
            /// <summary>
            /// Скорость ветра
            /// </summary>
            public double wind_speed { get; set; }
            /// <summary>
            /// Порыв ветра
            /// </summary>
            public int wind_gust { get; set; }
            /// <summary>
            /// Направление ветра в градусах
            /// </summary>
            public int wind_deg { get; set; }
            /// <summary>
            /// Погодные условия
            /// </summary>
            public List<Weather> weather { get; set; }
            /// <summary>
            /// Облачность в процентах
            /// </summary>
            public int clouds { get; set; }
            /// <summary>
            /// Вероятность выпадения осадков
            /// </summary>
            public double pop { get; set; }
            /// <summary>
            /// Дождь
            /// </summary>
            public double rain { get; set; }
            /// <summary>
            /// Снег
            /// </summary>
            public double snow { get; set; }
            /// <summary>
            /// Полуденный УФ-индекс
            /// </summary>
            public double uvi { get; set; }
            /// <summary>
            /// Видимость
            /// </summary>
            public int visibility { get; set; }
        }

        /// <summary>
        /// Корень класса
        /// </summary>
        public class Root
        {
            /// <summary>
            /// Ширина
            /// </summary>
            public double lat { get; set; }
            /// <summary>
            /// Долгота
            /// </summary>
            public double lon { get; set; }
            /// <summary>
            /// Часовой пояс
            /// </summary>
            public string timezone { get; set; }
            /// <summary>
            /// Сдвиг в секундах от UTC
            /// </summary>
            public int timezone_offset { get; set; }
            /// <summary>
            /// Текущий прогноз погоды
            /// </summary>
            public Current current { get; set; }
            /// <summary>
            /// Поминутный прогноз погоды
            /// </summary>
            public List<Minutely> minutely { get; set; }
            /// <summary>
            /// Почасовой прогноз погоды
            /// </summary>
            public List<Hourly> hourly { get; set; }
            /// <summary>
            /// Ежедневный прогноз погоды
            /// </summary>
            public List<Daily> daily { get; set; }
        }
    }
}
