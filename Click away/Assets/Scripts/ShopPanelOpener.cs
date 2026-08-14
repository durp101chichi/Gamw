using UnityEngine;

public class ShopPanelOpener : MonoBehaviour
{
    [SerializeField] GameObject askPanel;
    [SerializeField] GameObject shopPanel;
    [SerializeField] ShopTextAnimator shopTextAnimator;
    [SerializeField] PlayerDamage playerDamage;

   private bool inRange = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            shopTextAnimator.isAnimating = true;
            playerDamage.hpText.text = $"";
            shopPanel.SetActive(true);
            askPanel.SetActive(false);
            
        }
        else
        {
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            askPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        playerDamage.hpText.text = $" {playerDamage.hp}";
        askPanel.SetActive(false);
        shopPanel.SetActive(false );
    }
    public void ExitButton()
    {
        playerDamage.hpText.text = $" {playerDamage.hp}";
        shopPanel.SetActive(false);
    }

}
