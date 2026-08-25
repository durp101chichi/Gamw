using UnityEngine;

public class PauseMenuActivate : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inventory;
    public bool isPaused = false;


    void Start()
    {
        pauseMenu.SetActive(false);
        inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);          
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
        
        
    }
}
