using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class API
    {
        public class Parametros
        {
            public List<string> campos { get; set; }
        }

        public class Provincia
        {
            public string id { get; set; }
            public string nombre { get; set; }
        }

        public class GeoRef
        {
            public int cantidad { get; set; }

            public int inicio { get; set; }

            public Parametros parametros { get; set; }

            public List<Provincia> provincias { get; set; }

            public int total { get; set; }
        }

        public static List<Provincia> GetApi()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            GeoRef geoRef = null;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                geoRef = JsonSerializer.Deserialize<GeoRef>(responseBody);
                            }
                        }
                    }
                }
            }
            catch (WebException)
            {
                throw new Exception("No se pudo acceder a los recursos del servidor.");
            }

            return geoRef.provincias.OrderBy(provincia => provincia.id).ToList();
        }
    }
}