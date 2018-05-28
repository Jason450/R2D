using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMenu : MonoBehaviour
{
    public float current;
    public float start;
    public float end;
    public float desired;
    public float delay;

    RectTransform transf;

    private void Start()
    {
        transf = this.gameObject.GetComponent<RectTransform>();
    }

    void Update ()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        current += Time.deltaTime;

        if(current <= desired)
        {
            float value;

            value = Easing.ElasticEaseOut(current, start, end - start, desired);

            transf.localPosition = new Vector3(this.gameObject.transform.position.x, value, 0);
        }
	}
}
