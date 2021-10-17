using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    public QuestionData[] questions;
    List<QuestionData> mQuestion;
    QuestionData mCurrentQuestion;

    public QuestionData MCurrentQuestion { get => mCurrentQuestion; set => mCurrentQuestion = value; }

    private void Awake()
    {
        mQuestion = questions.ToList();
        MakeSingleton();
    }

    public QuestionData GetRandomQuestion()
    {
        if(mQuestion != null && mQuestion.Count > 0)
        {
            int rand = Random.Range(0, mQuestion.Count);
            mCurrentQuestion = mQuestion[rand];
            mQuestion.RemoveAt(rand);
        }
        return mCurrentQuestion;
    }

    public void MakeSingleton()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }
}
