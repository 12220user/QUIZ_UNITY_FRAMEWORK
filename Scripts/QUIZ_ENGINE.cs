using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WNF.Quiz{
    public class QUIZ_ENGINE : MonoBehaviour
    {
        #region consants
        private static readonly string PACKAGE_NAME = "Com.12220.quiz_framework";
        private static readonly string FRAME_ASSET_PATH = "Packages/"+PACKAGE_NAME+"/Prefabs/QuizFrame.prefab";
        private static readonly string FRAME_ASSET_PATH_DEV = "Assets/QUiZ_UNITY_FRAMEWORK/Prefabs/QuizFrame.prefab";
        #endregion

        #region Parametrs is visible

        [Tooltip("јктивен если идет разработка плагина (не игры), а именно плагина, в конечном проекте всегда отключен")]
        [SerializeField] private bool isDevelop = false;

        #endregion

        #region Parametrs unvisible



        #endregion

        private void Awake() => init();

        private void init()
        {
            // Load frame canvas with event system
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(isDevelop?FRAME_ASSET_PATH_DEV:FRAME_ASSET_PATH);
            Instantiate(asset);
        }
    }
}
