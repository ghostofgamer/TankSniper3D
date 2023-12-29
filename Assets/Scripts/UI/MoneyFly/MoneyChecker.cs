using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoneyChecker : MonoBehaviour
{
    [SerializeField] Transform _flyMoneyContainer;

    private List<Transform> _flyMoneys;

    private void Start()
    {
        _flyMoneys = new List<Transform>();

        for (int i = 0; i < _flyMoneyContainer.childCount; i++)
            _flyMoneys.Add(_flyMoneyContainer.GetChild(i));
    }

    private void Update()
    {
        var filtred = _flyMoneys.Where(p => p.gameObject.activeSelf == true);
        Debug.Log("Колличество купюр " + filtred.Count());

        if (filtred.Count() <= 0)
        {
            Debug.Log("Финал");
        }
    }
}