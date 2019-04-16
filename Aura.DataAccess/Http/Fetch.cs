using Aura.DataAccess.Http.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Aura.DataAccess.Http
{
    public class Fetch : IFetch
    {
        private readonly string _url;
        private Dictionary<string, string> _headers;

        public Fetch(string url)
        {
            _url = url;
            _headers = new Dictionary<string, string>();
        }

        public string Post(Dictionary<string, string> headers, string body)
        {
            return Upload(headers, body, "POST");
        }

        public string Put(Dictionary<string, string> headers, string body)
        {
            return Upload(headers, body, "PUT");
        }

        public void AddHeader(string key, string value)
        {
            _headers.Add(key, value);
        }

        public string Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            foreach (var header in _headers)
            {
                if (string.Equals(header.Key, "content-type", System.StringComparison.OrdinalIgnoreCase))
                {
                    request.ContentType = header.Value;
                    continue;
                }

                request.Headers.Add(header.Key, header.Value);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private string Upload(Dictionary<string, string> headers, string body, string method)
        {
            using (var client = new WebClient())
            {
                client.Headers = new WebHeaderCollection();

                foreach (var header in headers)
                {
                    client.Headers.Add(header.Key, header.Value);
                }

                return client.UploadString(_url, method, body);
            }
        }
    }
}
