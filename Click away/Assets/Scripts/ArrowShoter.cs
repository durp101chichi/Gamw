using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ArrowShoter : MonoBehaviour
{
    public GameObject pijlPrefab;    //arrowprefab
    public Transform schietPunt;     //shootpoint
    public float pijlSnelheid = 20f;
    [SerializeField] int ammountOfShoot;
    [SerializeField] TextMeshProUGUI arrowCounter;
    [SerializeField] AkController akController;
    [SerializeField] HasAk hasAk;
    
    [Header("Scroll Instellingen")]

    public float scrollGevoeligheid = 1f; //scroolsens
    public float minimaleSnelheid = 10f;   //minspeed
    public float maximaleSnelheid = 60f; //maxspeed

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
        if (Input.GetMouseButtonDown(0) && !hasAk.hasAk)
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
       
        pijlSnelheid += scrollRichting * scrollGevoeligheid;

        
        pijlSnelheid = Mathf.Clamp(pijlSnelheid, minimaleSnelheid, maximaleSnelheid);

        Debug.Log("Huidige pijlsnelheid ingesteld op: " + pijlSnelheid);
    }
    void SchietPijlNaarMuis()
    {

        GameObject nieuwePijl = Instantiate(pijlPrefab, schietPunt.position, schietPunt.rotation);
        Rigidbody rb = nieuwePijl.GetComponent<Rigidbody>();

        if (rb != null)
        {
           
            Plane speelvlak = new Plane(Vector3.forward, schietPunt.position);
            Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 vliegRichting = transform.forward;
            float afstand;

            // 2. Bepaal waar de muis het 2D-vlak snijdt
            if (speelvlak.Raycast(straal, out afstand))
            {
                Vector3 muisOpVlak = straal.GetPoint(afstand);

                
                vliegRichting = muisOpVlak - schietPunt.position;
                vliegRichting.z = 0f; 
                vliegRichting.Normalize(); 
            }

           
            rb.linearVelocity = vliegRichting * pijlSnelheid;

            if (vliegRichting != Vector3.zero)
            {
                nieuwePijl.transform.forward = vliegRichting;
            }
        }
    }
}
