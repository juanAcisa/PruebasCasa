using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PruebaJson_05
{
    class Program
    {
        static void Main(string[] args)
        {
            {

                // Petición a WEB
                try
                {
                    string fecha = "2019-10-23";
                    string token = "OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";

                    string uri = "";
                    uri += "http://api.sinersis.es/api/products?lastsync=" + fecha + "%2000%3A00%3A00&access_token=" + token;

                    // Crear petición
                    HttpWebRequest solicitud = (HttpWebRequest)WebRequest.Create(uri);
                    solicitud.Method = "GET";
                    solicitud.Accept = "application/vnd.sinersis.api-v2+json";
                    solicitud.ContentType = "application/json";

                    // Obtener respuesta
                    HttpWebResponse respuesta = (HttpWebResponse)solicitud.GetResponse();
                    Stream flujoRespuesta = respuesta.GetResponseStream();
                    var flujoLector = new StreamReader(flujoRespuesta);

                    string cadenaJson = flujoLector.ReadToEnd();

                    var productos = JsonConvert.DeserializeObject<List<Producto>>(cadenaJson);
                    int n = 0;
                    foreach (Producto p in productos)
                    {
                        Console.WriteLine("Secuencia {0}", ++n);
                        Console.WriteLine("El código EAN del producto es: " + p.ean1);
                        Console.WriteLine("El precio venta público del producto es: " + p.pvp);
                        Console.WriteLine("La última fecha actualización del producto es: " + p.lastUpdatedDate);

                        Console.WriteLine("\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



                Console.ReadKey();
            }
        }
        public class Producto
        {
            //[{"ean1":"105","trademark":"DE DIETRICH","model":"DME721Z","gamma":"BLANCA","family":"COCCION","article":"MICROONDAS","type":"GENERICO","subtype":"GENERICO","ean2":"0","pvp":"0.00","pvt":"0.00","active":true,"discontinued":true,"exclusive":false,"creationDate":"2011-06-01","lastUpdatedDate":"2017-03-08","previousEan":"0","web_category":"microondas","web_category_parent1":"hornos y micros","web_category_parent2":"electrodom\u00e9sticos"}]
            public string ean1 { get; set; }
            public string trademark { get; set; }
            public string model { get; set; }
            public string gamma { get; set; }
            public string family { get; set; }
            public string article { get; set; }
            public string type { get; set; }
            public string subtype { get; set; }
            public string ean2 { get; set; }
            public string pvp { get; set; }
            public string pvt { get; set; }
            public bool active { get; set; }
            public bool discontinued { get; set; }
            public bool exclusive { get; set; }
            public DateTime creationDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public string previousEan { get; set; }
            public string web_category { get; set; }
            public string web_category_parent1 { get; set; }
            public string web_category_parent2 { get; set; }
        }
    }
}