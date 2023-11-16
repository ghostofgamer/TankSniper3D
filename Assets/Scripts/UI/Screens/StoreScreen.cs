using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoreScreen : AbstractScreen
{
    [SerializeField] private GameObject[] _tabs;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private Load _load;

    public void OpenTab(int index)
    {
        OffItem(_tabs);
        _tabs[index].SetActive(true);
        _items[_load.Get(Save.Tank, index)].SetActive(true);
    }

    public void SetItem()
    {
        OffItem(_items);
    }

    public GameObject GetTank()
    {
        var filter = _items.FirstOrDefault(p => p.activeSelf == true);
        return filter;
    }

    private void OffItem(GameObject[] items)
    {
        foreach (GameObject item in items)
            item.SetActive(false);
    }
}
