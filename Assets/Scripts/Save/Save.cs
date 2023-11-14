using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string Sound = "Sound";

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetScene(int indexScene)
    {
        indexScene++;
        PlayerPrefs.SetInt(SceneNumber, indexScene);
    }

    public void SetMoney(int money)
    {
        PlayerPrefs.SetInt(Money, money);
    }

    public void SetSound(int index)
    {
        PlayerPrefs.SetInt(Sound, index);
    }
}
