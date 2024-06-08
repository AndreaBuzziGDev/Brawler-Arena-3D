using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVALUATE IMPROVING THIS BY USING A REQUIRED OR SOMETHING ELSE?
public class PlayerDirection : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] PlayerController player;
    [SerializeField] SpriteRenderer sprite;

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
        Vector2 aimedDirection = player.AimingDirection;
        Vector3 newDirection = this.transform.position + new Vector3(aimedDirection.x, 0, aimedDirection.y);
        transform.LookAt(newDirection);
    }

}
