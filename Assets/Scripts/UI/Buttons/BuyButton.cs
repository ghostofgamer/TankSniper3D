using Assets.Scripts.ADS;
using Assets.Scripts.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Buttons
{
    public class BuyButton : AbstractButton
    {
        [SerializeField] private GameObject _AdButton;
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
                DisableActive();
        }

        public override void OnClick()
        {
            Button.interactable = false;

            switch (_coloring)
            {
                case Coloring.Zebra:
                    _save.SetData(Save.Zebra, _index);
                    ShowAd();
                    break;
                case Coloring.Winter:
                    _save.SetData(Save.Winter, _index);
                    ShowAd();
                    break;
                case Coloring.Leopard:
                    _save.SetData(Save.Leopard, _index);
                    ShowAd();
                    break;
                case Coloring.Giraffe:
                    _save.SetData(Save.Giraffe, _index);
                    ShowAd();
                    break;
                case Coloring.Jaguar:
                    _save.SetData(Save.Jaguar, _index);
                    ShowAd();
                    break;
                case Coloring.Orange:
                    _save.SetData(Save.Orange, _index);
                    ShowAd();
                    break;
                case Coloring.Pink:
                    _save.SetData(Save.Pink, _index);
                    ShowAd();
                    break;
                case Coloring.Tigr:
                    _save.SetData(Save.Tigr, _index);
                    ShowAd();
                    break;
                case Coloring.Yellow:
                    _save.SetData(Save.Yellow, _index);
                    ShowAd();
                    break;
                default:
                    break;
            }
        }

        public void DisableActive()
        {
            _imageBlock.gameObject.SetActive(false);
            _AdButton.SetActive(false);
        }

        private void ShowAd()
        {
            int volume = _load.Get(Save.Volume, _index);
            _rewardVideo.SetVolume(volume);
            _rewardVideo.Show();
        }
    }
}