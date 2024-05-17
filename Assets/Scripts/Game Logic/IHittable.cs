using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public void HandleHit(DamageInstance dInstance);

    //TODO: THIS SHOULD PROBABLY DEFINE A DELEGATE OR SOME OTHER STRATEGY
    public void HandleDeath();
}
