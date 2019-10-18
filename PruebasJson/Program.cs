using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace PruebaJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Productos productos;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://api.sinersis.es/api/products?limit=1&access_token=ZTE5MmFiMjAyNzJlMzc1MzZmMjI0M2RjZTRlN2RlYzQwYTUwOGIzNDA4MmYxMjI4YTMwNDUyNzc2YjNjOGFiYw");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                //productos = JsonConvert.DeserializeObject<Productos>(json);
            }
            Console.WriteLine("El código EAN del producto es: " + productos.ean1);
            Console.ReadKey();
        }
    }
    public class Productos
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
        public double pvp { get; set; }
        public double pvt { get; set; }
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
