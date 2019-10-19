using System;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        String json = ("[{\"id\":\"1\",\"correo\":\"alpha@e.com\",\"clave\":\"123456\",\"numero\":\"+1 8XX-307-7455\"}]");
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        Console.WriteLine(jsonObj);
        var numero = jsonObj[0]["numero"].ToString();
        Console.WriteLine(numero);

        Console.ReadKey();
    }
}