using UnityEngine;
using UnityEngine.UI;

namespace Tank3D
{
    public class ProgressPoint : MonoBehaviour
    {
        [SerializeField] private Image _imageNotComplite;
        [SerializeField] private Image _imageComplite;

        public void Complite()
        {
            SetBool(false);
        }

        public void NoComplite()
        {
            SetBool(true);
        }

        private void SetBool(bool flag)
        {
            _imageNotComplite.gameObject.SetActive(flag);
            _imageComplite.gameObject.SetActive(!flag);
        }
    }
}