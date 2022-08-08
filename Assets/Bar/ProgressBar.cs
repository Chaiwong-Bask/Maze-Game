using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    //private Image barImage;
    private RawImage barRawImage;
    private Progress progress;
    private RectTransform barMaskRectTransform;
    private float barMaskWidth;
    private RectTransform edgerectTransform;

    private void Awake()
    {
        //barImage = transform.Find("bar").GetComponent<Image>();
        barMaskRectTransform = transform.Find("barMask").GetComponent<RectTransform>();
        barRawImage = transform.Find("barMask").Find("bar").GetComponent<RawImage>();
        edgerectTransform = transform.Find("edge").GetComponent<RectTransform>();

        progress = new Progress();

        barMaskWidth = barMaskRectTransform.sizeDelta.x;

    }

    private void Update()
    {
        progress.Update();

        //barImage.fillAmount = progress.GetProgNormalized();

        Rect uvRect = barRawImage.uvRect;
        uvRect.x -= 1f * UnityEngine.Time.deltaTime;
        barRawImage.uvRect = uvRect;

        Vector2 barMaskSizeDelta = barMaskRectTransform.sizeDelta;
        barMaskSizeDelta.x = progress.GetProgNormalized() * barMaskWidth;
        barMaskRectTransform.sizeDelta = barMaskSizeDelta;

        edgerectTransform.anchoredPosition = new Vector2(progress.GetProgNormalized() * barMaskWidth, 0);

    }


}

public class Progress
{
    private const int PROG_MAAX = 100;

    private float progAmount;
    private float progRegenAmount;

    public Progress()
    {
        progAmount = 0;
        progRegenAmount = 30f;
    }

    public void Update()
    {
        progAmount += progRegenAmount * UnityEngine.Time.deltaTime;

        progAmount = Mathf.Clamp(progAmount, 0f, PROG_MAAX);
    }

    public float GetProgNormalized()
    {
        return progAmount / PROG_MAAX;
    }

}