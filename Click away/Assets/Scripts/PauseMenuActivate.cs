using UnityEngine;

public class PauseMenuActivate : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject inventory;
    [SerializeField] ArrowShoter ArrowShoter;
    [SerializeField] AkController controller;


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
            ArrowShoter.canShoot = false;
            controller.canFire = false;
        }
        else
        {
            ArrowShoter.canShoot= true;
            controller.canFire = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(!inventory.activeSelf);
            ArrowShoter.canShoot = false;
            controller.canFire = false;
        }
        else
        {
            ArrowShoter.canShoot = true;
            controller.canFire = true;
        }
    }
}
