using UnityEngine;

namespace Tank3D
{
    public enum MissileState
    {
        Start,
        Fly
    }
}

namespace Tank3D
{
    public class HomingRocket : MonoBehaviour
    {
        [SerializeField] private float _speedStart;
        [SerializeField] private float _speedMove;
        [SerializeField] private float _speedRotate;
        [SerializeField] private int _distance;
        [SerializeField] private BulletTrigger _bulletTrigger;
        [SerializeField] private Bullet _bullet;

        private Transform _target;
        private Vector3 _startPosition;
        private float _correctVector = 1f;
        private int _minDistance = 1;
        private MissileState _missileState;
        private float _maxSpeed = 35;

        private void Start()
        {
            _target = FindObjectOfType<Player>().transform;
            _startPosition = gameObject.transform.position;
        }

        private void OnEnable()
        {
            _speedMove = _maxSpeed;
        }

        private void OnDisable()
        {
            _missileState = MissileState.Start;
        }

        private void Update()
        {
            switch (_missileState)
            {
                case MissileState.Start:
                    float startDistance = Vector3.Distance(gameObject.transform.position, _startPosition);
                    gameObject.transform.Translate(Vector3.up * _speedStart * Time.deltaTime);

                    if (startDistance >= _distance)
                        _missileState = MissileState.Fly;

                    break;

                case MissileState.Fly:
                    gameObject.transform.Translate(Vector3.up * _speedMove * Time.deltaTime);
                    Vector3 target = new Vector3(_target.transform.position.x, _target.transform.position.y + _correctVector, _target.transform.position.z);
                    Vector3 targetVector = target - gameObject.transform.position;
                    gameObject.transform.up = Vector3.Slerp(gameObject.transform.up, targetVector, _speedRotate * Time.deltaTime);

                    if (Vector3.Distance(transform.position, _target.position) < _minDistance)
                        _speedMove = 0f;

                    break;
            }
        }
    }
}