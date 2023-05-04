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
        [Space]
        [Tooltip("������� ������")]
        public AudioClip backgroundAudio;
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
}
