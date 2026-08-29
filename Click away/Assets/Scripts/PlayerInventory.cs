using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] public TextMeshProUGUI moneyCounterText;
    private void Start()
    {
        playerData.money = 300;
    }
    private void Update()
    {
        MoneyCounter();
        moneyLimit();
    }
    private void MoneyCounter()
    {
        //moneyCounterText.text = $"{playerData.money} $";
    }
    private void moneyLimit()
    {
        if (playerData.money <  0)
        {
            playerData.money = 0;
        }
    }
}
