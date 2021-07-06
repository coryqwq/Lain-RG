using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableStartMenu : MonoBehaviour
{
    public GameObject startMenu;
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BootCompoundStartMenu"))
        {
            startMenu.SetActive(true);
        }
    }
}
