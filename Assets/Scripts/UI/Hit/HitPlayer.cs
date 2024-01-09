using UnityEngine;
using UnityEngine.UI;

namespace Tank3D
{
    public class HitPlayer : MonoBehaviour
    {
        [SerializeField] private Image[] _hits;
        [SerializeField] private GameObject _positionEnemy;

        private Player _player;
        private int _half = 2;
        private int _right = 0;
        private int _left = 1;
        private int _up = 2;
        private int _down = 3;

        private void OnEnable()
        {
            _player.Hit += HitView;
        }

        private void OnDisable()
        {
            _player.Hit -= HitView;
        }

        public void Init(Player player)
        {
            _player = player;
        }

        private void HitView(Transform transform)
        {
            _positionEnemy.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            int widht = Screen.width / _half;
            int height = Screen.height / _half;
            Vector2 center = new Vector2(widht, height);

            if (_positionEnemy.transform.position.x > center.x)
                _hits[_right].gameObject.SetActive(true);

            if (_positionEnemy.transform.position.x < center.x)
                _hits[_left].gameObject.SetActive(true);

            if (_positionEnemy.transform.position.y > center.y)
                _hits[_up].gameObject.SetActive(true);

            if (_positionEnemy.transform.position.y < center.y)
                _hits[_down].gameObject.SetActive(true);
        }
    }
}