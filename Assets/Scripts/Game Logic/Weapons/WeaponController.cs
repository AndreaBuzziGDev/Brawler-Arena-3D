using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] protected WeaponAudioData weaponAudioData;
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
        if(weaponAudioData)
        {
            //UNBOUND AUDIO EMISSION
            EventManager<SoundFXEventArgs>.Instance.Notify(this, new SoundFXEventArgs(SoundFXEventArgs.EType.UNBOUND, weaponAudioData.OperateClip));
        }
    }
}
