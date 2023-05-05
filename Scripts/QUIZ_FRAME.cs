using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WNF.Quiz
{
    public class QUIZ_FRAME : MonoBehaviour
    {
        [SerializeField] private Animation LogoFramePreviewAnimation;
        [SerializeField] private Image BackgroundImage;
        [SerializeField] private Image LogoImage;
        [SerializeField] private Text  TitleText;
        [Space]
        [SerializeField] private QuizGame_button MenuPlayButton;
        [SerializeField] private QuizGame_button MenuRecordButton;
        [SerializeField] private QuizGame_button SettingsRecordButton;
        [SerializeField] private List<Image> themeColorElements = new List<Image>();
        [SerializeField] private List<FrameAnimator> frames = new List<FrameAnimator>();

        private QuizProjectData projectData;
        public event System.Action<string,string[]> OnClickNavigationButton;

        private void Start()
        {
            OnClickNavigationButton += ListemFrameAnimation;
        }

        public void SetProjectData(QuizProjectData data , Canvas selfCanvas) {
            projectData = data;
            // bg
            if (BackgroundImage != null)
            {
                BackgroundImage.sprite = data.Background;
                var resolution = data.CalcWidthBackground(selfCanvas);
                BackgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, resolution.x);
                BackgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, resolution.y);
            }
            if (TitleText != null) {
                TitleText.text = QUIZ_ENGINE.inctance.Locolize(data.Title);
                TitleText.color = data.BaseTextColor;
            }
            if(LogoImage != null)
            {
                LogoImage.sprite = data.Logo;
            }
            QUIZ_ENGINE.inctance.OnChanedScreenSizeEvent += CanvasResize;
            //LogoFramePreviewAnimation?.Play();

            foreach (var item in themeColorElements) {
                item.color = data.FrameThemeColor;
            }


            MenuPlayButton.ButtonImage.color = data.BaseButtonColor;
            MenuRecordButton.ButtonImage.color = data.BaseButtonColor;
            
            MenuPlayButton.Button.onClick.AddListener(() => { ButtonAction("OpenCategory", "disable-menu" , "open-categoty"); });
            MenuRecordButton.Button.onClick.AddListener(() => { ButtonAction("OpenRecord", "disable-menu" ); });


            if (data.useLocalization)
            {
                SettingsRecordButton.ButtonImage.color = data.BaseButtonColor;
            }
            else {
                SettingsRecordButton.gameObject.SetActive(false);
            }
        }

        private void ButtonAction(string type, params string[] preset_actions) {
            OnClickNavigationButton?.Invoke(type, preset_actions);
        }


        private void CanvasResize(Canvas selfCanvas) {
            if (BackgroundImage != null)
            {
                var resolution = projectData.CalcWidthBackground(selfCanvas);
                BackgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, resolution.x);
                BackgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, resolution.y);
            }
        }

        private void ListemFrameAnimation(string type, string [] actions) {
            foreach (var action in actions) {
                var a = action.Split('-');
                if (a[0] == "disable") {
                    frames.Find(x => x.name == a[1]).SetState(false);
                }
                if (a[0] == "open")
                {
                    frames.Find(x => x.name == a[1]).SetState(true);
                }
            }
        }
    }
}
