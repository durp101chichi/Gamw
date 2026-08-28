using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class InfoInventoryController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Tooltip Instellingen")]
    public GameObject ArrowInfo;
    

    void Start()
    {
        if (ArrowInfo != null)
            ArrowInfo.SetActive(false); 
       
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (ArrowInfo != null)
            ArrowInfo.SetActive(true); 
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ArrowInfo != null)
            ArrowInfo.SetActive(false); 
       
    }
}
