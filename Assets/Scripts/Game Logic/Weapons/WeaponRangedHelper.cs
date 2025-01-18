using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRangedHelper
{
    //DATA
    bool isOperating = false;
    float attackTimer = 0.0f;
    bool readyToShoot = true;
    float threshold = 1;
    
    
    //CONSTRUCTOR
    //TODO: THIS EVENTUALLY CAN BE MODIFIED TO HANDLE GENERALIZATION OF LOGIC
    public WeaponRangedHelper(WeaponRangedData wData){
        //
        threshold = 1.0f/wData.AttackRate;
        
    }
    
    
    //FUNCTIONALITIES
    //TODO: METHOD THAT HANDLES TIMER LOGIC
    //TODO: METHOD THAT HANDLES SHOOTING LOGIC
    //...
    
    

}
