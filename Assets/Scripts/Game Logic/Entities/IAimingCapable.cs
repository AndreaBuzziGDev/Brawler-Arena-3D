using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingCapable
{
    public Vector2 AimingDirection();
    public Vector3 AimingDirection3D();
    public void SetAimTarget();
    public void HandleSelfDestruction();//TODO: THIS NEEDS TO BE SOLVED. SHOULD NOT BE PUBLIC BUT STILL NEEDS ACCESSIBILITY
    //SHOULD PROBABLY REQUIRE IMPLEMENTING A RETURNABLE OF EntityWithHealth WHO CAN THEN BE MADE SELF-DESTRUCT
    //A POSSIBILITY MIGHT BE TO REMOVE THIS AND MAKE THE ROOT GAMEOBJECT DESTROY INSTEAD.
}
