using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "TraderConfig", menuName = "Scriptable Objects/TraderConfig")]
public class TraderConfig : ScriptableObject
{
    [SerializeField]  public float ticketAmmount ;
    [SerializeField] public float betweenHalf = 0.05f;
    [SerializeField] public float betweenChar = 0.03f;
    [SerializeField] public float smoothTime = 0.1f;
    
    [SerializeField] public GameObject GameObjectPrefab;

    public List<float> leftAlphas;
    public List<float> rightAlphas;
}
