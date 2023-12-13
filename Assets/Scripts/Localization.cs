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
    [SerializeField] private LeanLocalization _leanLanguage;

    //private const string EnglishCode = "en";
    //private const string RussianCode = "ru";
    //private const string TurkishCode = "tr";

    private const string EnglishCode = "English";
    private const string RussianCode = "Russian";
    private const string TurkishCode = "Turkish";

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ChangeLanguage();
#endif
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case "en":
                _leanLanguage.SetCurrentLanguage("English");
                break;
            case "tr":
                _leanLanguage.SetCurrentLanguage("Turkish");
                break;
            case "ru":
                _leanLanguage.SetCurrentLanguage("Russian");
                break;
        }
        //switch (languageCode)
        //{
        //    case "en":
        //        _leanLanguage.SetCurrentLanguage("English");
        //        break;
        //    case "tr":
        //        _leanLanguage.SetCurrentLanguage("Turkish");
        //        break;
        //    case "ru":
        //        _leanLanguage.SetCurrentLanguage("Russian");
        //        break;
        //}

        //string language = languageCode switch
        //{
        //    EnglishCode => Language.english.ToString(),
        //    RussianCode => Language.russian.ToString(),
        //    TurkishCode => Language.turkish.ToString(),
        //    _ => Language.english.ToString()
        //};
        //_leanLanguage.SetCurrentLanguage(language);
        //LeanLocalization.SetCurrentLanguageAll(language);
    }
}