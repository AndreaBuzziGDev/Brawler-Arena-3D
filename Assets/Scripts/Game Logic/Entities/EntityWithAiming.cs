using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: THIS SHOULD REALLY BECOME AN ABSTRACT CLASS EXTENDED BY PlayerController AND ANOTHER SCRIPT WITH REFACTORED EnemyController CODE
public class EntityWithAiming : MonoBehaviour, IAimingCapable
{
    //INSPECTOR REFERENCES
    [SerializeField] EntityWithHealth ownerEntity;

    //DATA
    protected Vector2 aimingDirection;



    //IAimingCapable CONCRETIZATION
    public virtual Vector2 AimingDirection() => aimingDirection.normalized;
    public virtual Vector3 AimingDirection3D() => new Vector3(aimingDirection.x, 0, aimingDirection.y).normalized;
    public virtual void SetAimTarget() => Debug.LogError("No aiming implemented.");
    public virtual void HandleSelfDestruction() => ownerEntity.HandleDeath();



}
