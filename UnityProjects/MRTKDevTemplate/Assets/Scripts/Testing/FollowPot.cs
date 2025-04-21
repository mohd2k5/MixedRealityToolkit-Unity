using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPot : MonoBehaviour
{
    public Transform targetPot;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    void LateUpdate()
    {
        if (targetPot != null)
        {
            transform.position = targetPot.position + targetPot.TransformVector(positionOffset);
            transform.rotation = targetPot.rotation * Quaternion.Euler(rotationOffset);
        }
    }
}

