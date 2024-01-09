using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField] private TowerRotate _towerRotate;

    private int _factor = 100;

    public void Init(TowerRotate towerRotate)
    {
        _towerRotate = towerRotate;
    }

    public void MoveRotate()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * _factor;
        Ray ray = new Ray(transform.position, forward);

        if (Physics.Raycast(ray, out hit))
            _towerRotate.Rotate(hit.point);
    }
}