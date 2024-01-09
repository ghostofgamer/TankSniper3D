using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tank3D
{
    public class BulletsInfo : MonoBehaviour
    {
        private readonly int ExtraNeedCount = 3;

        [SerializeField] private List<Image> _bulletsImages;
        [SerializeField] private List<Image> _extraImages;
        [SerializeField] private Image _reload;
        [SerializeField] private GameObject _extraShootActivated;

        private Weapon _weapon;

        private void OnEnable()
        {
            _weapon.BulletsChanged += OnBulletsChanged;
            _extraShootActivated.SetActive(false);
        }

        private void OnDisable()
        {
            _weapon.BulletsChanged -= OnBulletsChanged;
        }

        public void Init(Weapon weapon)
        {
            _weapon = weapon;
        }

        private void OnBulletsChanged(int bulletsCount, int extraCount)
        {
            ValueChanged(bulletsCount, _bulletsImages);
            ValueChanged(extraCount, _extraImages);
            _extraShootActivated.SetActive(extraCount == ExtraNeedCount);
        }

        private void ValueChanged(int count, List<Image> images)
        {
            foreach (Image image in images)
                image.gameObject.SetActive(false);

            for (int i = 0; i < count; i++)
                images[i].gameObject.SetActive(true);
        }
    }
}