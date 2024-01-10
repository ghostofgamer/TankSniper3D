using UnityEngine;

namespace Assets.Scripts.GameEnemy
{
    public class TakenDamageParticle : MonoBehaviour
    {
        private const string DamageText = "DamageText";
        private const string Zero = "0";

        [SerializeField] private Transform _textPosition;

        private int _number = 100;

        public void SetText(int damage)
        {
            float damageText = damage;
            float textSize = damageText / _number;
            GameObject text = Instantiate(Resources.Load(DamageText), _textPosition.localPosition, Quaternion.identity) as GameObject;
            text.transform.SetParent(_textPosition.transform, false);
            text.GetComponent<TMPro.TextMeshPro>().SetText(damageText.ToString(Zero));
            text.name = damageText.ToString(Zero);
            text.GetComponent<TMPro.TextMeshPro>().fontSize = textSize;
        }
    }
}