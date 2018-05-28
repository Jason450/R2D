using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBoingGroupX : MonoBehaviour
{
    public float current;
    public float start;
    public float end;
    public float desired;
    public float delay;
    float initialY;
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
                delay -= Time.deltaTime;
                return;
            }

            current += Time.deltaTime;

            if (current <= desired)
            {
                float value;

                value = Easing.Linear(current, start, end - start, desired);

                transf.localPosition = new Vector3(value, transf.localPosition.y, 0);
            }

            if (current >= desired)
            {
                active = false;
                current = 0;
                transf.localPosition = new Vector3(end, transf.localPosition.y, 0);
            }
        }
    }

    public bool Active { set { active = value; } }
}
