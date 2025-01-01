using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerDamageEventArgs : EntityDamageEventArgs
{
    //CONSTRUCTOR
    public PlayerDamageEventArgs(EDamageType damageType) : base(damageType){}
}
