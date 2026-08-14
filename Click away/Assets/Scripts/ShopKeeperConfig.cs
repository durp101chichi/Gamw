using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopKeeperConfig", menuName = "Scriptable Objects/ShopKeeperConfig")]
public class ShopKeeperConfig : ScriptableObject
{

    [SerializeField] public float betweenHalf = 0.05f;
    [SerializeField] public float betweenChar = 0.03f;
    [SerializeField] public float smoothTime = 0.1f;

    

    public List<float> leftAlphas;
    public List<float> rightAlphas;

}
