using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;

public class LanguageSupport : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();
            switch (Application.systemLanguage)
            {
                case SystemLanguage.English:
                    LocalizationManager.Language = "English";
                    break;
                case SystemLanguage.Spanish:
                    LocalizationManager.Language = "Spanish";
                    break;
            }
        LocalizationManager.Language = PlayerPrefs.GetString("lang");
    }
    public void Language(string language)
    {
        LocalizationManager.Language = language;//change language
        PlayerPrefs.SetString("lang", language);//set new preference
        PlayerPrefs.Save();
    }
}
