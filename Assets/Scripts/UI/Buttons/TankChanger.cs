using System.Collections.Generic;
using Assets.Scripts.GamePlayer;
using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class TankChanger : AbstractButton
    {
        [SerializeField] private List<GameObject> _tanks;
        [SerializeField] private int _index;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;

        private int _currentIndex;
        private int _startIndex = 0;

        private void Start()
        {
            _currentIndex = _load.Get(Save.Tank, _startIndex);
        }

        public override void OnClick()
        {
            SetTank();
        }

        private void SetTank()
        {
            DisableTanks();
            _currentIndex = _index;
            _tanks[_currentIndex].SetActive(true);
            Material material = _tanks[_currentIndex].GetComponentInChildren<Tank>().GetMaterial();
            _tanks[_currentIndex].GetComponentInChildren<ColoringChanger>().SetMaterial(material);
            _save.SetData(Save.Tank, _currentIndex);
        }

        private void DisableTanks()
        {
            foreach (GameObject tank in _tanks)
                tank.SetActive(false);
        }
    }
}