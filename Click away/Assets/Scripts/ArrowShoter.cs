using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ArrowShoter : MonoBehaviour
{
    public GameObject pijlPrefab;    //arrowprefab
    public Transform schietPunt;     //shootpoint
   [SerializeField] PlayerData playerData;
    [SerializeField] int ammountOfShoot;
    [SerializeField] TextMeshProUGUI arrowCounter;
    [SerializeField] AkController akController;
    [SerializeField] HasAk hasAk;
    [SerializeField] ArrowDamage arrowSpeed;
    [SerializeField] PauseMenuActivate pauseMenuActivate;
    
    [Header("Scroll Instellingen")]

    public float scrollGevoeligheid = 1f; //scroolsens
    public float minimaleSnelheid = 0f;  //minspeed
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
          //  if (pauseMenuActivate.isPaused == false)
            {
                if (ammountOfShoot > 0)
                {
                    SchietPijlNaarMuis();
                    ammountOfShoot--;
                    arrowCounter.text = $"{ammountOfShoot}";
                    arrowSpeed.Tier1();
                    arrowSpeed.Tier2();
                    arrowSpeed.Tier3();
                    arrowSpeed.Tier4();
                    arrowSpeed.Tier5();

                }
            } 
            
        }
    }
    void PasSnelheidAan(float scrollRichting)
    {
       
        playerData.ArrowSpeed += scrollRichting * scrollGevoeligheid;

        
        playerData.ArrowSpeed = Mathf.Clamp(playerData.ArrowSpeed, minimaleSnelheid, maximaleSnelheid);

       // Debug.Log("Huidige pijlsnelheid ingesteld op: " + pijlSnelheid);
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

           
            rb.linearVelocity = vliegRichting * playerData.ArrowSpeed;

            if (vliegRichting != Vector3.zero)
            {
                nieuwePijl.transform.forward = vliegRichting;
                SpeedDrop();
            }
        }
    }
    private void SpeedDrop()
    {
        if (playerData.ArrowSpeed > 0)
        {
         //   while (playerData.ArrowSpeed == minimaleSnelheid)
            {
           //     playerData.ArrowSpeed--;
            }
            playerData.ArrowSpeed -= 5;
            
        }
        


    }

}
