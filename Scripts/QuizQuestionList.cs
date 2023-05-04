using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WNF.Quiz
{
    [CreateAssetMenu(fileName = "new questionList" , menuName = "QUIZ_ENGINE/QuestionList" , order = 0)]
    public class QuizQuestionList : ScriptableObject
    {
        public QuestionSortType questionSort = QuestionSortType.Random;
        public AnswersSortType answersSort = AnswersSortType.Unchange;
        [Space]
        public List<Question> questions = new List<Question>();
    }
}
