using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace WNF.Quiz{
    public class QUIZ_ENGINE : MonoBehaviour
    {
        #region consants
        private static readonly string PACKAGE_NAME = "Com.12220.quiz_framework";
        private static readonly string FRAME_ASSET_PATH = "Packages/"+PACKAGE_NAME+"/Prefabs/QuizFrame.prefab";
        private static readonly string FRAME_ASSET_PATH_DEV = "Assets/QUiZ_UNITY_FRAMEWORK/Prefabs/QuizFrame.prefab";
        #endregion

        #region Parametrs is visible
        
        [Tooltip("Активен если идет разработка плагина (не игры), а именно плагина, в конечном проекте всегда отключен")]
        [SerializeField] private bool isDevelop = false;

        [Header("Конфигурация проекта")]
        [SerializeField] private QuizProjectData projectData;

        [Space]
        [Header("Параметры викторины")]
        [Tooltip("Время ответа на вопрос в секундах")]
        [SerializeField] private float answerGetTime = 15;
        [Space]
        [SerializeField] private List<QuizQuestionList> quizList = new List<QuizQuestionList>();

        #endregion

        #region Parametrs unvisible

        private AudioSource backgroundAudioSource;

        #endregion

        #region init logic

        private void init()
        {
            // Check fields
            CheckProjectData();


            // Load frame canvas with event system
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(isDevelop ? FRAME_ASSET_PATH_DEV : FRAME_ASSET_PATH);
            Instantiate(asset);

            
            SetAllTextComponentFont();  // Set font

            // Create Audio background music
            if (projectData.backgroundAudio != null)
                CreateBackgroundAudio();
        }

        private void CreateBackgroundAudio() {
            backgroundAudioSource = new GameObject("[AutoCreated-GUIZ] Audio Background", typeof(AudioSource)).GetComponent<AudioSource>();
            backgroundAudioSource.playOnAwake = true;
            backgroundAudioSource.loop = true;
        }

        private void SetAllTextComponentFont() {
            var textArray = GameObject.FindObjectsOfType<Text>();
            foreach (var text in textArray) {
                text.font = projectData.projectFont;
            }
        }

        #endregion

        #region Check fields
        /// <summary>
        /// Проверка правильности заполнения полей конфигурации
        /// </summary>
        private void CheckProjectData() {
            if (projectData.Logo == null)
                WarningLog("Logotype undefiend. Please set " + transform.name + " -> QUIZ_ENGINE -> Project Data -> Logo");
            if (projectData.projectFont == null)
                ErrorLog("Не установлен шрифт текста. Без него вся текстовая информация не будет отображаться.");
            if (string.IsNullOrEmpty(projectData.Title))
            {
                projectData.Title = Application.productName;
                WarningLog("Не установлено название игры. Подгружено название проекта unity : " + Application.productName);
            }
            if (string.IsNullOrEmpty(projectData.Author))
            {
                projectData.Author = Application.companyName;
                WarningLog("Не установлен автор. Подгружено название компании unity : " + Application.companyName);
            }
            if (projectData.backgroundAudio == null) {
                WarningLog("Не установлена фоновая музыка. Проект работает без неё");
            }
        }

        #endregion

        #region Logs
        private void Log(string msg) {
            #if UNITY_EDITOR
            Debug.Log(msg);
            #endif
        }

        private void ErrorLog(string msg) {
            #if UNITY_EDITOR
            Debug.LogError(msg);
            #endif
        }

        private void WarningLog(string msg) {
            #if UNITY_EDITOR
            Debug.LogWarning(msg);
            #endif
        }
        #endregion



        private void Awake() => init();
    }
}
