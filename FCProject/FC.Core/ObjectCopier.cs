using Newtonsoft.Json;

namespace FC
{
    public static class ObjectCopier
    {
        public static T Clone<T>(T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            string str = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(str);
        }

    }
}
