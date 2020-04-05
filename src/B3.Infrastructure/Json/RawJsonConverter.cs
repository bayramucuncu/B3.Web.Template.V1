using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace B3.Infrastructure.Json
{
    public class RawJsonConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return reader.TokenType == JsonToken.Null ? null : JObject.Load(reader).ToString();
            }
            catch
            {
                throw new Exception($"{reader.Path} property has not a valid json format.");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
    }
}