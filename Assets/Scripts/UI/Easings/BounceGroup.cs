using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGroup : MonoBehaviour
{
    public float current;
    public float start;
    public float end;
    public float desired;
    public float delay;

    bool active;

    Transform transf;

    private void Start()
    {
        transf = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (active)
        {
            if (delay > 0)
            {
                delay -= Time.unscaledDeltaTime;
                return;
            }

            current += Time.unscaledDeltaTime;

            if (current <= desired)
            {
                float value;

                value = Easing.ElasticEaseOut(current, start, end - start, desired);

                transf.localPosition = new Vector3(this.gameObject.transform.localPosition.x, value, 0);
            }

            if (current >= desired)
            {
                active = false;
                current = 0;
                transf.localPosition = new Vector3(this.gameObject.transform.localPosition.x, end, 0);
            }
        }
        //else
        //{
        //    if (transf.localPosition.y >= 1000)
        //    {
        //        this.gameObject.SetActive(false);
        //    }
        //}
    }

    public bool Active { set { active = value; } }
}
