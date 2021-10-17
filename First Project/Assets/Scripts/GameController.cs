using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float timePerQuestion;
    float currentTime; 

    int rightCount;

    private void Awake()
    {
        currentTime = timePerQuestion;
    }
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.SetTimeText("00 : " + currentTime);
        CreateQuestion();
        StartCoroutine(TimeCountingDown());
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
                    int answerId = i;
                    if(string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswers[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }

                    temp[answerId].btnComp.onClick.RemoveAllListeners();
                    temp[answerId].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));
                }
            }
        }
    }

    public void CheckRightAnswerEvent(AnswerBtn answerBtn)
    {
        if (answerBtn.CompareTag("RightAnswer"))
        {
            currentTime = timePerQuestion;
            UIManager.Instance.SetTimeText("00 :"+ currentTime);

            rightCount++;

            if (rightCount == QuestionManager.Instance.questions.Length)
            {
                UIManager.Instance.dialog.SetDialogContent("Bạn đã chiến thắng!!");
                UIManager.Instance.dialog.Show(true);
                AudioController.Instance.WinSound();
                StopAllCoroutines();
            }
            else
            {
                CreateQuestion();
                AudioController.Instance.PlayRightSound();
            }
        }
        else
        {
            UIManager.Instance.dialog.SetDialogContent("Trò chơi kết thúc! bạn thua");
            UIManager.Instance.dialog.Show(true);
            AudioController.Instance.LoseSound();
        }
    }

    IEnumerator TimeCountingDown()
    {
        // Delay
        yield return new WaitForSeconds(1);
        if(currentTime > 0)
        {
            currentTime--;
            StartCoroutine(TimeCountingDown());
            UIManager.Instance.SetTimeText("00 : " + currentTime);
        }
        else
        {
            UIManager.Instance.dialog.SetDialogContent("Đã hết thời gian, bạn đã thua!");
            UIManager.Instance.dialog.Show(true);
            StopAllCoroutines();
            AudioController.Instance.LoseSound();
        }
    }

    public void Replay()
    {
        AudioController.Instance.StopMusic();
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
