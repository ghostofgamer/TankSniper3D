using System.Collections;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;
    [SerializeField] private float _startMoney;

    private float _money;
    private float _smooth = 1f;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.15f);

    public float Money => _money;

    private void Start()
    {
        _money = _load.Get(Save.Money, _startMoney);
        ShowMoneyInfo();
    }

    public void AddMoney(int money)
    {
       StartCoroutine(ChangeMoney(money));
    }

    public void DecreaseMoney(int money)
    {
        _money -= money;
        ShowMoneyInfo();
    }

    private void ShowMoneyInfo()
    {
        _moneyText.text = _money.ToString("0");
        _save.SetData(Save.Money, _money);
    }

    private IEnumerator ChangeMoney(int money)
    {
        yield return _waitForSeconds;
        float elapsedTime = 0;
        float value = _money + money;

        while (_money < value)
        {
            elapsedTime += Time.deltaTime;
            float normalized = elapsedTime / _smooth;
            _money = Mathf.Lerp(_money, value, normalized);
            _moneyText.text = _money.ToString("0");
            yield return null;
        }

        _save.SetData(Save.Money, _money);
    }
}