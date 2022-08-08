using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    private int nextSceneLoad;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestions = 0;
    public static int score;


    // Start is called before the first frame update
    private void Start()
    {
        totalQuestions = QnA.Count;
        Quizpanel.SetActive(true);
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void GameOver(){
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + (totalQuestions + 3);

    }
    public void getnextLevel()
        {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitLevel()
    {
        Debug.Log("Quitting Game . . .");
        Application.Quit();
    }
    public void sendResult()
    {
        SceneManager.LoadScene("GetInfo");
        
    }


    public void retry()
    {
        SceneManager.LoadScene("ModeSelect");
    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }


    public  void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());


    }

    IEnumerator WaitForNext()

    {

        yield return new WaitForSeconds(1);

        generateQuestion();

    }

    void setAnswer()
    {
        for(int i = 0; i < options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answer[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }

        }


    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {

            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;
            setAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
       


    }
   
}
