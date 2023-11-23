using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsInfo : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField]private List<Image> _bulletsImages;
    [SerializeField]private List<Image> _extraImages;
    [SerializeField] private Image _reload;
    [SerializeField] private GameObject _extraShootActivated;

    private void OnEnable()
    {
        _weapon.BulletsChanged += OnBulletsChanged;
    }

    private void OnDisable()
    {
        _weapon.BulletsChanged -= OnBulletsChanged;
    }

    private void OnBulletsChanged(int bulletsCount,int extraCount)
    {
        OffImage();
        _extraShootActivated.SetActive(extraCount == 2);
        //if (extraCount == 2)
        //{

        //}
        for (int i = 0; i < bulletsCount; i++)
        {
            _bulletsImages[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < extraCount; i++)
        {
            _extraImages[i].gameObject.SetActive(true);
        }
    }

    private void OffImage()
    {
        foreach (var item in _bulletsImages)
            item.gameObject.SetActive(false);

        foreach (var item in _extraImages)
            item.gameObject.SetActive(false);
    }
}
