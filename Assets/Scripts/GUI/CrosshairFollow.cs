using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CrosshairFollow : MonoBehaviour
{
    public float duration;
    public float elasped;

     GameObject currentSelectedButton;
     GameObject nextSelectedButton;

    public Vector2 a;
    public Vector2 b;

    bool flag = false;
    // Update is called once per frame
    void Update()
    {
        //set reference for current button
        if(flag == false)
        {
            currentSelectedButton = FindObjectOfType<EventSystem>().currentSelectedGameObject;
            flag = true;
        }
        //set reference for other button when player switches buttons
        nextSelectedButton = FindObjectOfType<EventSystem>().currentSelectedGameObject;

        //reset elasped when current button is set to different button
        if(currentSelectedButton != nextSelectedButton)
        {
            elasped = 0;
            flag = false;
        }

        //set the references for current crosshair position and current button position
        if (currentSelectedButton != null)
        {
            a = gameObject.GetComponent<RectTransform>().anchoredPosition;
            b = currentSelectedButton.GetComponent<RectTransform>().anchoredPosition;
        }

        //lerp crosshair position to current button position
        if (a != b && elasped <= duration)
        {
            elasped += Time.deltaTime;
            gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.LerpUnclamped(a, b, elasped / duration);

        }
        else
        {
            elasped = 0;
        }
    }
}
