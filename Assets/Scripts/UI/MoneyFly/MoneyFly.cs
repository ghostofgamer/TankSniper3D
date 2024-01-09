using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MoneyFly
{
    public class MoneyFly : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Transform _targetPosition;
        [SerializeField] private float _speedScale;
        [SerializeField] private float _speed;

        private Transform _target;
        private RectTransform _rectTransform;
        private int _targetSize = 105;
        private int _minDistance = 1;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            Rect rect;
            rect = _image.rectTransform.rect;
            float width = rect.width;
            float height = rect.height;
            width = Mathf.MoveTowards(width, _targetSize, Time.deltaTime * _speedScale);
            height = Mathf.MoveTowards(height, _targetSize, Time.deltaTime * _speedScale);
            _rectTransform.sizeDelta = new Vector2(width, height);
            _target = _targetPosition;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _target.position) < _minDistance)
                gameObject.SetActive(false);

            if (transform.position == _target.position)
                gameObject.SetActive(false);
        }
    }
}