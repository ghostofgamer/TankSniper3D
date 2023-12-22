using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDamage : MonoBehaviour
{
    [SerializeField] private Transform _textPosition;
    [SerializeField] private Enemy _enemy;

    public IEnumerator DamageTextFly(int damage)
    {
        if (!_enemy.IsDying)
        {
            Debug.Log("Зашел");
            float damageText = damage;
            float textSize = damageText / 100;
            GameObject text = Instantiate(Resources.Load("DamageText"), _textPosition.localPosition, Quaternion.identity) as GameObject;
            text.transform.SetParent(_textPosition.transform, false);
            text.GetComponent<TMPro.TextMeshPro>().SetText(damageText.ToString("0"));
            text.name = damageText.ToString("0");
            text.GetComponent<TMPro.TextMeshPro>().fontSize = textSize;
            yield return new WaitForSeconds(1f);
            Debug.Log("Вышел");
            text.SetActive(false);
        }
    }
}
