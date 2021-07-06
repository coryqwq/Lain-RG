using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public Animator buttonAnim;
    public void AuthorizeUserOn()
    {
        buttonAnim.SetBool("select", true);
    }
    public void AuthorizeUserOff()
    {
        buttonAnim.SetBool("select", false);
    }
    public void LoadDataOn()
    {
        buttonAnim.SetBool("select", true);
    }
    public void LoadDataOff()
    {
        buttonAnim.SetBool("select", false);
    }


}
