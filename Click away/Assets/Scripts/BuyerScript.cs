using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuyerScript : MonoBehaviour
{
    [SerializeField] TraderConfig config;
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject buyerPanel;
    [SerializeField] GameObject buyerAskPanel;
    [SerializeField] TextMeshProUGUI ticketText;
    [SerializeField] BuyerTextAnimator BuyerTextAnimator;
    


    private bool playerInRange = false; 
    void Start()
    {
        ticketText.text = $"{config.ticketAmmount}";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyUp(KeyCode.E))
        {
            BuyerTextAnimator.isAnimating = true;
            buyerPanel.SetActive(true);
            buyerAskPanel.SetActive(false);
            ticketText.text = $"{config.ticketAmmount}";
        }
    }
    public void TicketSellButton()
    {
        if (config.ticketAmmount >  0)
        {
            playerData.money += 40;
            config.ticketAmmount -= 1;
            ticketText.text = $"{config.ticketAmmount}";
        }
    }
    public void RefreshButton()
    {
        ticketText.text = $"{config.ticketAmmount}";
    }
    public void ExitButton()
    {
        buyerPanel.SetActive (false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            buyerAskPanel.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
        buyerPanel.SetActive(false);
        buyerAskPanel.SetActive(false);
        ticketText.text = $"{config.ticketAmmount}";
    }

}
