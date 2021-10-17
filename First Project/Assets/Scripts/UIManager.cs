using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public AnswerBtn[] answerBtns;

    private void Awake()
    {
        MakeSingleton();
    }
    private void Start()
    {
        ShuffleAnswer();
    }

    public void SetTimeText(string content)
    {
        if (timeText)
            timeText.text = content;
    }

    public void SetQuestionText(string content)
    {
        if (questionText)
            questionText.text = content;
    }

    public void ShuffleAnswer()
    {
        if (answerBtns != null && answerBtns.Length > 0)
        {
            for (int i = 0; i < answerBtns.Length; i++)
            {
                if (answerBtns[i])
                {
                    answerBtns[i].tag = "Untagged";
                }
            }
            int rand = Random.Range(0, answerBtns.Length);
            if (answerBtns[rand])
            {
                answerBtns[rand].tag = "RightAnswer";
            }
        }
    }

    public void MakeSingleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
