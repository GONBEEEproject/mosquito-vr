using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{
    [SerializeField]
    Transform leftHand, rightHand, head;
    Vector3 lookForward;

    [SerializeField]
    float flyThreshold;

    [SerializeField]
    AnimationCurve accelCurve;
    float accelTime;
    bool isAccel;

    float speed;
    float handDistance;

    private void Update()
    {
        SpeedCheck();
        ForwardCheck();

        if (handDistance >= flyThreshold)
        {
            accelTime += Time.deltaTime;
            if (accelTime >= accelCurve[accelCurve.length - 1].time)
            {
                accelTime = accelCurve[accelCurve.length - 1].time;
            }
        }
        else
        {
            accelTime -= Time.deltaTime;
            if (accelTime <= 0)
            {
                accelTime = 0;
            }
        }

        speed = accelCurve.Evaluate(accelTime);
    }

    private void SpeedCheck()
    {
        handDistance = Vector3.Distance(leftHand.position, rightHand.position);
    }

    private void ForwardCheck()
    {
        lookForward = head.forward;
    }

}
