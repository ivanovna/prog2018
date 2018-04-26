using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SportGames
{
    public static class SportGamesSerializer
    {
        private static readonly XmlSerializer Xs = new XmlSerializer(typeof(RequestModel));
        public static void WriteToFile(string fileName, RequestModel data)
        {
            using (var fileStream = File.Create(fileName))
            {
                Xs.Serialize(fileStream, data);
            }
        }

        public static RequestModel LoadFromFile(string fileName)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                return (RequestModel)Xs.Deserialize(fileStream);
            }
        }

    }
}

