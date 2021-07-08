using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonFX : MonoBehaviour
{
    public Animator buttonAnim;

    public VideoClip[] preview;
    public VideoPlayer videoPlayer;
    public string[] buttonName;
    public GameObject video;

    public Text title;
    public Text artist;
    public string[] songTitle;
    public string[] songArtist;
    public void Highlight()
    {
        if (FindObjectOfType<EventSystem>().currentSelectedGameObject != gameObject)
        {
            FindObjectOfType<EventSystem>().SetSelectedGameObject(gameObject);
        }
        buttonAnim.SetBool("select", true);
    }

    public void Unhighlight()
    {
        buttonAnim.SetBool("select", false);
    }

    public void PlayPreview()
    {
        video.SetActive(true);
        for (int i = 0; i < preview.Length; i++)
        {
            if (gameObject.name == buttonName[i])
            {
                title.text = songTitle[i];
                artist.text = songArtist[i];

                videoPlayer.Stop();
                videoPlayer.clip = preview[i];
                videoPlayer.Play();
            }
        }
    }

    public void DisplayNull()
    {
        title.text = "NULL";
        artist.text = "NULL";

        videoPlayer.Stop();
        video.SetActive(false);
    }
}
