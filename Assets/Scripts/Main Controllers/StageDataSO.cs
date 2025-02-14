using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Stage Data")]
public class StageDataSO : ScriptableObject
{
    //DATA

    //ASSOCIATED SCENE
    [Header("Data")]
    [Tooltip("String should match the exact Name of the Scene to target")]
    [SerializeField] private string associatedSceneName;


    //ENUM IDENTIFIER
    [Tooltip("Match this Stage Data to an identifier provided from a list of pre-determined values")]
    [SerializeField] private SceneNavigationController.eSceneName stageID;



    //DATA GETTERS
    public string AssociatedSceneName => associatedSceneName;
    public SceneNavigationController.eSceneName StageID => stageID;

}
