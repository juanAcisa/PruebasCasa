using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PruebaJson_04
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                try
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://api.sinersis.es/api/products?limit=5&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ");
                    using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string json = reader.ReadToEnd();

                        var productos1 = JsonConvert.DeserializeObject<List<Producto>>(json);
                        foreach (Producto p in productos1)
                        {
                            Console.WriteLine("El código EAN del producto es: " + p.ean1);
                            Console.WriteLine("El precio venta público del producto es: " + p.pvp);
                            Console.WriteLine("La última fecha actualización del producto es: " + p.lastUpdatedDate);

                            Console.WriteLine("\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //// Petición a WEB - Javier
                //try
                //{
                //    //uri = @"http://api.sinersis.es/api/products?lastsync=2019-10-01%2000%3A00%3A00&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";


                //    HttpWebRequest req = null;
                //    HttpWebResponse res = null;

                //    string url = "http://api.sinersis.es";
                //    if (!url.EndsWith("/"))
                //        url += "/";
                //    url += "api/products";

                //    url += @"?lastsync=2019-10-01%2000%3A00%3A00&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";

                //    if (!url.Contains("http"))
                //        url = "http://" + url;

                //    req = (HttpWebRequest)WebRequest.Create(url);
                //    req.Method = "GET";
                //    req.Accept = "application/json";
                //    req.ContentType = "application/vnd.sinersis.api-v2+json";

                //    res = (HttpWebResponse)req.GetResponse();
                //    Stream responseStream = res.GetResponseStream();
                //    var streamReader = new StreamReader(responseStream);

                //    string txt = streamReader.ReadToEnd();
                //    txt = txt.Replace("\r\n", "");

                //    //XmlDocument xmlDoc = new XmlDocument();
                //    //xmlDoc.LoadXml(txt);

                //    //string xpath = "//def:Plates";

                //    //XmlNode root = xmlDoc.DocumentElement;

                //    //// create ns manager
                //    //XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
                //    //xmlnsManager.AddNamespace("def", "http://www.hikvision.com/ver20/XMLSchema");


                //    //var node = root.SelectSingleNode(xpath, xmlnsManager);

                //    //listadoRegistros = new List<RMD_Grid>();
                //    //foreach (XmlNode childrenNode in node.SelectNodes("//def:Plate", xmlnsManager))
                //    //{
                //    //    try
                //    //    {
                //    //        string carril = childrenNode.SelectSingleNode("def:laneNo", xmlnsManager).InnerText;
                //    //        string lista = childrenNode.SelectSingleNode("def:matchingResult", xmlnsManager).InnerText;
                //    //        string nombreImagen = childrenNode.SelectSingleNode("def:picName", xmlnsManager).InnerText;
                //    //        string numeroMatricula = childrenNode.SelectSingleNode("def:plateNumber", xmlnsManager).InnerText;
                //    //        string pais = childrenNode.SelectSingleNode("def:country", xmlnsManager).InnerText;
                //    //        string posicion = childrenNode.SelectSingleNode("def:direction", xmlnsManager).InnerText;

                //    //        DateTime fechaCaptura = DateTime.ParseExact(childrenNode.SelectSingleNode("def:captureTime", xmlnsManager).InnerText.Substring(0, 15), "yyyyMMddTHHmmss", null);

                //    //        RMD_Grid registroLog = new RMD_Grid();

                //    //        registroLog.Carril = carril;
                //    //        registroLog.Lista = string.IsNullOrEmpty(lista) ? "" : registroLog.ValoresTraducidos[lista];
                //    //        registroLog.NombreImagen = nombreImagen;
                //    //        registroLog.Matricula = numeroMatricula;
                //    //        registroLog.Pais = pais;
                //    //        registroLog.Posicion = string.IsNullOrEmpty(posicion) ? "" : registroLog.ValoresTraducidos[posicion.ToLower()];

                //    //        registroLog.FechaRegistro = fechaCaptura;
                //    //        registroLog.HoraRegistro = fechaCaptura.ToString("HHmmss").NumeroDecimal();

                //    //        registroLog.CodigoDetectorMatricula = dispositivoCamara.CodigoDetectorMatricula;


                //    //        // Campos opcionales, solo visuales
                //    //        registroLog.CDM_DescripcionCamara = dispositivoCamara.Descripcion;
                //    //        registroLog.DLG_DescripcionDelegacion = dispositivoCamara.DLG_DescripcionDelegacion;

                //    //        listadoRegistros.Add(registroLog);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                //Console.ReadKey();
                //return;


                // Petición a WEB
                try
                {
                    string uri = "";
                    //uri += @"http://api.sinersis.es/api/products?lastsync=";
                    //uri += @"2019-10-01%2000%3A00%3A00";
                    //uri += @"&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";
                    uri = @"http://api.sinersis.es/api/products?lastsync=2019-09-01%2000%3A00%3A00&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";

                    // Crear petición
                    HttpWebRequest solicitud = (HttpWebRequest)WebRequest.Create(uri);
                    solicitud.Method = "GET";
                    solicitud.Accept = "application/vnd.sinersis.api-v2+json";
                    solicitud.ContentType = "application/json";


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

    //// Prueba https://stackoverflow.com/questions/9145667/how-to-post-json-to-a-server-using-c
    //try
    //{
    //    string uri = "";
    //    uri += @"http://api.sinersis.es/api/products?limit=5&access_token=OWMxMzRiY2NmMmM5ZWQ3OWRhODgzMWZkODk1ZmQ0NjkzYWIyMTFlMTNlYmU3OWMyMWJjMzhjZTFjYzYyNjAxNQ";


    //    // create a request
    //    HttpWebRequest request = (HttpWebRequest)
    //    WebRequest.Create(uri); request.KeepAlive = false;
    //    request.ProtocolVersion = HttpVersion.Version10;
    //    request.Method = "POST";


    //    // turn our request string into a byte stream
    //    string json = "";
    //    byte[] postBytes = Encoding.UTF8.GetBytes(json);

    //    // this is important - make sure you specify type this way
    //    //request.ContentType = "application/json; charset=UTF-8";
    //    request.Accept = @"application/vnd.sinersis.api-v2+json";
    //    request.ContentType = "application/json";
    //    request.ContentLength = postBytes.Length;
    //    //request.CookieContainer = Cookies;
    //    //request.UserAgent = currentUserAgent;
    //    Stream requestStream = request.GetRequestStream();

    //    // now send it
    //    requestStream.Write(postBytes, 0, postBytes.Length);
    //    requestStream.Close();

    //    // grab te response and print it out to the console along with the status code
    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //    string result;
    //    using (StreamReader rdr = new StreamReader(response.GetResponseStream()))
    //    {
    //        result = rdr.ReadToEnd();
    //    }
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex.Message);
    //}





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