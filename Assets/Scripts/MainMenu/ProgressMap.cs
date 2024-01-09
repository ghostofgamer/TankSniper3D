using UnityEngine;

namespace Tank3D
{
    public class ProgressMap : Progress
    {
        [SerializeField] private GameObject[] _enviropments;
        [SerializeField] private GameObject[] _points;
        [SerializeField] private GameObject[] _advancement;
        [SerializeField] private ProgressPoint[] _progressPoint;
        [SerializeField] private BuyTank _buyTank;
        [SerializeField] private Transform[] _positions;
        [SerializeField] private bool _isMainScene;

        private int _indexEnviropments;
        private int _maxIndexEnviropment = 2;

        private void Awake()
        {
            _indexEnviropments = Load.Get(Save.Enviropment, StartIndex);

            if (_isMainScene)
                SetElement(_enviropments, _indexEnviropments);

            ProgressPointImage();
            SetIndex();
            SetProgress();
        }

        private void SetProgress()
        {
            if (CurrentIndex > MaxIndex)
            {
                SetEnviropment();
                SetElement(_enviropments, _indexEnviropments);
            }

            SetElement(_points, CurrentIndex);
            SetElement(_advancement, _indexEnviropments);
        }

        private void SetEnviropment()
        {
            if (_isMainScene)
            {
                CurrentIndex = 0;
                _indexEnviropments++;

                if (_indexEnviropments > _maxIndexEnviropment)
                    _indexEnviropments = 0;

                Save.SetData(Save.Enviropment, _indexEnviropments);
                Save.SetData(Save.Map, CurrentIndex);
            }
        }

        private void SetElement(GameObject[] gameObjects, int index)
        {
            foreach (var gameObject in gameObjects)
                gameObject.SetActive(false);

            gameObjects[index].SetActive(true);
        }

        private void ProgressPointImage()
        {
            foreach (var progressPoint in _progressPoint)
                progressPoint.NoComplite();

            CurrentIndex = Load.Get(Save.Map, StartIndex);

            for (int i = 0; i < CurrentIndex; i++)
                _progressPoint[i].Complite();
        }
    }
}