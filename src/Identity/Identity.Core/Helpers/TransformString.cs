namespace Identity.Core.Helpers;

public static class TransformString
{
    public static Dictionary<string, string> TransformStringtoDictionary(string dictionaryString)
    {
        int left = 0, right = 1;
        Dictionary<string, string> dictionary = new();
        var urls = dictionaryString.Split(",");

        foreach (var dic in urls)
        {
            var value = dic.Split("@");
            if (value[right].Equals("3000"))
                dictionary.Add(value[left], $"http://localhost:{value[right]}");
            else
                dictionary.Add(value[left], $"http://docker.for.mac.localhost:{value[right]}");
        }

        return dictionary;
    }
}