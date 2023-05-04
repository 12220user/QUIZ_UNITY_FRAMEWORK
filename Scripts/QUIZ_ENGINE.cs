using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WNF.Quiz{
    public class QUIZ_ENGINE : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>("Packages/com.12220.quiz_framework/Prefubs/QuizFrame.prefab");
            Instantiate(asset);
        }

        
    }
}
