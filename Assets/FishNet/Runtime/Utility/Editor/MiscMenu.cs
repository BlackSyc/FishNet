﻿#if UNITY_EDITOR
using FishNet.Editing;
using FishNet.Object;
using FishNet.Utility.Extension;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Utility.Editing
{


    public class RebuildSceneIdMenu : MonoBehaviour
    {
        /// <summary>
        /// Rebuilds sceneIds for open scenes.
        /// </summary>
        [MenuItem("Fish-Networking/Rebuild SceneIds", false, 20)]
        static void RebuildSceneIds()
        {
            int generatedCount = 0;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene s = SceneManager.GetSceneAt(i);
                int count;
                List<NetworkObject> nobs = SceneFN.GetSceneNetworkObjects(s, out count);
                for (int z = 0; z < count; z++)
                {
                    nobs[z].TryCreateSceneID();
                    EditorUtility.SetDirty(nobs[z]);
                }
                generatedCount += count;
            }

            Debug.Log($"Generated sceneIds for {generatedCount} objects over {SceneManager.sceneCount} scenes. Please save your open scenes.");
        }


    }

    public class RefreshDefaultPrefabsMenu : MonoBehaviour
    {
        /// <summary>
        /// Rebuilds the DefaultPrefabsCollection file.
        /// </summary>
        [MenuItem("Fish-Networking/Refresh Default Prefabs", false, 21)]
        static void RebuildSceneIds()
        {
            DefaultPrefabsFinder.PopulateDefaultPrefabs(true, true);
        }


    }

}
#endif