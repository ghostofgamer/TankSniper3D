using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsInfo : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private List<Image> _bulletsImages;
    [SerializeField] private List<Image> _extraImages;
    [SerializeField] private Image _reload;
    [SerializeField] private GameObject _extraShootActivated;

    private readonly int _extraNeedCount = 3;

    private void OnEnable()
    {
        _weapon.BulletsChanged += OnBulletsChanged;
        OffImage(_extraImages);
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
        OffImage(_bulletsImages);
        OffImage(_extraImages);
        _extraShootActivated.SetActive(extraCount == _extraNeedCount);
        ValueChanged(bulletsCount, _bulletsImages);
        ValueChanged(extraCount, _extraImages);
    }

    private void ValueChanged(int count, List<Image> images)
    {
        for (int i = 0; i < count; i++)
            images[i].gameObject.SetActive(true);
    }

    private void OffImage(List<Image> images)
    {
        foreach (var item in images)
            item.gameObject.SetActive(false);
    }
}
