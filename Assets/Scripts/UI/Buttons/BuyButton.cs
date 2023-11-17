using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : AbstractButton
{
    public enum Coloring
    {
        Zebra,
        Winter,
        Leopard
    }

    [SerializeField] private Image _imageBlock;
    [SerializeField] private Coloring _coloring;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;
    [SerializeField] private Ad _rewardVideo;

    private int _index = 1;
    private int _startIndex = 0;

    private void Start()
    {
        int index = _load.Get(_coloring.ToString(), _startIndex);

        if (index > 0)
            OffActive();
    }

    public override void OnClick()
    {
        switch (_coloring)
        {
            case Coloring.Zebra:
                _save.SetData(Save.Zebra, _index);
                _rewardVideo.Show();
                break;
            case Coloring.Winter:
                _save.SetData(Save.Winter, _index);
                _rewardVideo.Show();
                break;
            case Coloring.Leopard:
                _save.SetData(Save.Leopard, _index);
                _rewardVideo.Show();
                break;
            default:
                break;
        }
        //OffActive();
    }

    public void OffActive()
    {
        _imageBlock.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
