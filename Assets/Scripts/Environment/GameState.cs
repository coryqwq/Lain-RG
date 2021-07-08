using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameState : MonoBehaviour
{
    EventSystem eventSys;
    // Start is called before the first frame update
    void Start()
    {
        eventSys = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(eventSys.currentSelectedGameObject == null && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            eventSys.SetSelectedGameObject(eventSys.firstSelectedGameObject);
        }
    }
}
