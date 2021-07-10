using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawnManager : MonoBehaviour
{
    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCircle", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCircle()
    {
        float xPos = Random.Range(-5f, 5f);
        float yPos = Random.Range(-3f, 3f);

        GameObject newCircle = Instantiate(circle, transform.position + new Vector3(xPos, yPos, 0), transform.rotation);
        newCircle.transform.SetParent(gameObject.transform);

    }
}
