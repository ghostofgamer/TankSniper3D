using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public int Get(string name, int number)
    {
        if (PlayerPrefs.HasKey(name))
            return PlayerPrefs.GetInt(name);

        return number;
    }

    public float Get(string name, float number)
    {
        if (PlayerPrefs.HasKey(name))
            return PlayerPrefs.GetFloat(name);

        return number;
    }

    public void ResetLoad()
    {
        PlayerPrefs.GetFloat(Save.Money);
        PlayerPrefs.GetFloat(Save.ProgressSlider);
        PlayerPrefs.GetFloat(Save.ProgressLevel);
        PlayerPrefs.GetFloat(Save.Level);
        PlayerPrefs.GetFloat(Save.Tank);
        PlayerPrefs.GetFloat(Save.Enviropment);
        PlayerPrefs.GetFloat(Save.Map);
    }
}
