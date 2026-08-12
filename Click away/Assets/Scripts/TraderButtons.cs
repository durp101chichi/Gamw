using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using static UnityEngine.Rendering.STP;

public class TraderScript : MonoBehaviour
{
    
    private bool playerInRange = false;
    [SerializeField] TraderConfig TraderConfig;
    [SerializeField] PlayerData PlayerData;
    [SerializeField] public GameObject _uitaskpanel;
    [SerializeField] public GameObject _uiTraderMenu;
    [SerializeField] public Trader TraderScript1;
    

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TraderScript1.isTraderAnimating = true;
            _uiTraderMenu.SetActive(true);
            _uitaskpanel.SetActive(false);

            TraderScript1.ticketText.text = $"{TraderConfig.ticketAmmount}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            playerInRange = true;
            _uitaskpanel.SetActive(true);
            
            
            TraderScript1.ticketText.text = $"{TraderConfig.ticketAmmount}";
        }
    }
    public void RefreshButton()
    {
        
    }

    private void Opener()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
           _uiTraderMenu.SetActive(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            playerInRange = false;
            _uitaskpanel.SetActive(false);
            _uiTraderMenu.SetActive(false);
            TraderScript1.ticketText.text =  $"{TraderConfig.ticketAmmount}";

        }
    }
}
