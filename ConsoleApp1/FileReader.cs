using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Converter
{
    public class FileReader
    {
        private List<Car> cars = new List<Car>();

        public FileReader(String filePath)
        {
            String fileText = File.ReadAllText(filePath);

            if (filePath.EndsWith(".json"))
            {
               deserializeJson(fileText);
            }
            else
            if (filePath.EndsWith(".txt"))
            {
                deserializeTxt(fileText);
            }
            else
            if (filePath.EndsWith(".xml"))
            {
                deserializeXml(fileText);
            }
            else
            {
                Console.WriteLine("формат файла не соответствует заданному");
                MainProgramm.exitFlag = true;
            }
        }

        private void deserializeJson(String text)
        {
            cars = JsonConvert.DeserializeObject<List<Car>>(text);
        }

        private void deserializeXml(String text)
        {
            System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Car>));

            MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(text));
            cars = (List<Car>)xml.Deserialize(stream);

        }

        private void deserializeTxt(String text)
        {
            text = text.Replace("\r", "");
            String[] values = text.Split(new char[] { '\n' });

            for (int i = 0; i < values.Count() - 1; i++)
            {
                cars.Add(new Car(values[i], values[i + 1], values[i + 2], int.Parse(values[i + 3])));
                i += 3;
            }
        }

        public List<Car> getCars()
        {
            return cars;
        }
    }
}