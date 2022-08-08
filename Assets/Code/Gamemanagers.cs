using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Gamemanagers : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestion;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

  //  [SerializeField]
 //   private Text trueAnswerText;

 //   [SerializeField]
 //   private Text falseAnswerText;

   // [SerializeField]
  //  private Animator animator;


    [SerializeField]
    private float timeBetweenQuestion = 1f;


    private void Start()
    {
        if (unansweredQuestion == null || unansweredQuestion.Count == 0)
        {
            unansweredQuestion = questions.ToList<Question>();
        }

        setCurrentQuestion();
        // Debug.Log(currentQuestion.question + " is " + currentQuestion.isTrue);
    }
        void setCurrentQuestion()
        {
            int randomQuestionIndex = Random.Range(0, unansweredQuestion.Count);
            currentQuestion = unansweredQuestion[randomQuestionIndex];

            factText.text = currentQuestion.question;

      /*    if(currentQuestion.isTrue)
        {
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "WRONG";
        }else
        {
            trueAnswerText.text = "WRONG";
            falseAnswerText.text = "CORRECT";
        }*/

        }

        IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestion.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestion);

        setCurrentQuestion();
    }


        public void UserSelectTrue()
    {
      //  animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
     //   animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        StartCoroutine(TransitionToNextQuestion());
    }

}



