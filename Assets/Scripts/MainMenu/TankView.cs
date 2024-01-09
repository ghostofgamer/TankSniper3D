using Assets.Scripts.GamePlayer;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class TankView : MonoBehaviour
    {
        [SerializeField] private Load _load;
        [SerializeField] private GameObject[] _tanks;
        [SerializeField] private Save _save;
        [SerializeField] private ParticleSystem _effect;
        [SerializeField] private AudioSource _audioSource;

        private int _startIndex = 0;
        private int _currentLevel = 0;

        private void Start()
        {
            Show();
            _currentLevel = _load.Get(Save.CurrentLevel, 0);
        }

        public void Show()
        {
            OffActiveTanks();
            SetTank();
        }

        public void ShowNewLevel(int level)
        {
            if (_currentLevel < level)
            {
                _effect.Play();
                _audioSource.Play();
                Show();

                if (_currentLevel < level)
                {
                    _currentLevel = level;
                    _save.SetData(Save.CurrentLevel, _currentLevel);
                }
            }
        }

        public void OffActiveTanks()
        {
            foreach (var tank in _tanks)
                tank.SetActive(false);
        }

        private void SetTank()
        {
            _tanks[_load.Get(Save.Tank, _startIndex)].SetActive(true);
            int index = _load.Get(Save.Tank, _startIndex);
            Material material = _tanks[index].GetComponent<Tank>().GetMaterial();
            _tanks[index].GetComponent<ColoringChanger>().SetMaterial(material);
        }
    }
}