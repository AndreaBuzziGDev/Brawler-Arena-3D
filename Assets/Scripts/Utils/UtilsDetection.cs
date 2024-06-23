using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsDetection 
{
    public static DetectionInfos DetectColliders(Vector3 position, float radius)
    {
        //DATA
        List<IHittable> hittables = new();
        PlayerHittable pc = null;

        //DETECTION LOGIC
        Collider[] hitColliders = Physics.OverlapSphere(position, radius);
        foreach (var hitCollider in hitColliders)
        {
            IHittable hitOther = hitCollider.gameObject?.GetComponent<IHittable>();
            if(hitOther != null)
            {
                if(hitOther is PlayerHittable controller)
                    pc = controller;
                else 
                    hittables.Add((IHittable) hitOther);
            }
        }

        return new DetectionInfos(pc, hittables);
    }
    
    //NESTED CLASSES
    public class DetectionInfos
    {
        public PlayerHittable Player { get; }
        public List<IHittable> Hittables { get; }

        public DetectionInfos(PlayerHittable playerInfo, List<IHittable> hittableInfo)
        {
            this.Player = playerInfo;
            this.Hittables = hittableInfo;
        }
    }
}
