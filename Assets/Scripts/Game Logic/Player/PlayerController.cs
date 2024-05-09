using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //DATA
    float currentHealth = 1;
    float currentShield = 1;
    
    float maxHealth = 1;
    float maxShield = 1;

    //SCRIPTABLE OBJECTS
    



    //INPUT
    GameInputAction inputPlayer = new GameInputAction();

    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        inputPlayer.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //FUNCTIONALITIES



    //UTILITIES


}
