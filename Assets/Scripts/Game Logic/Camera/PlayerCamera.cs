using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //DATA
    [SerializeField] Transform cameraTarget;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] float verticalOffset;
    [SerializeField] float damping = 1.0f;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (cameraTarget == null)
            Debug.LogWarning("No Camera Target Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //
    Camera cameraComp;
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
