using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalisationSystem
{
    
    public enum Language
    {
        English,
        Japanese
    }

    public static Language language = Language.Japanese;

    private static Dictionary<string, string> localisedEN;
    private static Dictionary<string, string> localisedJA;

    public static bool isInit;

    public static void Init()
    {
        CSVLoader csvLoader = new();
        csvLoader.LoadCSV();

        localisedEN = csvLoader.GetDictionaryValue("en");
        localisedJA = csvLoader.GetDictionaryValue("ja");

        isInit = true;

    }

    public static string GetLocalisedValue(string key)
    {
        if (!isInit) { Init(); }

        string value = key;

        switch (language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Japanese:
                localisedJA.TryGetValue(key, out value);
                break;
        }

        return value;
    }
}
