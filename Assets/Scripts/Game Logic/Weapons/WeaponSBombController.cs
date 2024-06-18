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
            List<IHittable> hittables = new();
            PlayerController pc = null;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, wData.EffectiveRadius);
            foreach (var hitCollider in hitColliders)
            {
                IHittable hitOther = hitCollider.gameObject?.GetComponent<IHittable>();
                if(hitOther != null)
                {
                    if(hitOther is PlayerController controller)
                        pc = controller;
                    else if(wData.HasFriendlyFire)
                        hittables.Add((IHittable) hitOther);
                }
            }
            
            //DAMAGE INSTANCE
            DamageInstance dInstance = new DamageInstance(WData);

            //DAMAGE DEALING
            if(pc != null)
                pc.HandleHit(dInstance);

            foreach(IHittable hitbl in hittables)
                hitbl.HandleHit(dInstance);
            
            //SELF-DESTRUCT
            if(ownerEntity) 
                ownerEntity.HandleDeath();
        }
    }
}
