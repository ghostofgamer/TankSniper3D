using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : AbstractButton
{
    [SerializeField] private Image _imageBlock;

    public override void OnClick()
    {
        _imageBlock.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
