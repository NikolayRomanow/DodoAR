using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class Victorine : MonoBehaviour
{
    public QuestionList[] Questions;
    public Text[] AnswersText;
    public Text qText;
    public Transform endPosition;

    public GameObject victorinePanel;
    public GameObject ratingPanel;

    public GameObject Bird1;
    public GameObject Bird2;

    public GameObject game;

    public float time;
    private int _ratingScore;

    public Text timeCount;
    public Text trueAnswers;
    public Text countAnswers;
    public Text ratingScore;

    private AIMoveFirstBird speedBird1;
    
    private List<object> qList;
    private QuestionList crntQ;
    private int randQ;

    private int Rele = 0;
    private bool lampochka = false;

    public int _trueAnswers;
    public int _countAnswers;

    private void Awake()//Бесполезно
    {
        speedBird1 = Bird1.GetComponent<AIMoveFirstBird>();
    }

    public void Update()
    {
        
        //if(!game.activeSelf)
        //    return;
        time += Time.deltaTime;
        _ratingScore = Mathf.RoundToInt(time) * (_trueAnswers / _countAnswers);
        //time = Math.Round(time, 2);
        if (Bird1.transform.position == endPosition.position && !lampochka)
        {
            lampochka = true;
            timeCount.text = Convert.ToString(time).Remove(7);
            trueAnswers.text = Convert.ToString(_trueAnswers);
            countAnswers.text = Convert.ToString(_countAnswers);
            ratingScore.text = Convert.ToString(_ratingScore);
            victorinePanel.SetActive(false);
            ratingPanel.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        if (Rele == 0)
        {
            Rele++;
            qList = new List<object>(Questions);
            _questionGenerate();
        }
        
    }

    void _questionGenerate()
    {
        randQ = UnityEngine.Random.Range(0, qList.Count);
        crntQ = qList[randQ] as QuestionList;
        qText.text = crntQ.Question;
        List<string> Answer = new List<string>(crntQ.Answer);
        for (int i = 0; i < crntQ.Answer.Length; i++)
        {
            int rand = UnityEngine.Random.Range(0, Answer.Count);
            AnswersText[i].text = Answer[rand];
            Answer.RemoveAt(rand);
        }
    }

    public void AnswersButtons(int index)
    {
        print(AnswersText[index].ToString());
        if (AnswersText[index].text.ToString() == crntQ.Answer[0])
        {
            _trueAnswers++;
            //speedBird1.SpeedMove += 0.1f;     Заменил на использование статического класса.
            Stats.MovementVelocityFirstBird += 0.1f;
        }
        else
        {
           
        }
        _countAnswers++;
        StartCoroutine(KostylNomer2534());
    }

    IEnumerator KostylNomer2534()
    {
        yield return new WaitForSeconds(0.5f);
        qList.RemoveAt(randQ);
        _questionGenerate();
    }
    
}

[System.Serializable]
public class QuestionList
{
    public string Question;
    public string[] Answer = new string[3];
}







