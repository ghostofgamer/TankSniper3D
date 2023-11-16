using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankChanger : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private List<GameObject> _tanks;

    public override void OnClick()
    {
        foreach (GameObject tank in _tanks)
            tank.SetActive(false);

        _tanks[_index].SetActive(true);
    }
}
