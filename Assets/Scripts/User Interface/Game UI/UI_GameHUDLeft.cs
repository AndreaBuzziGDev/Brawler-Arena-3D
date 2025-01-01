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
        pc = GameController.Instance.GetPlayerAnywhere;
        if (pc != null)
        {
            pc.PlayerHealthAndShield.OnHealthChanged += healthBar.UpdateFill;
            pc.PlayerHealthAndShield.OnShieldChanged += shieldBar.UpdateFill;
        }
    }

    private void OnDestroy()
    {
        if (pc != null)
        {
            pc.PlayerHealthAndShield.OnHealthChanged -= healthBar.UpdateFill;
            pc.PlayerHealthAndShield.OnShieldChanged -= shieldBar.UpdateFill;
        }
    }
}
