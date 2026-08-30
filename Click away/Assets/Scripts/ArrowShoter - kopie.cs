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
                    SpeedDrop();
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
        // 1. Bereken de muispositie in de wereld
        Plane speelvlak = new Plane(-Camera.main.transform.forward, schietPunt.position);
        Ray straal = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (speelvlak.Raycast(straal, out float afstand))
        {
            Vector3 muisPositie = straal.GetPoint(afstand);

            // 2. Bepaal de richting van schietPunt naar muis (alleen X en Y)
            Vector3 richtingsVector = muisPositie - schietPunt.position;
            richtingsVector.z = 0f;

            if (richtingsVector == Vector3.zero) return;

            // 3. Bereken de exacte rotatie die naar de muis wijst
            Quaternion pijlRotatie = Quaternion.LookRotation(richtingsVector, Vector3.up);

            // 4. Instantiate met de BEREKENDE rotatie (niet schietPunt.rotation!)
            GameObject nieuwePijl = Instantiate(pijlPrefab, schietPunt.position, pijlRotatie);

            // 5. Negeer botsing tussen pijl en speler direct bij de start
            Collider pijlCol = nieuwePijl.GetComponent<Collider>();
            Collider spelerCol = GetComponent<Collider>();
            if (pijlCol != null && spelerCol != null)
            {
                Physics.IgnoreCollision(pijlCol, spelerCol);
            }

            // 6. Geef snelheid in de berekende richting
            Rigidbody rb = nieuwePijl.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = richtingsVector.normalized * playerData.ArrowSpeed;
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
