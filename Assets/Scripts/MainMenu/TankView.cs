using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private GameObject[] _tanks;
    [SerializeField] private MaterialContainer _materialContainer;

    private int _startIndex = 0;

    private void Start()
    {
        ViewTank();
    }

    public void ViewTank()
    {
        for (int i = 0; i < _tanks.Length; i++)
        {
            _tanks[i].SetActive(false);
            _tanks[_load.Get(Save.Tank, 0)].SetActive(true);
            _tanks[_load.Get(Save.Tank, 0)].GetComponent<ColoringChanger>().SetMaterial(_materialContainer.GetColor());
        }
    }
}
