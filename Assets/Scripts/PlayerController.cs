using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform TargetObjectTF;
    //[Range(1.0f, 6.0f)] public float TargetRadius;
    [SerializeField] private LineRenderer lineRenderer;
    [Range(20.0f, 75.0f)] public float LaunchAngle;

    //private Rigidbody rigid;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;    
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 projectileXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vector3 targetXZPos = new Vector3(TargetObjectTF.position.x, 0.0f, TargetObjectTF.position.z);

        // rotate the object to face the target
        transform.LookAt(targetXZPos);

        // shorthands for the formula
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(LaunchAngle * Mathf.Deg2Rad);
        float H = TargetObjectTF.position.y - transform.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        // create the velocity vector in local space and get it in global space
        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity and flipping its state

        transform.position = localVelocity;

        //rigid.velocity = globalVelocity;
    }

    /*void DrawPath(float vo, float angle, int step)
    {
        int totalTime = 10;

        lineRenderer.positionCount = (int) (totalTime / step) + 2;
        for(int i = 0; i < totalTime; i += step)
        {
            
        }
    }*/
}
