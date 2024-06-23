using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSBombController : WeaponController
{
    //INSPECTOR REFERENCES
    [SerializeField] protected WeaponSBombData wData;


    //DATA GETTER
    override protected WeaponData WData { get { return wData; } }


    //FUNCTIONALITIES
    public override void Operate(){
        base.Operate();
        
        if(WData)
        {
            //FIND ALL HITTABLES IN A RADIUS
            //TODO: POLISH AND/OR EXTRACT AS A UTILITY OR OTHER KIND OF FUNCTIONALITY (LIKELY TO BE USED ELSEWHERE)
            UtilsDetection.DetectionInfos dInfo = UtilsDetection.DetectColliders(transform.position, wData.EffectiveRadius);
            
            //DAMAGE INSTANCE
            DamageInstance dInstance = new DamageInstance(WData);

            //DAMAGE DEALING - PLAYER
            if(dInfo.Player != null)
                dInfo.Player.HandleHit(dInstance);
            
            //DAMAGE DEALING - FRIENDLY FIRE
            if(wData.HasFriendlyFire)
                foreach(IHittable hitbl in dInfo.Hittables)
                    hitbl.HandleHit(dInstance);
            
            //SELF-DESTRUCT
            if(ownerEntity) 
                ownerEntity.HandleDeath();
        }
    }
}
