using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimatingConfig", menuName = "Scriptable Objects/AnimatingConfig")]
public class AnimatingConfig : ScriptableObject
{
    [SerializeField] public float betweenHalf = 0.05f;
    [SerializeField] public float betweenChar = 0.03f;
    [SerializeField] public float smoothTime = 0.1f;

    [SerializeField] public GameObject GameObjectPrefab;

    public List<float> leftAlphas;
    public List<float> rightAlphas;

    
}
