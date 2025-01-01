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
        EventManager<PlayerDamageEventArgs>.Instance.StartListening(HandlePlayerDamageEvent);
    }

    private void OnDestroy()
    {
        EventManager<PlayerDamageEventArgs>.Instance.StartListening(HandlePlayerDamageEvent);
    }
    
    
    //EVENT HANDLING
    private void HandlePlayerDamageEvent(object sender, PlayerDamageEventArgs e){
        switch(e.DamageType){
            case EntityDamageEventArgs.EDamageType.HEALTH:
                healthBar.UpdateFill(e.PercentFill);
                break;
            case EntityDamageEventArgs.EDamageType.SHIELD:
                shieldBar.UpdateFill(e.PercentFill);
                break;
            default:
                Debug.LogError("Invalid Damage Type: " + e.DamageType);
                break;
        }
    }
    
}
