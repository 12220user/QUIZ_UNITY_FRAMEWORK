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
        
        [Tooltip("������� ���� ���� ���������� ������� (�� ����), � ������ �������, � �������� ������� ������ ��������")]
        [SerializeField] private bool isDevelop = false;

        [Header("������������ �������")]
        [SerializeField] private QuizProjectData projectData;

        [Space]
        [Header("��������� ���������")]
        [Tooltip("����� ������ �� ������ � ��������")]
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
        /// �������� ������������ ���������� ����� ������������
        /// </summary>
        private void CheckProjectData() {
            if (projectData.Logo == null)
                WarningLog("Logotype undefiend. Please set " + transform.name + " -> QUIZ_ENGINE -> Project Data -> Logo");
            if (projectData.projectFont == null)
                ErrorLog("�� ���������� ����� ������. ��� ���� ��� ��������� ���������� �� ����� ������������.");
            if (string.IsNullOrEmpty(projectData.Title))
            {
                projectData.Title = Application.productName;
                WarningLog("�� ����������� �������� ����. ���������� �������� ������� unity : " + Application.productName);
            }
            if (string.IsNullOrEmpty(projectData.Author))
            {
                projectData.Author = Application.companyName;
                WarningLog("�� ���������� �����. ���������� �������� �������� unity : " + Application.companyName);
            }
            if (projectData.backgroundAudio == null) {
                WarningLog("�� ����������� ������� ������. ������ �������� ��� ��");
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
