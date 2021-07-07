using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EnableStartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject firstButton;
    bool flag = false;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BootCompoundStartMenu") && flag == false)
        {
            startMenu.SetActive(true);
            FindObjectOfType<EventSystem>().SetSelectedGameObject(firstButton);
            flag = true;
        }
    }
}
