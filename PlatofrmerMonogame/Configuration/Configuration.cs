using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Engine;

namespace PlatofrmerMonogame.Configs
{
    public class Configuration
    {
        string ScenesPath { get; set; }
        string EntitiesPath { get; set; }

        string ConfigurationPath;

        public Configuration()
        {
            ConfigurationPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Configuration/configuration.json";

            /*string fileName = ScenesPath + currentScene.Name + ".json";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string jsonString = JsonSerializer.Serialize(currentScene, options);
            File.WriteAllText(fileName, jsonString);*/
        }

       
    }
}
