using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpinner : MonoBehaviour
{
    //DATA
    [SerializeField] float spinningSpeed = 10;//IN EULERS

    // Update is called once per frame
    void FixedUpdate()
    {
        //SPINS AT A GIVEN SPEED
        transform.Rotate(new Vector3(0,spinningSpeed * Time.fixedDeltaTime,0));
    }
}
