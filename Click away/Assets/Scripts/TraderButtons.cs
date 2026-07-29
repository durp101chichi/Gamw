using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class TraderScript : MonoBehaviour
{
    
    private bool playerInRange = false;
    [SerializeField] TraderConfig TraderConfig;
    [SerializeField] public GameObject _uitaskpanel;
    [SerializeField] public GameObject _uiTraderMenu;
    [SerializeField] public Trader TraderScript1;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            _uiTraderMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            playerInRange = true;
            _uitaskpanel.SetActive(true);
        }
    }
   
    
    private void Opener()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
           _uiTraderMenu.SetActive(true);
        }
        Debug.Log("Dad");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trader"))
        {
            playerInRange = false;
            _uitaskpanel.SetActive(false);
            _uiTraderMenu.SetActive(false);
            TraderScript1.animationText.alpha = 0.1f;

        }
    }
}
