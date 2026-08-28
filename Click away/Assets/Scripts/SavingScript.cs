using UnityEngine;
using System.IO;
using System.Collections;

    public class SaveManager : MonoBehaviour
    {
    [Header("UI Elementen")]
    public GameObject saveNotificationText;

    private string filePath;
    private float autoSaveInterval = 30f;
    private GameObject player;
    private Rigidbody playerRb;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/playersave.json";
        player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody>();
        }
    }

    private void Start()
    {
        if (saveNotificationText != null) saveNotificationText.SetActive(false);
        LoadGame();
        StartCoroutine(AutoSaveRoutine());
    }

    private IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveInterval);
            SaveGame();
        }
    }

    public void SaveGame()
    {
        if (player == null) return;

        PlayerSaveData data = new PlayerSaveData();

        data.posX = player.transform.position.x;
        data.posY = player.transform.position.y;
        data.posZ = player.transform.position.z;

        data.level = 1;
        data.score = 100;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Spel opgeslagen!");

        if (saveNotificationText != null)
        {
            StartCoroutine(ShowNotificationRoutine());
        }
    }

    public void LoadGame()
    {
        if (player == null) return;

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);

            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }

            player.transform.position = new Vector3(data.posX, data.posY, data.posZ);
            Debug.Log("Spel geladen!");
        }
    }

    private IEnumerator ShowNotificationRoutine()
    {
        saveNotificationText.SetActive(true);
        yield return new WaitForSeconds(2f);
        saveNotificationText.SetActive(false);
    }

    public void DeleteAllSaves()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save-bestand verwijderd.");
        }
    }
}




