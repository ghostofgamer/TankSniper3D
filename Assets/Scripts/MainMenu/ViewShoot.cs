using System.Collections;
using Assets.Scripts.Bullets;
using Assets.Scripts.MergeTanks;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.Spawner;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class ViewShoot : MonoBehaviour
    {
        [SerializeField] private Bullet _prefabBullet;
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Load _load;
        [SerializeField] private TMP_Text _levelTxt;
        [SerializeField] private Tanks _tanksEnum;
        [SerializeField] private int _startLevel;

        protected ObjectPool<Bullet> _pool;
        protected int _maxAmmo = 5;
        protected bool _autoExpand = true;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.05f);

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
            Shoot();
        }

        private void Shoot()
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
            yield return _waitForSeconds;
            string name = _tanksEnum.ToString();
            int level = _load.Get(name, _startLevel);
            _levelTxt.text = (++level).ToString();
        }
    }
}