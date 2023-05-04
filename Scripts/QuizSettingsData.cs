using UnityEngine;


namespace WNF.Quiz
{
    /// <summary>
    /// Способ сотрировки листа вопросов
    /// </summary>
    public enum QuestionSortType { Unsort , Invert , Random }

    /// <summary>
    /// Способ сортировки полей ответа
    /// </summary>
    public enum AnswersSortType { Unchange , Random }


    /// <summary>
    /// Параметры игры викторины
    /// </summary>
    [System.Serializable]
    public struct QuizProjectData
    {
        [Header("* локализация распространяется на весь проект")]
        public bool useLocalization;
        [Space]
        public Font projectFont;
        [Header("* вместо текста можно использовать ключи локализации")]
        [Tooltip("Название проекта, которое отображается в графическом представлении (UI)")]
        public string Title;
        [Tooltip("Автор проекта")]
        public string Author;
        [Space]
        [Tooltip("Логотип в графике")]
        public Sprite Logo;
        [Space]
        [Tooltip("Фоновая музыка")]
        public AudioClip backgroundAudio;
    }


    [System.Serializable]
    public struct Question {
        [Tooltip("Картинка привязанная к вопросу, оставте пустым, если не требуется")]
        public Sprite Img;
        [Tooltip("Текст или ключ локализации самого вопрос, к нему не применяется форматирование, поэтому желательно везде проверить наличие знака '?'")]
        public string question;
        [Tooltip("Индекс верного ответа в списке ниже. Помни начинается с 0")]
        public int indexTrueAnswer;
        [Space]
        [Tooltip("Список ответов на данный вопрос")]
        public Answer[] answers;
    }


    [System.Serializable]
    public struct Answer
    {
        [Tooltip("Текст или ключ локализации ответа, отображаемого в UI")]
        public string data;
    }
}
