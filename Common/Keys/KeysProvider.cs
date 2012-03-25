using System.IO;

namespace Common.Keys
{
    public static class KeysProvider
    {
        public static readonly string GooglePlacesApiKey;

        private const string KeyFilePath = @"Keys\googlePlacesApiKey.txt";

        static KeysProvider()
        {
            GooglePlacesApiKey = File.ReadAllText(KeyFilePath);
        }
    }
}
