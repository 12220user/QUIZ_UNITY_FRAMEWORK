using UnityEngine;


namespace WNF.Quiz
{
    /// <summary>
    /// ������ ���������� ����� ��������
    /// </summary>
    public enum QuestionSortType { Unsort , Invert , Random }

    /// <summary>
    /// ������ ���������� ����� ������
    /// </summary>
    public enum AnswersSortType { Unchange , Random }


    /// <summary>
    /// ��������� ���� ���������
    /// </summary>
    [System.Serializable]
    public struct QuizProjectData
    {
        [Header("* ����������� ���������������� �� ���� ������")]
        public bool useLocalization;
        [Space]
        public Font projectFont;
        [Header("* ������ ������ ����� ������������ ����� �����������")]
        [Tooltip("�������� �������, ������� ������������ � ����������� ������������� (UI)")]
        public string Title;
        [Tooltip("����� �������")]
        public string Author;
        [Space]
        [Tooltip("������� � �������")]
        public Sprite Logo;
        [Tooltip("������ ��� ����������")]
        public Sprite Background;
        [Space]
        [Tooltip("������� ������")]
        public AudioClip backgroundAudio;

        [Space]
        [Header("�������� ���������")]
        [Tooltip("���� ������ �� ���������� � ����������� ��� ��������������� ������� ����")]
        public Color BaseTextColor;
        [Tooltip("���� ������ � �������, ����� ����������")]
        public Color DataTextColor;
        [Tooltip("���� ������ �����������")]
        public Color BaseButtonColor;
        [Tooltip("���� �� ���� ������������ � ������� ��������")]
        public Color FrameThemeColor;
        
        public Vector2 CalcWidthBackground(Canvas screen) {
            //Debug.Log(screen.renderingDisplaySize.x);
            var width = Background.textureRect.width;
            var height = Background.textureRect.height;
            var screenWidth = screen.GetComponent<RectTransform>().rect.width;//screen.renderingDisplaySize.x;
            var screenHeight = screen.GetComponent<RectTransform>().rect.height;//screen.renderingDisplaySize.y;

            if (width != screenWidth || height != screenHeight) { 
                var solution = width / height;
                if (screenWidth > screenHeight)
                {
                    width = screenWidth;
                    height = width / solution;
                }
                else {
                    height = screenHeight;
                    width = height * solution;
                }
            }
            return new Vector2(width, height);
        }
    }


    [System.Serializable]
    public struct Question {
        [Tooltip("�������� ����������� � �������, ������� ������, ���� �� ���������")]
        public Sprite Img;
        [Tooltip("����� ��� ���� ����������� ������ ������, � ���� �� ����������� ��������������, ������� ���������� ����� ��������� ������� ����� '?'")]
        public string question;
        [Tooltip("������ ������� ������ � ������ ����. ����� ���������� � 0")]
        public int indexTrueAnswer;
        [Space]
        [Tooltip("������ ������� �� ������ ������")]
        public Answer[] answers;
    }


    [System.Serializable]
    public struct Answer
    {
        [Tooltip("����� ��� ���� ����������� ������, ������������� � UI")]
        public string data;
    }

    [System.Serializable]
    public struct FrameAnimator {
        public string name;
        public Animation animation;
        public AnimationClip clipOpen , clipClose;
        public void SetState(bool isOpen) {
            if (!animation.gameObject.activeSelf) animation.gameObject.SetActive(true);
            animation.clip = isOpen ? clipOpen : clipClose;
            animation.Play();
        }
    }
}
