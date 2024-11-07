using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [Header("Inspector References")]
    [SerializeField] PlayerActionController playerAction;
    [SerializeField] SpriteRenderer sprite;


    //DATA
    //...


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate()
    {
        if (playerAction == null)
            Debug.LogWarning("No PlayerController Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        if(sprite == null)
            Debug.LogWarning("No SpriteRenderer Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif





    //LIFECYCLE FUNCTIONS
    void Start()
    {
        //IMMEDIATELY ROTATE WHERE NEEDED
        UpdateDirection();
    }

    void Update()
    {
        //IMMEDIATELY ROTATE WHERE NEEDED
        UpdateDirection();
    }



    //FUNCTIONALITIES
    private void UpdateDirection() => transform.LookAt(this.transform.position + playerAction.AimingDirection3D());

}
