using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Models;

namespace ProductShop.Utilities
{
    public static class JsonParser
    {
        public static T ParseJson<T>(string inputJson)
        {
            var result = JsonConvert.DeserializeObject<T>(inputJson);
            return result;
        }

        public static string GetJson(Object collection, bool isCamelCase, bool isOmitNullableValues = false)
        {
            var jsonOptions = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = isCamelCase == true ?
                NullValueHandling = isOmitNullableValues == true ? NullValueHandling.Ignore : NullValueHandling.Include
            };
            var result = JsonConvert.SerializeObject(collection,jsonOptions);
            return result;
        }
    }
}
