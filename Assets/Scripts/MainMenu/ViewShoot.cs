using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewShoot : MonoBehaviour
{
    [SerializeField] protected Bullet _prefabBullet;
    [SerializeField] protected Transform _container;
    [SerializeField] protected Transform _shootPosition;
    //[SerializeField] private AudioPlugin _audioPlugin;
    [SerializeField] private AudioSource _audioSource;
    //[SerializeField] private AudioClip _audioClip;
    [SerializeField] private Load _load;
    [SerializeField] private TMP_Text _levelTxt;
    [SerializeField] private Tanks _tanksEnum;
    [SerializeField] private int _startLevel;



    //private Weapon _weapon;
    protected ObjectPool<Bullet> _pool;
    protected readonly int _maxAmmo = 5;
    protected bool _autoExpand = true;

    private void OnEnable()
    {

        StartCoroutine(ViewLevel());
        //Debug.Log("ÂÊË");
        //string nameR = _tanksEnum.ToString();

        //_levelTxt.text = (_load.Get(nameR, _startLevel) + 1).ToString();
    }

    private void Start()
    {
        //Debug.Log("Ñòàðò");
        _pool = new ObjectPool<Bullet>(_prefabBullet, _maxAmmo, _container);
        _pool.GetAutoExpand(_autoExpand);
        //_weapon = GetComponent<Weapon>();
    }

    private void OnMouseDown()
    {
        if (_pool.TryGetObject(out Bullet bullet, _prefabBullet))
        {
            bullet.Init(_shootPosition);
            //_audioPlugin.PlayOneShootKey();
            _audioSource.Play();
            //_audioPlugin.PlayKey();
        }
        //_weapon.Shoot();
    }

    private IEnumerator ViewLevel()
    {
        _levelTxt.text = " ";
        yield return new WaitForSeconds(0.05f);
        string nameR = _tanksEnum.ToString();

        _levelTxt.text = (_load.Get(nameR, _startLevel) + 1).ToString();
    }
}