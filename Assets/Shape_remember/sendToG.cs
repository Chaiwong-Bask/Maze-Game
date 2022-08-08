using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sendToG : MonoBehaviour
{

    [SerializeField] InputField _name;
    [SerializeField] InputField age;
    [SerializeField] InputField gender;
    //[SerializeField] public GameObject score;
    //[SerializeField] public GameObject timesp;
    [SerializeField] private string bASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSc6ez-PvpIhB9InLw3kt-h5Z7pi5jaO5oanPXnjQ3cbezGD3A/formResponse";

    private string _score;
    private string _timespent;
    private string Pname;
    private string Page;
    private string PGender;
    [SerializeField]
    private GameObject _done;
    [SerializeField]
    private GameObject BackToMainMenu;



    public void Start()
    {
        _score = QuizManager.score.ToString();
        _timespent = CountTime.t.ToString();
    }


    public void Send()
    {
        Pname = _name.GetComponent<InputField>().text;
        Page = age.GetComponent<InputField>().text;
        PGender = gender.GetComponent<InputField>().text;
        //   _score = _score.GetComponent<InputField>().text;
        //_timespent = timesp.GetComponent<Text>().text;

        StartCoroutine(Post(Pname, Page, PGender, _score, _timespent));
        Debug.Log("Sending Result. . .");
        Debug.Log(_score);
        Debug.Log(_timespent);

        _done.SetActive(true);
        BackToMainMenu.SetActive(true);

    }

    IEnumerator Post(string name, string age, string gender, string score, string timesp)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.540514761", name);
        form.AddField("entry.2034515329", age);
        form.AddField("entry.1579980990", gender);
        form.AddField("entry.13908200", score);
        form.AddField("entry.309281067", timesp);

        UnityWebRequest www = UnityWebRequest.Post(bASE_URL, form);

        yield return www.SendWebRequest();
    }

    public void QuitLevel()
    {
        Debug.Log("Quitting Game . . .");
        Application.Quit();
    }

}
