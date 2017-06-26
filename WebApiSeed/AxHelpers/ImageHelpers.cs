using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace WebApiSeed.AxHelpers
{
    public class ImageHelpers
    {
        private const string ImgUrClientId = "";
        public static string UploadImageToImgUr(string base64Data)
        {
            base64Data = base64Data.Replace("data:image/png;base64,", "");
            base64Data = base64Data.Replace("data:image/jpeg;base64,", "");
            base64Data = base64Data.Replace("data:image/jpg;base64,", "");
            base64Data = base64Data.Replace("data:image/gif;base64,", "");
            var auth = "Client-ID " + ImgUrClientId;

            var client = new RestClient("https://api.imgur.com/3/image");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", auth);
            request.AddHeader("Accept", "application/json");

            request.AddParameter("image", base64Data);
            request.AddParameter("type", "base64");

            var response = client.Execute(request);
            if (response.ResponseStatus != ResponseStatus.Completed) throw new Exception("Could not upload image to imgur. Try again!!");

            var res = JsonConvert.DeserializeObject<ImgUrResultObj>
                (response.Content);
            if (!res.Success) throw new Exception("Could not upload image to imgur. Try again!!");

            return res.Data.Link;
        }
    }

    public class ImgUrResultObj
    {
        public ImgUrResultData Data { get; set; }
        public string Status { get; set; }
        public bool Success { get; set; }
    }

    public class ImgUrResultData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
    }
}