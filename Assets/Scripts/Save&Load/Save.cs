using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string Volume = "Volume";
    public const string Map = "Map";
    public const string Enviropment = "Enviropment";
    public const string Tank = "Tank";
    public const string Level = "Level";
    public const string ProgressLevel = "ProgressLevel";
    public const string ProgressSlider = "ProgressSlider";
    public const string LevelBuy = "LevelBuy";
    public const string CurrentLevel = "CurrentLevel";
    public const string AllTanksOpen = "AllTanksOpen";
    public const string LevelComplited = "LevelComplited";
    public const string Reward = "Reward";
    [Header("Pattern")]
    public const string Zebra = "Zebra";
    public const string Winter = "Winter";
    public const string Leopard = "Leopard";
    public const string Giraffe = "Giraffe";
    public const string Jaguar = "Jaguar";
    public const string Orange = "Orange";
    public const string Pink = "Pink";
    public const string Tigr = "Tigr";
    public const string Yellow = "Yellow";
    public const string Color = "Color";
    [Header("Tanks")]
    public const string SimpleTank = "SimpleTank";
    public const string CannonTank = "CannonTank";
    public const string RocketTank = "RocketTank";
    public const string FireballTank = "FireballTank";
    public const string MissileTank = "MissileTank";
    public const string LazerTank = "LazerTank";

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetData(string name,int number)
    {
        PlayerPrefs.SetInt(name, number);
        PlayerPrefs.Save();
    }

    public void SetData(string name, float number)
    {
        PlayerPrefs.SetFloat(name, number);
        PlayerPrefs.Save();
    }
}