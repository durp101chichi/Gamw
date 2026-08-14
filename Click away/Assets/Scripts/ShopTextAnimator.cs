using DG.Tweening;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class ShopTextAnimator : MonoBehaviour
{


[SerializeField] ShopKeeperConfig shopKeeperConfig;


[SerializeField] public TextMeshProUGUI animationText;

public bool isAnimating = false;
    

    
    private void Start()
    {

        shopKeeperConfig.leftAlphas = new float[animationText.text.Length].ToList();
        shopKeeperConfig.rightAlphas = new float[animationText.text.Length].ToList();

    }
    private void Update()
    {


        TextAnimator1();
        if (Input.GetKeyUp(KeyCode.End))
        {
            isAnimating = false;
            Visible(true);
        }
    }
    public void TextAnimator1()
    {

        if (isAnimating)
        {
            SwitchColor();
            StartCoroutine(Smooth(0));
        }




    }
    private void Visible(bool visible)
    {
        StopAllCoroutines();
        DOTween.Kill(1);

        for (int i = 0; i < shopKeeperConfig.leftAlphas.Count; i++)
        {
            shopKeeperConfig.leftAlphas[i] = visible ? 255 : 0;
            shopKeeperConfig.rightAlphas[i] = visible ? 255 : 0;
        }
        SwitchColor();
    }

    private void SwitchColor()
    {
        for (int i = 0; i < shopKeeperConfig.leftAlphas.Count; i++)
        {
            if (animationText.textInfo.characterInfo[i].character != '\n' &&
                animationText.textInfo.characterInfo[i].character != ' ')
            {
                int meshIndex = animationText.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = animationText.textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = animationText.textInfo.meshInfo[meshIndex].colors32;

                vertexColors[vertexIndex + 0].a = (byte)shopKeeperConfig.leftAlphas[i];
                vertexColors[vertexIndex + 1].a = (byte)shopKeeperConfig.leftAlphas[i];
                vertexColors[vertexIndex + 2].a = (byte)shopKeeperConfig.rightAlphas[i];
                vertexColors[vertexIndex + 3].a = (byte)shopKeeperConfig.rightAlphas[i];
            }
        }
        animationText.UpdateVertexData();
    }
    private IEnumerator Smooth(int i)
    {
        if (i >= shopKeeperConfig.leftAlphas.Count)
            yield break;

        DOTween.To(
        () => shopKeeperConfig.leftAlphas[i],
        z => shopKeeperConfig.leftAlphas[i] = z,
        255,
        shopKeeperConfig.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(shopKeeperConfig.betweenHalf);

        DOTween.To(
        () => shopKeeperConfig.rightAlphas[i],
        z => shopKeeperConfig.rightAlphas[i] = z,
        255,
        shopKeeperConfig.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(shopKeeperConfig.betweenChar);
        StartCoroutine(Smooth(i + 1));
    }
}