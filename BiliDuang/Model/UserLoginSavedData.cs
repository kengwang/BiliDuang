using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace BiliDuang.Model
{
    public class UserLoginSavedData
    {
        [JsonInclude]
        public List<Cookie> Cookie;
        
        [JsonInclude]
        public string AccessKey;
    }
}