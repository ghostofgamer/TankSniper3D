using System.Linq;
using UnityEngine;

public class StoreScreen : AbstractScreen
{
    [SerializeField] private GameObject[] _tabs;
    [SerializeField] private GameObject[] _items;
    [SerializeField] private GameObject[] _blocks;
    [SerializeField] private Load _load;

    private int _startIndex = 0;

    public void OpenTab(int index)
    {
        OffItem(_tabs);
        _tabs[index].SetActive(true);

        if (index == 0)
        {
            _items[_load.Get(Save.Tank, _startIndex)].SetActive(true);
            Material material = _items[_load.Get(Save.Tank, _startIndex)].GetComponentInChildren<Tank>().GetMaterial();
            _items[_load.Get(Save.Tank, _startIndex)].GetComponentInChildren<ColoringChanger>().SetMaterial(material);
        }

        OpenTanks();
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

    private void OpenTanks()
    {
        int allOpen = _load.Get(Save.AllTanksOpen, 0);

        if (allOpen == 0)
        {
            int level = _load.Get(Save.Level, _startIndex);

            for (int i = 0; i < level; i++)
                _blocks[i].SetActive(false);
        }
        else
        {
            foreach (GameObject block in _blocks)
                block.SetActive(false);
        }
    }

    private void OffItem(GameObject[] items)
    {
        foreach (GameObject item in items)
            item.SetActive(false);
    }
}