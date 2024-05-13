using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: EVALUATE IMPROVING THIS BY USING A REQUIRED OR SOMETHING ELSE?
public class PlayerDirection : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] SpriteRenderer sprite;

    //DATA
    //TODO: ONCE ARCHITECTURE HAS BEEN IMPROVED, CHANGE VISIBILITY AND ORGANIZATION OF THESE DATA
    public Vector2 lastDirection2D = Vector2.up;





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
        Vector3 newDirection = this.transform.position + new Vector3(lastDirection2D.x, 0, lastDirection2D.y);
        transform.LookAt(newDirection);
    }

}
