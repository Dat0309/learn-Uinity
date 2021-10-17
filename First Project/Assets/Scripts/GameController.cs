using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Instance.GetRandomQuestion();
        if (qs != null)
        {
            UIManager.Instance.SetQuestionText(qs.question);
            string[] wrongAnswers = new string[] { qs.answerA, qs.answerB, qs.answerC };
            UIManager.Instance.ShuffleAnswer();
            var temp = UIManager.Instance.answerBtns;
            if(temp!=null && temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    if(string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswers[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                }
            }
        }
    }
}
