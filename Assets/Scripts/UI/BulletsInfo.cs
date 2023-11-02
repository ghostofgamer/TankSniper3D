using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsInfo : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField]private List<Image> _bulletsImages;
    [SerializeField] private Image _reload;

    private void OnEnable()
    {
        _weapon.BulletsChanged += OnBulletsChanged;
    }

    private void OnDisable()
    {
        _weapon.BulletsChanged -= OnBulletsChanged;
    }

    private void OnBulletsChanged(int bulletsCount)
    {
        OffImage();

        for (int i = 0; i < bulletsCount; i++)
        {
            _bulletsImages[i].gameObject.SetActive(true);
        }
    }

    private void OffImage()
    {
        foreach (var item in _bulletsImages)
            item.gameObject.SetActive(false);
    }
}
