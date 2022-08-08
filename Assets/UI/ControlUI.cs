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

public class ControlUI : MonoBehaviour, INeedInjection
{


    [SerializeField] Button button_test = null;
    [SerializeField] Button button_1 = null;
    [SerializeField] Button button_2 = null;
    [SerializeField] Button button_3 = null;
    [SerializeField] Button button_4 = null;
    [SerializeField] Button button_scan = null;

    [SerializeField] InputField input_h1 = null;
    [SerializeField] InputField input_h2 = null;
    [SerializeField] MapBehaviour mb = null;


    void Start()
    {

        button_test.onClick.AddListener(buttonF_test2);
        button_1.onClick.AddListener(buttonF_shortcut1);
        button_2.onClick.AddListener(buttonF_shortcut2);
        button_3.onClick.AddListener(buttonF_shortcut3);
        button_4.onClick.AddListener(buttonF_shortcut4);
        input_h1.text = "1"; input_h2.text = "2";
        button_scan.onClick.AddListener(buttonF_scan);

    }

    void Update()
    {

    }

    void buttonF_test2()
    {
        int hmin = int.Parse(input_h1.text);
        int hmax = int.Parse(input_h2.text);
        ScreenFloor(hmin, hmax);
    }

    void ScreenFloor(int hmin, int hmax )
    {

        GameObject m = GameObject.Find("Map");
        Debug.Log("mmm000 " + "_" + m.name);

        //loop child
        foreach (Transform c in m.transform)
        {
            Debug.Log("mmm" + "_" + c.name);

            bool b = true;
            if (c.transform.position.y < hmin || c.transform.position.y > hmax)
            {
                b = false;
            }
            else {
                foreach (Transform c2 in c.transform)
                {
                    bool b2 = true;
                    if (c2.transform.position.y > hmax)
                    {
                        b2 = false;
                    }
                    c2.gameObject.SetActive(b2);
                }
            }
            c.gameObject.SetActive(b);

        }
    }


    //void buttonF_test()
    //{
    //    //mb.cullingData.ChunksInRange[0].Rooms.Clear();
    //    Debug.Log("BUTTON CLICK1");
    //    Debug.Log(
    //        "BUTTON CLICK2"
    //         + "_" + mb.cullingData.ChunksInRange.Count

    //        );
    //    Debug.Log(
    //"BUTTON CLICK3"
    // + "_" + mb.cullingData.ChunksInRange.Count
    //+ "_" + mb.cullingData.ChunksInRange[0].Rooms.Count

    //);
    //    Debug.Log(
    //        "BUTTON CLICK4"
    //        + "_" + mb.cullingData.ChunksInRange[0].GameObjects.Count

    //        );


    //    //slot.GameObject
    //}
    void buttonF_shortcut1() { ScreenFloor(1, 1); }
    void buttonF_shortcut2() { ScreenFloor(1, 3); }
    void buttonF_shortcut3() { ScreenFloor(1, 5); }
    void buttonF_shortcut4() { ScreenFloor(1, 7); }

    void buttonF_scan()
    {
        Debug.Log("BUTTON SCAN");

        int ic = 0;
        foreach (Chunk ch in mb.cullingData.ChunksInRange)
        {

            int ir = 0;
            foreach (Room r in ch.Rooms)
            {

                Debug.Log("C" + ic + "R" + ir + " == " + r.ToString());
            }
        }

    }
}
