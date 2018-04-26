using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PocketToot
{
    public static class JsonUtility
    {
        public static T MaybeDeserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (JsonSerializationException e)
            {
                var error = JsonConvert.DeserializeObject<Types.Error>(json);
                if (error != null && error.Message != null)
                    throw new ApiException(error);
                else
                    throw e;
            }
        }
    }
}
