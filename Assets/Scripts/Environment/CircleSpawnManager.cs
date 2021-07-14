using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnManager : MonoBehaviour
{
    public GameObject circle;
    public float[] timestamp;
    public float elasped;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnCircle", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        elasped += Time.deltaTime;

        if(index < timestamp.Length && elasped >= timestamp[index])
        {
            SpawnCircle();
            index++;
        }
    }

    void SpawnCircle()
    {
        float xPos = Random.Range(-6f, 6f);
        float yPos = Random.Range(-4f, 4f);

        GameObject newCircle = Instantiate(circle, transform.position + new Vector3(xPos, yPos, 0), transform.rotation);
        newCircle.transform.SetParent(gameObject.transform);

    }
}
