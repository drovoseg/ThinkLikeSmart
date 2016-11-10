using System.Text.RegularExpressions;
using Foundation;
using Tls.ThinkLikeSmart.Common.Storage;

namespace Tls.ThinkLikeSmart.iOS.Storage
{
    public class IosResourcesProvider : IResourcesProvider
    {
        readonly Regex regex = new Regex("(.+?):(\\d+),?");

        public string GetLocalizedCountryNameByCode(ushort code)
        {
            string codeString = code.ToString();
            string stringsList = NSBundle.MainBundle.LocalizedString("countries_array", "");
            
            Match match = regex.Match(stringsList);

            if (!match.Success)
                return null;

            while (match.Success)
            {
                if (match.Groups[2].Value == codeString)
                    return match.Groups[1].Value;

                match = match.NextMatch();
            }

            return null;
        }
    }
}