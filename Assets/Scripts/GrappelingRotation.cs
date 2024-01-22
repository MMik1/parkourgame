// GrapplingRotation script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingRotation : MonoBehaviour
{
    public GrappelingGun grappling;

    private Quaternion desiredRotation;
    private float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (!grappling.IsGrappeling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }
}
