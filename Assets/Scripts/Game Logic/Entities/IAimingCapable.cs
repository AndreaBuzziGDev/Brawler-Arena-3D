using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingCapable
{
    public Vector2 AimingDirection();
    public void SetAimTarget();
}
