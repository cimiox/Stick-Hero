using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectsFactoryEditor 
{
    #region Public methods
    [MenuItem("ScriptableObjects/Stick Parameters")]
    public static void CreateAssetStickParameters()
    {
        ScriptableObjectUtility.CreateAsset<StickParameters>();
    } 
    #endregion
}
