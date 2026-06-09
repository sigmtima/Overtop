using ShopScripts;
using TMPro;
using UnityEngine;

public class BalanceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceText;

    public void OnEnable()
    {
        WalletManager.Instance.OnBalanceChanged += UpdateBalance;
    }

    public void OnDisable()
    {
        WalletManager.Instance.OnBalanceChanged -= UpdateBalance;
    }

    public void UpdateBalance(float money)
    {
        balanceText.text = money.ToString("N0");
    }
}