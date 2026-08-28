using UnityEngine;
using UnityEngine.EventSystems;

public class AkInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public GameObject AkInf; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (AkInf != null)
            AkInf.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        
        if (AkInf != null)
            AkInf.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (AkInf != null)
            AkInf.SetActive(false);
    }


}
