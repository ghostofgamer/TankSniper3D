using Assets.Scripts.SaveLoad;
using UnityEngine;

namespace Assets.Scripts
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