using Android.App;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.Droid.Storage
{
    class AndroidResourcesProvider : IResourcesProvider
    {
        public string GetCountryNameByCode(ushort code)
        {
            string[] countryCodeNameStringPairs = Application.Context.Resources.GetStringArray(Resource.Array.countries_array);

            foreach (string stringPair in countryCodeNameStringPairs)
            {
                string[] splitArray = stringPair.Split(':');

                if (ushort.Parse(splitArray[1]) == code)
                    return splitArray[0];
            }

            return null;
        }
    }
}