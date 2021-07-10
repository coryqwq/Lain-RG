using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CircleController : MonoBehaviour
{
    public BoxCollider hitbox;
    public int[] points = { 50, 100, 200 };
    public float elasped;

    EventSystem eventSys;

    RippleEffect rippleEffectScript;
    // Start is called before the first frame update
    void Start()
    {
        rippleEffectScript = FindObjectOfType<RippleEffect>();
        eventSys = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(eventSys.currentSelectedGameObject == null)
        {
            eventSys.SetSelectedGameObject(gameObject);
        }
        elasped = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (elasped > 1f)
        {
            GameObject.Destroy(gameObject);
        }
    }

    public void Check()
    {
        if (Input.anyKey)
        {
            if (elasped <= 0.58f)
            {
                EnableHitBox(points[0]);
            }
            else if (elasped <= 0.83f)
            {
                EnableHitBox(points[1]);

            }
            else if (elasped <= 1f)
            {
                EnableHitBox(points[2]);
            }

        }
    }
    void EnableHitBox(int points)
    {
        hitbox.enabled = true;
        rippleEffectScript.Emit(Camera.main.WorldToViewportPoint(GetComponent<RectTransform>().transform.localPosition));
        Debug.Log(points);
        GameObject.Destroy(gameObject);
    }
}
