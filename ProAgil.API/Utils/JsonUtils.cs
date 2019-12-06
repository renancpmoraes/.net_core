using Newtonsoft.Json;

namespace ProAgil.API.Utils
{
    public class JsonUtils
    {
        
        public static string ConvertToJson(object obj) {

            string output = JsonConvert.SerializeObject(obj);  

            return output;
        }
    }
}