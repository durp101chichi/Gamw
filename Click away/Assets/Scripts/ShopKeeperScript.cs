using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperScript : MonoBehaviour
{



    [Header("TV")]
    [SerializeField] public GameObject TVButton;
    [SerializeField] public GameObject newTv;
    [SerializeField] public GameObject oldTv;

    [Header("Beds")]
    [SerializeField] public GameObject newBedButton;
    [SerializeField] public GameObject newBed;
    [SerializeField] public GameObject oldBed;

    [Header("ThrirdFloor")]
    [SerializeField] public GameObject newFloorButton;
    [SerializeField] public GameObject thirdFloor;
    [SerializeField] public GameObject oldFloor;

    [Header ("Data")]
    [SerializeField] TraderConfig TraderConfig;
    [SerializeField] PlayerData PlayerData;
    [SerializeField] ShopKeeperConfig ShopKeeperConfig;

    [Header("Bool")]
    bool isTv;



    private void Update()
    {
        
       // if (isTv)
        {
      //      Debug.Log("TV");
        }
    }
    private void NewBedPlacer()
    {
        oldBed.SetActive(false);
        newBed.SetActive(true);
    }
    public void NewBedButton()
    {
        if (PlayerData.money >= 300)
        {
            NewBedPlacer();
            PlayerData.money -= 300;
            newBedButton. SetActive(false);
        }
    }
    private void NewFloorPlacer()
    {
        
        oldFloor.SetActive(false);
        thirdFloor.SetActive(true);
    }
    public void ThirdFloorButton()
    {
        if (PlayerData.money >= 1200)
        {
            isTv = true;
            NewFloorPlacer();
            PlayerData.money -= 1200;
            
            newFloorButton. SetActive(false);
        }
    }
    private void NewTVPLacer()
    {
            oldTv.SetActive(false);
            newTv.SetActive(true);
    }
    public void NewTVButton()
    {
        if (PlayerData.money >= 300 && isTv)
        {
            PlayerData.money -= 300;
            NewTVPLacer();
            TVButton.SetActive(false);

        }
    }
    


}
