using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] Image backgroundImage;
    [SerializeField] Color32 onColor;
    [SerializeField] Color32 offColor;

    bool isOn;

    [SerializeField] RectTransform handleTransform;
    [SerializeField] float handlePos;
    [SerializeField] float moveSpeed;

    bool isMove;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isMove)
        {
            // ONÇ∆OFFÇÃêÿÇËë÷Ç¶
            isOn = !isOn;
            // UIÇÃå©ÇΩñ⁄ÇïœçX
            UpdateUI();
            // êÿÇËë÷Ç¶éûÇÃèàóùÇé¿çs
            OnClick();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        Vector2 endPos;
        if (isOn)
        {
            endPos = new Vector2(handlePos, handleTransform.anchoredPosition.y);
            backgroundImage.color = onColor;
        }
        else
        {
            endPos = new Vector2(-handlePos, handleTransform.anchoredPosition.y);
            backgroundImage.color = offColor;
        }
        StartCoroutine(SmoothMove(handleTransform.anchoredPosition, endPos));
    }

    IEnumerator SmoothMove(Vector2 startPos, Vector2 endPos)
    {
        isMove = true;
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            handleTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
        handleTransform.anchoredPosition = endPos;
        isMove = false;
    }


    void OnClick()
    {
        if (isOn)
        {
            Debug.Log("ON");
        }
        else
        {
            Debug.Log("OFF");
        }
    }
}
