using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameHUDLeft : MonoBehaviour
{
    //DATA
    PlayerController pc;
    

    [Header("Inspector References")]
    [SerializeField] private UI_FilledBar healthBar;
    [SerializeField] private UI_FilledBar shieldBar;

    // Start is called before the first frame update
    private void Start()
    {
        EventManager<EntityDamageEventArgs>.Instance.StartListening(HandlePlayerDamageEvent);
    }

    private void OnDestroy()
    {
        EventManager<EntityDamageEventArgs>.Instance.StartListening(HandlePlayerDamageEvent);
    }
    
    
    //EVENT HANDLING
    private void HandlePlayerDamageEvent(object sender, EntityDamageEventArgs e){
        switch(e.DamageType){
            case EntityDamageEventArgs.EDamageType.HEALTH:
                healthBar.UpdateFill(10.0f);
                break;
            case EntityDamageEventArgs.EDamageType.SHIELD:
                shieldBar.UpdateFill(10.0f);
                break;
            default:
                Debug.LogError("Invalid Damage Type: " + e.DamageType);
                break;
        }
    }
    
}
