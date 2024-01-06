using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewShoot : MonoBehaviour
{
    [SerializeField] protected Bullet _prefabBullet;
    [SerializeField] protected Transform _container;
    [SerializeField] protected Transform _shootPosition;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Load _load;
    [SerializeField] private TMP_Text _levelTxt;
    [SerializeField] private Tanks _tanksEnum;
    [SerializeField] private int _startLevel;

    protected ObjectPool<Bullet> _pool;
    protected readonly int _maxAmmo = 5;
    protected bool _autoExpand = true;

    private void OnEnable()
    {
        StartCoroutine(ViewLevel());
    }

    private void Start()
    {
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);
        _pool.SetAutoExpand(_autoExpand);
    }

    private void OnMouseDown()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            bullet.Init(_shootPosition);
            _audioSource.Play();
        }
    }

    private IEnumerator ViewLevel()
    {
        _levelTxt.text = " ";
        yield return new WaitForSeconds(0.05f);
        string nameR = _tanksEnum.ToString();

        _levelTxt.text = (_load.Get(nameR, _startLevel) + 1).ToString();
    }
}