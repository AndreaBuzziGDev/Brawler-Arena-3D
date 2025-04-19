using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomUITextureImporter : AssetPostprocessor {
    void OnPreprocessTexture() {
        if (assetPath.Contains("Sprites/UI")) {
            TextureImporter importer = assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;

            //TODO: USE DEBUGGER
            Debug.Log("Processed: " + assetPath + " as UI Sprite");
        }
    }
}
