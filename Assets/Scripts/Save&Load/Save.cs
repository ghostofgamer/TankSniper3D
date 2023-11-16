using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string Sound = "Sound";
    public const string Map = "Map";
    public const string Enviropment = "Enviropment";
    public const string Tank = "Tank";
    public const string Zebra = "Zebra";
    public const string Winter = "Winter";
    public const string Leopard = "Leopard";
    public const string Color = "Color";

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetData(string name,int number)
    {
        PlayerPrefs.SetInt(name, number);
        PlayerPrefs.Save();
    }
}
