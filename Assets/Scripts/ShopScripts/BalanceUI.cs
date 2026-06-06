using ShopScripts;
using UnityEngine;
using TMPro;

public class BalanceUI : MonoBehaviour
{

 [SerializeField] private TextMeshProUGUI balanceText;
 

 public void UpdateBalance(float money)
 {
  balanceText.text = money.ToString("N0");
  
 }

 public void OnEnable()
 {
  ShopScripts.WalletManager.Instance.OnBalanceChanged += UpdateBalance;
 }

 public void OnDisable()
 {
  ShopScripts.WalletManager.Instance.OnBalanceChanged -= UpdateBalance;
 }
}
