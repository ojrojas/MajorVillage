namespace Identity.Core.Helpers;

public static class TransformString
{
    public static Dictionary<string, string> TransformStringtoDictionary(string dictionaryString)
    {
        Dictionary<string, string> dictionary = new();
        var urls = dictionaryString.Split(",");

        foreach (var dic in urls)
        {
            var value = dic.Split("@");
            if (value[1].Equals("3000"))
                dictionary.Add(value[0], $"http://localhost:{value[1]}");
            else
                dictionary.Add(value[0], $"http://docker.for.mac.localhost:{value[1]}");
        }

        return dictionary;
    }
}