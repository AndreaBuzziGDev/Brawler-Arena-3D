using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] PlayerController player;
    [SerializeField] SpriteRenderer sprite;
    

    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (player == null)
            Debug.LogWarning("No PlayerController Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(sprite == null)
            Debug.LogWarning("No SpriteRenderer Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //DATA
    //...



    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //IMMEDIATELY ROTATE WHERE NEEDED
        UpdateDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //IMMEDIATELY ROTATE WHERE NEEDED
        UpdateDirection();
    }



    //FUNCTIONALITIES
    private void UpdateDirection()
    {
        //lastDirection
        //TODO: CAN THIS BE OPTIMIZED?
        //YES, BY GETTING EULERS (WHICH ALSO FIT WHAT CRISTIANO DID DURING LESSONS) AND USING TRANSFORM.ROTATE(VECTOR 3 OF EULERS)
        Vector2 aimedDirection = player.AimingDirection();
        Vector3 newDirection = this.transform.position + new Vector3(aimedDirection.x, 0, aimedDirection.y);
        transform.LookAt(newDirection);
    }

}
