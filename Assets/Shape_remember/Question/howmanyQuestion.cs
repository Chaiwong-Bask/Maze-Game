using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UniInject;
using UniRx;

// Disable warning about fields that are never assigned, their values are injected.
#pragma warning disable CS0649

public class howmanyQuestion : MonoBehaviour, INeedInjection
{
    [SerializeField]
    private InputField inputC;

    [SerializeField]
    private InputField inputT;

    [SerializeField]
    private InputField inputS;

    public GameObject nextQuestion;
    public GameObject currentQuestion;

    int score_c;
    int score_t;
    int score_s;
    int sumScore;
    int c_num;
    int t_num;
    int s_num;
   

    public void Awake()
    {
        c_num = PlayerInventory.NumberOfCircle;
        t_num = PlayerInventory.NumberOfTriangle;
        s_num = PlayerInventory.NumberOfSquare;
       // Debug.Log(c_num + " Circles have been collected");
      //  Debug.Log(t_num + " Triangles have been collected");
      //  Debug.Log(s_num + " Squares have been collected");
    }
   
    public void GetInputC(string inputC)
    {


        Debug.Log("You entered " + inputC + " as in Circle");
        //Debug.Log("You entered " + inputT + "as in Triangles");
       // Debug.Log("You entered " + inputS + "as in Squares");
       
        CompareAnswer_C(int.Parse(inputC));
        //CompareAnswer_T(int.Parse(ans));
        //CompareAnswer_S(int.Parse(ans));

    }
    public void GetInputT(string inputT)
    {
        Debug.Log("You entered " + inputT + " as in Triangles");
        CompareAnswer_T(int.Parse(inputT));
    }
    public void GetInputS(string inputS)
    {
        Debug.Log("You entered " + inputS + " as in Squares");
        CompareAnswer_S(int.Parse(inputS));
    }

  
    public void NextQuestion()
    {
        nextQuestion.SetActive(true);
        currentQuestion.SetActive(false);
        sumScore = score_c + score_s + score_t;
       
        Debug.Log("This is sum score from how many questions" + sumScore);
        QuizManager.score = QuizManager.score + sumScore ;
        
    }
    public void CompareAnswer_C(int inputC)
    {
        
        if (inputC == c_num)
        {
            score_c += 1;
            
            //Debug.Log("Fucking correct " + score_c);
        }
    }
    public void CompareAnswer_T(int inputT)
    {
        if (inputT == t_num)
        {
            score_t += 1;
           
            //Debug.Log("Fucking correct " + score_t);
        }
    }
    public void CompareAnswer_S(int inputS)
    {
        if (inputS == s_num)
        {
            score_s += 1;
            
           //Debug.Log("Fucking correct " + score_s);
        }
    }
}
