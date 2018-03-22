using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEasingNoLoop : MonoBehaviour
{
    public enum Type { EXPO, CIRC, QUINT, QUART, QUAD, SINE, BACK, BOUNCE, ELASTIC }
    public Type type;

    public Vector3 iniValue;
    public Vector3 finalValue;
    Vector3 deltaValue;
    public float currentTime;
    public float timeDuration;

    public float startDelay;

    void Start()
    {
        deltaValue = finalValue - iniValue;
        currentTime = 0;
    }

    void Update()
    {
        startDelay -= Time.deltaTime;

        if(startDelay <= 0)
        {
            startDelay = 0;
            if(currentTime <= timeDuration)
            {
                //DO EASING
                Vector3 easingValue = new Vector3();
                switch(type)
                {
                    case Type.EXPO:
                        easingValue = new Vector3(
                            Easing.ExpoEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.ExpoEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.ExpoEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.CIRC:
                        easingValue = new Vector3(
                            Easing.CircEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.CircEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.CircEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUINT:
                        easingValue = new Vector3(
                            Easing.QuintEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.QuintEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.QuintEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUART:
                        easingValue = new Vector3(
                            Easing.QuartEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.QuartEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.QuartEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUAD:
                        easingValue = new Vector3(
                            Easing.QuadEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.QuadEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.QuadEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.SINE:
                        easingValue = new Vector3(
                            Easing.SineEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.SineEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.SineEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.BACK:
                        easingValue = new Vector3(
                            Easing.BackEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.BackEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.BackEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.BOUNCE:
                        easingValue = new Vector3(
                            Easing.BounceEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.BounceEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.BounceEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.ELASTIC:
                        easingValue = new Vector3(
                            Easing.ElasticEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                            Easing.ElasticEaseInOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                            Easing.ElasticEaseInOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    default:
                        break;
                }
                //easingValue.x = Easing.ExpoEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration);
                //easingValue.x = Easing.BounceEaseInOut(currentTime, iniValue.x, deltaValue.x, timeDuration);

                transform.localRotation = Quaternion.Euler(easingValue);

                currentTime += Time.deltaTime;

                if(currentTime > timeDuration)
                {
                    Debug.Log("EL EASING HA TERMINADO JUSTO AHORA");
                }
            }
            else
            {
                Debug.Log("EL EASING HA TERMINADO HACE RATO YA");
            }
        }
    }
}
