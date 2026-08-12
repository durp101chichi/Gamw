using DG.Tweening;
using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.STP;

public class BuyerTextAnimator : MonoBehaviour
{
    
    
    [SerializeField] AnimatingConfig animatingConfig;
    
    
    [SerializeField] public TextMeshProUGUI animationText;

    public bool isAnimating = false;
    private void Start()
    {
        
        animatingConfig.leftAlphas = new float[animationText.text.Length].ToList();
        animatingConfig.rightAlphas = new float[animationText.text.Length].ToList();

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

        for (int i = 0; i < animatingConfig.leftAlphas.Count; i++)
        {
            animatingConfig.leftAlphas[i] = visible ? 255 : 0;
            animatingConfig.rightAlphas[i] = visible ? 255 : 0;
        }
        SwitchColor();
    }

    private void SwitchColor()
    {
        for (int i = 0; i < animatingConfig.leftAlphas.Count; i++)
        {
            if (animationText.textInfo.characterInfo[i].character != '\n' &&
                animationText.textInfo.characterInfo[i].character != ' ')
            {
                int meshIndex = animationText.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = animationText.textInfo.characterInfo[i].vertexIndex;
                Color32[] vertexColors = animationText.textInfo.meshInfo[meshIndex].colors32;

                vertexColors[vertexIndex + 0].a = (byte)animatingConfig.leftAlphas[i];
                vertexColors[vertexIndex + 1].a = (byte)animatingConfig.leftAlphas[i];
                vertexColors[vertexIndex + 2].a = (byte)animatingConfig.rightAlphas[i];
                vertexColors[vertexIndex + 3].a = (byte)animatingConfig.rightAlphas[i];
            }
        }
        animationText.UpdateVertexData();
    }
    private IEnumerator Smooth(int i)
    {
        if (i >= animatingConfig.leftAlphas.Count)
            yield break;

        DOTween.To(
        () => animatingConfig.leftAlphas[i],
        z => animatingConfig.leftAlphas[i] = z,
        255,
        animatingConfig.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(animatingConfig.betweenHalf);

        DOTween.To(
        () => animatingConfig.rightAlphas[i],
        z => animatingConfig.rightAlphas[i] = z,
        255,
        animatingConfig.smoothTime).
        SetEase(Ease.Linear).
        SetId(1);
        yield return new WaitForSeconds(animatingConfig.betweenChar);
        StartCoroutine(Smooth(i + 1));
    }
}