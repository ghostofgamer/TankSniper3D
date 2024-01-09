using System.Linq;
using UnityEngine;

public class PartCollapse : MonoBehaviour
{
    [SerializeField] private GameObject[] _houseParts;
    [SerializeField] private int _minCountPart;

    private void Update()
    {
        Collapse();
    }

    private void Collapse()
    {
        var filter = _houseParts.Where(p => p.activeSelf == true);

        if (filter.Count() <= _minCountPart)
            GetComponent<Destroy>().Destruction();
    }
}