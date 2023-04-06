using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Deserializers;

namespace iComercio.Rest
{
    public class JsonDeserializer : IDeserializer
    {
        static readonly Lazy<JsonDeserializer> lazyInstance =
            new Lazy<JsonDeserializer>(() => new JsonDeserializer());
        readonly JsonSerializerSettings settings;

        public static JsonDeserializer Default
        {
            get { return lazyInstance.Value; }
        }

        public JsonDeserializer()
        {
            settings = new JsonSerializerSettings
            {
                Error = ErrorHandler
            };
        }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, settings);
        }

        void ErrorHandler(object sender, ErrorEventArgs args)
        {
            // Only handle initial error
            if (args.CurrentObject != args.ErrorContext.OriginalObject)
                return;

            //// This was for *my* specific problem. It is not a generic solution!
            //if (args.ErrorContext.Member.ToString() == "Qty" &&
            //    args.ErrorContext.Error.Message.Contains("Could not convert string to integer"))
            //    args.ErrorContext.Handled = true; // Leave null
        }

        /// <summary>
        /// Not used for Json serialization
        /// </summary>
        string IDeserializer.RootElement { get; set; }

        /// <summary>
        /// Not used for Json serialization
        /// </summary>
        string IDeserializer.Namespace { get; set; }

        /// <summary>
        /// Not used for Json serialization
        /// </summary>
        string IDeserializer.DateFormat { get; set; }
    }
}
