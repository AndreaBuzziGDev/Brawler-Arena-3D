using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FilledBar : MonoBehaviour {
    //DATA


    [Header("Inspector References")]
    [SerializeField] Image filledImage;


    //REFERENCE VALIDATION
#if UNITY_EDITOR
    protected void OnValidate() {
        if (filledImage == null)
            Debug.LogWarning("No Filled Image assigned on GameObject " + gameObject.name + " of type " + this.GetType(), this);
    }
#endif



    //FUNCTIONALITIES
    public void UpdateFill(float fillAmount) {
        if (filledImage != null) {
            filledImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}
