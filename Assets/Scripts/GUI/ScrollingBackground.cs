using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public int speed;
    public float distance;
    public float maxDistance;
    Vector3 startPos;
    Quaternion startAngle;

    bool flag = false;
    private void Start()
    {
        startPos = transform.position;
        startAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed, transform);
       
        if (Mathf.Abs(startPos.x - transform.position.x) >= distance && flag == false)
        {
            Instantiate(gameObject, startPos, startAngle);
            flag = true;
        }
        if (Mathf.Abs(startPos.x - transform.position.x) >= maxDistance)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
