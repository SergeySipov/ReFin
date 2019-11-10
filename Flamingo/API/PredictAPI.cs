﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Flamingo.API
{
    class PredictAPI
    {
        private string _event;
        private string _city;
        private string _advancedSearchOptions;
        private string _fileName;

        public PredictAPI(string @event, string city, string fileNameWithoutExtension)
        {
            _event = @event;
            _city = city;
            _fileName = $"{fileNameWithoutExtension}.json";
            _advancedSearchOptions = "";
        }

        public void StartSearch()
        {
            //Авторизация
            //WebRequest request = WebRequest.Create("https://api.predicthq.com/v1/token/");
            //request.Method = "POST";
            //string sName = "Authorization: Basic base64(zB4PpS4zbzY:2JgGw3OWdnLiz78crYz_3q_Js0aZ3cvIYFhodPW773Viwvm5O3v68A)";
            //byte[] byteArray = Encoding.UTF8.GetBytes(sName);
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = byteArray.Length;

            //using (Stream dataStream = request.GetRequestStream())
            //{
            //    dataStream.Write(byteArray, 0, byteArray.Length);
            //}

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.predicthq.com/v1/events/?q=jazz&country=US&active.gte=2019-10-22&active.lte=2019-10-25&active.tz=America/Los_Angeles&sort=rank");
            req.Headers.Add("Authorization: Bearer 3kZgSkhejEg4zgqYVw8xObQQOVi-XvmZLvYbn08N");
            req.Accept = "application/json";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            //resp.Close();
            string text = sr.ReadToEnd();
            sr.Close();
            using (var sw = new StreamWriter("EventsSearchResult.json"))
                sw.Write(text);
        }
    }
}
