using Assets.Scripts.GamePlayer;
using Assets.Scripts.SaveLoad;
using Assets.Scripts.UI.Screens;
using UnityEngine;

namespace Assets.Scripts.UI.Buttons
{
    public class ColoringButton : AbstractButton
    {
        [SerializeField] private StoreScreen _storeScreen;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;
        [SerializeField] private int _index;

        private int _zero = 0;

        public override void OnClick()
        {
            var tank = _storeScreen.GetTank();
            _save.SetData(Save.Color, _index);
            tank.GetComponent<Tank>().SetMaterial(_index);
            tank.GetComponentInChildren<Animator>().Play(_zero);
            Material material = tank.GetComponent<Tank>().GetMaterial();
            tank.GetComponentInChildren<ColoringChanger>().SetMaterial(material);
        }
    }
}