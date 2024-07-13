using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public void HandleHit(DamageInstance dInstance);

    public void HandleDeath();
}
