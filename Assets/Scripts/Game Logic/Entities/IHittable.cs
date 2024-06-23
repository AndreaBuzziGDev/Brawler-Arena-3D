using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    public void HandleHit(DamageInstance dInstance);

    //TODO: THIS SHOULD PROBABLY DEFINE A DELEGATE OR SOME OTHER STRATEGY
    //TODO: THIS COULD BE IN ITS OWN INTERFACE
    public void HandleDeath();//TODO: THIS SHOULD NOT BE PUBLIC
}
