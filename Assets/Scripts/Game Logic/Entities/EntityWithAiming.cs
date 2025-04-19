using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityWithAiming : MonoBehaviour, IAimingCapable {
    //DATA
    protected Vector2 aimingDirection;

    //IAimingCapable CONCRETIZATION
    public virtual Vector2 AimingDirection() => aimingDirection.normalized;
    public virtual Vector3 AimingDirection3D() => new Vector3(aimingDirection.x, 0, aimingDirection.y).normalized;
    public virtual void SetAimTarget() => Debug.LogError("No aiming implemented.");
}
