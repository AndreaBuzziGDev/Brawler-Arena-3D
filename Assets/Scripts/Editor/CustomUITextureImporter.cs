using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomUITextureImporter : AssetPostprocessor
{
    void OnPreprocessTexture(){
        //TODO: COULD THIS BE EXPANDED FURTHER?
        //      YES, IT CAN BE EXPANDED UPON BY DEFINING HELPER CLASSES THAT HANDLE LOGIC BASED ON SEVERAL CRITERIA
        if(assetPath.Contains("Sprites/UI")){
            TextureImporter importer = assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;

            Debug.Log("Processed: " + assetPath + " as UI Sprite");
        }
    }
}
