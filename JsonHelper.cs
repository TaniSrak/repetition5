using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace repetition5
{
    public class JsonHelper //класс для работы с json
    {
        public static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        //сохраняем в файл
        public static void SaveToFile<T>(T obj,  string filePath)
        {
            var json = SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }
        //выгружаем из файла
        public static T LoadFromFile<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return DeserializeObject<T>(json);
        }
    }
}
