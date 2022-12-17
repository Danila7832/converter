using System;
using System.Runtime.ConstrainedExecution;
using Newtonsoft.Json;

namespace Converter
{
    public class FileSaver
    {
        public FileSaver(String filePath, List<Car> cars)
        {
            if (filePath.EndsWith(".json"))
            {
                String json = JsonConvert.SerializeObject(cars);
                File.WriteAllText(filePath, json);
                MainProgramm.exitFlag = true;
            }
            else
            if (filePath.EndsWith(".txt"))
            {
                String strCars = "";
                foreach (Car car in cars) { 
                    strCars += car.ToString() + '\n';
                }

                File.WriteAllText(filePath, strCars);
                MainProgramm.exitFlag = true;
            }
            else
            if (filePath.EndsWith(".xml"))
            {
                System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(typeof(List<Car>));

                using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
                {
                    xml.Serialize(fs, cars);
                }
                MainProgramm.exitFlag = true;
            }
            else
            {
                Console.WriteLine("формат файла не соответствует заданному");
                MainProgramm.exitFlag = true;
            }
        }
    }
}