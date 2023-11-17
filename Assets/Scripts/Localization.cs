using Agava.YandexGames;
using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    english,
    russian,
    turkish
}

public class Localization : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    private void Awake()
    {
#if UNITY_WEBGL&& !UNITY_EDITOR
        ChangeLanguage();
#endif
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        string language = languageCode switch
        {
            EnglishCode => Language.english.ToString(),
            RussianCode => Language.russian.ToString(),
            TurkishCode => Language.turkish.ToString(),
            _ => Language.english.ToString()
        };

        LeanLocalization.SetCurrentLanguageAll(language);
    }
}
