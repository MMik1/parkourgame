// GrappelingGun script
using UnityEngine;

public class GrappelingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, Camera, Player;
    private float maxDistance = 50f;
    private SpringJoint joint;
    public float grappleForce = 5f;
    public float maxGrappleSpeed = 10f;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }

        // Move player towards grapple point while the grapple is active
        if (joint)
        {
            Vector3 grappleDirection = (grapplePoint - Player.position).normalized;
            Player.GetComponent<Rigidbody>().AddForce(grappleDirection * grappleForce, ForceMode.Impulse);

            // Limit the speed of the player
            LimitPlayerSpeed();
        }
    }

    private void LateUpdate()
    {
        // Draw the rope only when grappling
        if (IsGrappeling())
        {
            DrawRope();
        }
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = Player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(Player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void DrawRope()
    {
        lr.enabled = true;  // Enable the LineRenderer only when grappling
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    private void LimitPlayerSpeed()
    {
        Rigidbody playerRigidbody = Player.GetComponent<Rigidbody>();
        if (playerRigidbody)
        {
            float currentSpeed = playerRigidbody.velocity.magnitude;
            if (currentSpeed > maxGrappleSpeed)
            {
                // Clamp the speed to the maximum allowed speed
                playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxGrappleSpeed;
            }
        }
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

    public bool IsGrappeling()
    {
        return joint != null;
    }
}
