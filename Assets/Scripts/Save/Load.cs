using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private int _startSceneIndex = 1;
    private int _startMoney = 0;
    private int _startSound = 1;

    public int GetScene()
    {
        if (PlayerPrefs.HasKey(Save.SceneNumber))
            return PlayerPrefs.GetInt(Save.SceneNumber);

        return _startSceneIndex;
    }

    public int GetMoney()
    {
        if (PlayerPrefs.HasKey(Save.Money))
            return PlayerPrefs.GetInt(Save.Money);

        return _startMoney;
    }

    public int GetSound()
    {
        if (PlayerPrefs.HasKey(Save.Sound))
            return PlayerPrefs.GetInt(Save.Sound);

        return _startSound;
    }
}
