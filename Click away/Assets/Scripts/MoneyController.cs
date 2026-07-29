using DG.Tweening;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] PlayerData playerData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10000 ; i++) 
        {
          gameObject.transform.DORotate(new Vector3(0, 360, 0), rotationSpeed, RotateMode.Fast)
           .SetRelative(true)
           .SetEase(Ease.Linear)
           .SetLoops(-1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            playerData.money += 100;
            Debug.Log("money");
            gameObject.SetActive(false);
        }
    }
}
