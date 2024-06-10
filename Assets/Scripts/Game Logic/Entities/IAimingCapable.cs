using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAimingCapable
{
    public Vector2 AimingDirection();
    public Vector3 AimingDirection3D();
    public void SetAimTarget();
}
