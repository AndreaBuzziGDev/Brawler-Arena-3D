using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //DATA
    [Header("Inspector References")]
    [SerializeField] Transform cameraTarget;
    [SerializeField] Vector3 cameraOffset;

    [Header("Camera Parameters")]
    [Tooltip("How many units of vertical offset this has compared to its target.")]
    [SerializeField] float verticalOffset;

    [Tooltip("Adjusts delay in camera orientation.")]
    [SerializeField] float damping = 1.0f;


    Camera cameraComp;//TODO: ENFORCE REQUIREMENT LIKE I ALREADY DID SOMEWHERE ELSE
    float baseFOV;


    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        cameraComp = gameObject.GetComponent<Camera>();
        baseFOV = cameraComp.fieldOfView;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(cameraTarget)
            FollowTarget();
    }


    //FUNCTIONALITIES
    private void FollowTarget()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position + cameraOffset, Time.deltaTime * damping);
        transform.LookAt(cameraTarget.position - new Vector3(0, verticalOffset, 0), Vector3.up);
    }

}
