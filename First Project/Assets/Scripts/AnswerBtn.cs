using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBtn : MonoBehaviour
{
    public Text txtAnswer;
    public Button btnComp;

    public void SetAnswerText(string content)
    {
        if (txtAnswer)
            txtAnswer.text = content;
    }
}
