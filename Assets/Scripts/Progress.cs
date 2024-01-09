using UnityEngine;

namespace Tank3D
{
    public class Progress : MonoBehaviour
    {
        [SerializeField] protected Save Save;
        [SerializeField] protected Load Load;

        protected int CurrentIndex;
        protected int MaxIndex = 4;

        public int StartIndex { get; private set; } = 0;

        private void Start()
        {
            SetIndex();
        }

        public int AddIndex()
        {
            return ++CurrentIndex;
        }

        protected void SetIndex()
        {
            CurrentIndex = Load.Get(Save.Map, StartIndex);
        }
    }
}