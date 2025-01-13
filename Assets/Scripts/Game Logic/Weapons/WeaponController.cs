using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    //DATA
    [Header("Inspector References")]
    [Tooltip("Reference to an enemy or player script. Necessary for complex logic to work.")]
    [SerializeField] protected EntityWithAiming aimingEntity;


    //DATA GETTER
    abstract protected WeaponData WData { get; }


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        if (WData == null)
            Debug.LogWarning("No Weapon Data Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        else if((aimingEntity == null) && WData.NeedsOwnerToOperate)
            Debug.LogWarning("No Aiming Entity Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //LIFECYCLE FUNCTIONS
    //TODO: IMPLEMENT COOLDOWN HANDLING AND OTHER THINGS?



    //FUNCTIONALITIES
    public virtual void Operate()
    {
        if(WData.WAudioData)
        {
            //UNBOUND AUDIO EMISSION
            //WData
            //TODO: THIS MIGHT NEED TO DELVE INTO WData AND PICK UP WETHER THE USER IS UNBOUND, PLAYER OR ELSE
            EventManager<SoundFXEventArgs>.Instance.Notify(
                this, 
                new SoundFXEventArgs(SoundFXEventArgs.EType.UNBOUND, WData.WAudioData.OperateClip)
            );
        }
    }
    
    public virtual void Release(){
        
    }
}
