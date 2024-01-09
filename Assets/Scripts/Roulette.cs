using TMPro;
using UnityEngine;

namespace Tank3D
{
    public class Roulette : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winText;
        [SerializeField] private VictoryScreen _victoryScreen;

        private float _startReward;
        private int _angle;
        private int _factor = 1;
        private int _double = 2;
        private int _triple = 3;
        private int _quadruple = 4;
        private int _quintuple = 5;
        private int _minAngleDouble = 65;
        private int _maxAngleDouble = 90;
        private int _minAngleTriple = 0;
        private int _minAngleQuadruple = 300;
        private int _maxAngleQuadruple = 360;
        private int _minAngleQuintuple = 271;

        public int Win { get; private set; }

        private void Start()
        {
            _startReward = _victoryScreen.ViewReward;
        }

        private void Update()
        {
            _angle = Mathf.RoundToInt(transform.eulerAngles.z);

            if (_angle <= _maxAngleDouble && _angle >= _minAngleDouble)
                _factor = _double;

            if (_angle < _minAngleDouble && _angle >= _minAngleTriple)
                _factor = _triple;

            if (_angle <= _maxAngleQuadruple && _angle >= _minAngleQuadruple)
                _factor = _quadruple;

            if (_angle < _minAngleQuadruple && _angle >= _minAngleQuintuple)
                _factor = _quintuple;

            Win = (int)_startReward * _factor;
            _winText.text = Win.ToString();
        }
    }
}