using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public RectTransform healthBar;
    public float maxSize;
    public float currentSize;
    public float speed;

    private void Start()
    {
        maxSize = healthBar.sizeDelta.x;
        currentSize = healthBar.sizeDelta.x;
    }
    // Update is called once per frame
    void Update()
    {
        currentSize -= Time.deltaTime * speed;
        healthBar.sizeDelta = new Vector2(currentSize, healthBar.sizeDelta.y);
    }
}
