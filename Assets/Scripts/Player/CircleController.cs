using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CircleController : MonoBehaviour
{
    public BoxCollider hitbox;
    public float[] points = { 5, 10, 20 };
    public int flag;
    public float elasped;

    EventSystem eventSys;
    RippleEffect rippleEffectScript;
    HealthBar healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        eventSys = FindObjectOfType<EventSystem>();
        rippleEffectScript = FindObjectOfType<RippleEffect>();
        healthBarScript = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSys.currentSelectedGameObject == null)
        {
            eventSys.SetSelectedGameObject(gameObject);
        }
        elasped = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (elasped > 1f)
        {
            GameObject.Destroy(gameObject);
            healthBarScript.currentSize -= points[2];
        }
    }
    public void SetFlag0()
    {
        flag = 1;
    }

    public void SetFlag1()
    {
        flag = 2;
    }

    public void SetFlag2()
    {
        flag = 3;
    }

    public void Check()
    {
        switch (flag)
        {
            case 1:
                EnableHitBox(points[0]);
                break;
            case 2:
                EnableHitBox(points[1]);
                break;
            case 3:
                EnableHitBox(points[2]);
                break;
            default:
                healthBarScript.currentSize -= points[2];
                EnableHitBox(0);
                break;
        }

    }
    void EnableHitBox(float points)
    {
        hitbox.enabled = true;
        rippleEffectScript.Emit(Camera.main.WorldToViewportPoint(GetComponent<RectTransform>().transform.localPosition));
        if(healthBarScript.currentSize + points >= healthBarScript.maxSize)
        {
            points = healthBarScript.maxSize - healthBarScript.currentSize;
        }
        healthBarScript.currentSize += points;
        GameObject.Destroy(gameObject);
    }
}
