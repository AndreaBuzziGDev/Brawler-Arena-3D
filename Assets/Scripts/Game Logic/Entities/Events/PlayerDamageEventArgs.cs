using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerDamageEventArgs : EntityDamageEventArgs {
    //CONSTRUCTOR
    public PlayerDamageEventArgs(EDamageType damageType, float maxFill, float currentFill) : base(damageType, maxFill, currentFill) { }
}
