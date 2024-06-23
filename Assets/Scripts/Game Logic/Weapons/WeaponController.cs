using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    //INSPECTOR REFERENCES
    [SerializeField] protected WeaponAudioData weaponAudioData;
    [SerializeField] protected IAimingCapable aimingEntity;


    //DATA GETTER
    abstract protected WeaponData WData { get; }

    
    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        if(WData == null)
            Debug.LogError("This Weapon doesn't have any data: " + gameObject.name);
        else if((aimingEntity == null) && WData.NeedsOwnerToOperate)
            Debug.LogError("This Weapon doesn't have holder: " + gameObject.name);
        //TODO: IMPLEMENT COOLDOWN HANDLING AND OTHER THINGS?
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: HANDLE COOLDOWN AND OTHER STUFF?
        
    }



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
