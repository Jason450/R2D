using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceButton : MonoBehaviour
{
    public float current;
    public float start;
    public float end;
    public float desired;
    public float delay;
    bool active;

    RectTransform transf;

    private void Start()
    {
        transf = this.gameObject.GetComponent<RectTransform>();
        active = false;
    }

    void Update()
    {
        if(active)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
                return;
            }

            current += Time.deltaTime;

            if (current <= desired)
            {
                float value;

                value = Easing.ElasticEaseOut(current, start, end - start, desired);

                transf.localScale = new Vector3(value, value, 1);
            }

            if (current >= desired)
            {
                active = false;
                current = 0;
            }
        }
    }

    public void Active()
    {
        active = true;
    }
}
