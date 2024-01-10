using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class WaterMover : MonoBehaviour
    {
        private const float Speed = 0.1f;

        private Renderer _renderer;
        private float _offset;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            ScrollTexture();
        }

        private void ScrollTexture()
        {
            _offset += Speed * Time.deltaTime;
            _renderer.material.mainTextureOffset = new Vector2(_offset, 0);
        }
    }
}