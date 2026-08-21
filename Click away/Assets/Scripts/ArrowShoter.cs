using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ArrowShoter : MonoBehaviour
{
    public GameObject pijlPrefab;    
    public Transform schietPunt;     
    public float pijlSnelheid = 20f;
    [SerializeField] int ammountOfShoot;
    [SerializeField] TextMeshProUGUI arrowCounter;
    [Header("Scroll Instellingen")]

    public float scrollGevoeligheid = 1f;
    public float minimaleSnelheid = 10f;   
    public float maximaleSnelheid = 60f;

    private void Start()
    {


        arrowCounter.text = $"{ammountOfShoot}";
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            PasSnelheidAan(scroll);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            
                if (ammountOfShoot > 0)
                {
                    SchietPijlNaarMuis();
                    ammountOfShoot--;
                    arrowCounter.text = $"{ammountOfShoot}";
                }
            
            
            
        }
    }
    void PasSnelheidAan(float scrollRichting)
    {
        // Verander de snelheid op basis van de scroll-richting en gevoeligheid
        pijlSnelheid += scrollRichting * scrollGevoeligheid;

        // Mathf.Clamp zorgt ervoor dat de snelheid netjes tussen het minimum en maximum blijft
        pijlSnelheid = Mathf.Clamp(pijlSnelheid, minimaleSnelheid, maximaleSnelheid);

        Debug.Log("Huidige pijlsnelheid ingesteld op: " + pijlSnelheid);
    }
    void SchietPijlNaarMuis()
    {
        
        GameObject nieuwePijl = Instantiate(pijlPrefab, schietPunt.position, schietPunt.rotation);
        Rigidbody rb = nieuwePijl.GetComponent<Rigidbody>();

        if (rb != null)
        {
            
            Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

           
            Vector3 vliegRichting = transform.forward;

            
            if (Physics.Raycast(straal, out hitInfo))
            {
                
                vliegRichting = (hitInfo.point - schietPunt.position).normalized;
            }

            // 5. Laat de pijl in die richting vliegen
            rb.linearVelocity = vliegRichting * pijlSnelheid;

            
            nieuwePijl.transform.forward = vliegRichting;
            
        }
    }
}
