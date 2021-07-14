using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class GameState : MonoBehaviour
{
    EventSystem eventSys;
    HealthBar healthBarScript;
    public VideoPlayer videoPlayer;
    public GameObject video;

    public VideoClip[] videoClip;

    public bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        eventSys = FindObjectOfType<EventSystem>();
        healthBarScript = FindObjectOfType<HealthBar>();

        if (SceneManager.GetActiveScene().name == "TransitionScene")
        {
            StartCoroutine(DelaySceneLoad(2, "LevelScene"));
        }
        if (SceneManager.GetActiveScene().name == "FailScene")
        {
            StartCoroutine(DelaySceneLoad(3, "MenuScene"));
        }
        if (SceneManager.GetActiveScene().name == "WinScene")
        {
            SetVideoClip(PlayerPrefs.GetInt("level passed"));
            StartCoroutine(DelayStartVideo(3));
            StartCoroutine(DelaySceneLoad((float)videoPlayer.length + 3, "MenuScene"));
        }
    }

    void SetVideoClip(int index)
    {
        for (int i = 0; i < videoClip.Length; i++)
        {
            if (i == index)
            {
                videoPlayer.clip = videoClip[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSys.currentSelectedGameObject == null && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
            eventSys.SetSelectedGameObject(eventSys.firstSelectedGameObject);
        }

        if (healthBarScript != null)
        {
            if (healthBarScript.currentSize <= 0 && flag == false)
            {
                StartCoroutine(DelaySceneLoad(0, "FailScene"));
                flag = true;
            }
        }
    }

    IEnumerator DelaySceneLoad(float seconds, string sceneName)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator DelayStartVideo(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        video.SetActive(true);

        videoPlayer.Play();
    }
}
