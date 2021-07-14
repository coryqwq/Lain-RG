using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class CircleSpawnManager : MonoBehaviour
{
    public GameObject circle;
    public float[] timestamp;
    public float elasped;
    public int index = 0;
    public float offset;
    string path;
    public string[] log;
    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Song Timestamps/");
        CreateFile();
        ReadAndConvertFile();
    }

    public void CreateFile()
    {
        path = Application.streamingAssetsPath + "/Song Timestamps/" + "Song" + PlayerPrefs.GetInt("level select") + ".txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }
    }

    public void ReadAndConvertFile()
    {
        log = File.ReadAllLines(path);
        timestamp = Array.ConvertAll(log, float.Parse);
    }

    public void WriteFile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(elasped);
            File.AppendAllText(path, elasped.ToString() + "\n");
        }
    }

    public void SpawnManager()
    {
        if (index < timestamp.Length && elasped >= timestamp[index] - offset)
        {
            SpawnCircle();
            index++;
        }
    }
    // Update is called once per frame
    void Update()
    {

        elasped += Time.deltaTime;

        WriteFile();
        //SpawnManager();
    }

    void SpawnCircle()
    {
        float xPos = UnityEngine.Random.Range(-6f, 6f);
        float yPos = UnityEngine.Random.Range(-4f, 4f);

        GameObject newCircle = Instantiate(circle, transform.position + new Vector3(xPos, yPos, 0), transform.rotation);
        newCircle.transform.SetParent(gameObject.transform);

    }
}
