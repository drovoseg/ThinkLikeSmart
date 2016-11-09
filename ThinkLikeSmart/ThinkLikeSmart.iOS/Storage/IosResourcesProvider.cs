using System.Text.RegularExpressions;
using Foundation;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.iOS.Storage
{
    public class IosResourcesProvider : IResourcesProvider
    {
        public string GetCountryNameByCode(ushort code)
        {
            string stringsList = NSBundle.MainBundle.LocalizedString("countries_array", "");

            Regex regex = new Regex("(.+?):(\\d+),?");

            Match match = regex.Match(stringsList);

            if (!match.Success)
                return null;

            while (match.Success)
            {
                if (int.Parse(match.Groups[2].Value) == code)
                    return match.Groups[1].Value;

                match = match.NextMatch();
            }

            return null;
        }
    }
}