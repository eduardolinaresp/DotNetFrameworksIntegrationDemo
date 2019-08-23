using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace Genera.App_Code
{
    public class ApiManager
    {
        public ApiManager()
        {

        }
        public static int callApiSchedulesAsync(string nombrepais)
        {

            Pais pais = new Pais();

            pais.Nombre = nombrepais;

            string Apiurl = ConfigurationManager.AppSettings["ApiCrearPais"];

            System.Net.WebClient client = new System.Net.WebClient();

            //client.Headers.Add("content-type", "application/json");//set your header here, you can add multiple headers
            client.Headers[HttpRequestHeader.ContentType] = "application/json";

            //reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented));
            //resByte = webClient.UploadData(this.urlToPost, "post", reqString);
            //resString = Encoding.Default.GetString(resByte);

            string serialisedData = JsonConvert.SerializeObject(pais);

            var response = client.UploadString(Apiurl, "post", serialisedData);

            return 1;
        }
    }
}