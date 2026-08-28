using Unity.VisualScripting;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    
    [SerializeField] PlayerData playerData;
    private void Start()
    {
        playerData.ArrowSpeed = 20f;
    }
    public void Tier1()
    {
        if (playerData.ArrowSpeed <= 15)
        {
            playerData.arrowCurrentDamage = 5;
            Debug.Log("5");
        }
    }
    public void Tier2()
    {
        if (playerData.ArrowSpeed <= 30 && playerData.ArrowSpeed > 15)
        {
            playerData.arrowCurrentDamage = 10;
            Debug.Log("10");
        }
    }
    public void Tier3()
    {
        if (playerData.ArrowSpeed <= 40 && playerData.ArrowSpeed > 30)
        {
            playerData.arrowCurrentDamage = 15;
            Debug.Log("15");
        }
    }
    public void Tier4()
    {
        if (playerData.ArrowSpeed <= 50 && playerData.ArrowSpeed > 40)
        {
            playerData.arrowCurrentDamage = 20;
            Debug.Log("20");
        }
    }
    public void Tier5()
    {
        if (playerData.ArrowSpeed <= 60 && playerData.ArrowSpeed > 50)
        {
            playerData.arrowCurrentDamage = 30;
            Debug.Log("30");
        }
    }
}
