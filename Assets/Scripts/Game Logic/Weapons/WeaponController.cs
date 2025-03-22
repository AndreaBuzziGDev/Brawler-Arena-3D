using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    //DATA
    [Header("Instance Data")]
    //NONE...
    

    //INSPECTOR REFERENCES
    [Header("Inspector References")]
    [Tooltip("Reference to an enemy or player script. Necessary for complex logic to work.")]
    [SerializeField] protected EntityWithAiming aimingEntity;


    //DATA GETTER
    abstract protected WeaponData WData { get; }


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected virtual void OnValidate(){
        if (WData == null)
            Debug.LogWarning("No Weapon Data Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
        else if((aimingEntity == null) && WData.NeedsOwnerToOperate)
            Debug.LogWarning("No Aiming Entity Assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //LIFECYCLE FUNCTIONS



    //FUNCTIONALITIES
    public virtual void Operate(){
        if(WData.WAudioData){
            //UNBOUND AUDIO EMISSION
            //WData
            //TODO: THIS MIGHT NEED TO DELVE INTO WData AND PICK UP WETHER THE USER IS UNBOUND, PLAYER OR ELSE
            //TODO: THIS SOUND SHOULD REFRESH EVERY TIME A SHOT HAPPENS, SO THE CURRENT UNIFIED AUDIO ARCHITECTURE DOESN'T SUPPORT THE INTENDED BEHAVIOUR AS OF YET.
            //      CURRENTLY, THE AUDIO GETS REPEATED WHEN IT ENDS.
            
            //TODO: AUDIO CLIP DATA
            EventManager<SoundFXEventArgs>.Instance.Notify(
                this, 
                new SoundFXEventArgs(WData.WAudioData.OperateClipData)
            );
        }
        
        //TODO: USE OperateCooldownClipData
        
        //TODO: USE HitClipData
        
    }
    
    public virtual void Release(){
        
    }
}
