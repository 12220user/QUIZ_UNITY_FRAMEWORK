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
        [Tooltip("Задний фон приложения")]
        public Sprite Background;
        [Space]
        [Tooltip("Фоновая музыка")]
        public AudioClip backgroundAudio;

        [Space]
        [Header("Цветовые параметры")]
        [Tooltip("Цвет текста на заготовках и компонентов без дополнительного заднего фона")]
        public Color BaseTextColor;
        [Tooltip("Цвет текста в кнопках, полях интерфейса")]
        public Color DataTextColor;
        [Tooltip("Цвет кнопок стандартный")]
        public Color BaseButtonColor;
        [Tooltip("Цвет на фоне используемый в экранах перехода")]
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
