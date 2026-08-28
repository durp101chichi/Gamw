using UnityEngine;
using UnityEngine.EventSystems;

public class LigherInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public GameObject LigherInformation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (LigherInformation != null)
            LigherInformation.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {


        if (LigherInformation != null)
            LigherInformation.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (LigherInformation != null)
            LigherInformation.SetActive(false);
    }
}
