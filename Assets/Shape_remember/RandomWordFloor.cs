using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


public class RandomWordFloor : MonoBehaviour
{
    [SerializeField]
    // private string[] m_InspectorStrings;
    List<string> fakecolour = new List<string>();
    List<string> colorlist = new List<string>();

    string[] _12colors;
    string[] _10words;
    string[] _20backup;
    public TextAsset colorList;
    public TextMesh[] color_floor;
    public TextMesh color_board;
    public GameObject triggerbox;
    /*
    Color32 Red = new Color(1f, 0f, 0f);
    Color32 Orange = new Color(0.98f, 0.63f, 0.09f);
    Color32 Pink = new Color(255, 128, 191);
    Color32 Purple = new Color(99, 28, 179);
    Color32 Yellow = new Color(255, 232, 28);
    Color32 Green = new Color(59, 164, 36);
    Color32 Blue = new Color(38, 100, 245);
    Color32 Grey = new Color(151, 151, 151);
    */

    public Color32 Red = new Color(1f, 0f, 0f);
    public Color32 Orange = new Color(0.98f, 0.63f, 0.09f);
    public Color32 Pink = new Color(1f, 0.50f, 0.74f);
    public Color32 Purple = new Color(99f, 28f, 179f);
    public Color32 Yellow = new Color(255f, 232f, 28f);
    public Color32 Green = new Color(59f, 164f, 36f);
    public Color32 Blue = new Color(38f, 100f, 245f);
    public Color32 Grey = new Color(151f, 151f, 151f);
    public Color32 White = new Color(1f, 1f, 1f);

    string[] BASE_colors;
    string[] colors;
    private Vector3 SpawnPosition;
    public GameObject ObjectToCreate;

    void Start()
    {
        
        SetFloorColour();
    }

    private void SetFloorColour()
    {
        BASE_colors = (colorList.text.Split(' '));
            
            colors = BASE_colors;
            // Choose 1 color for answer
            System.Random random = new System.Random();

            int targetcolor = random.Next(colors.Length);
            string answerColor = colors[targetcolor];

            RemoveAt(ref colors, targetcolor);


            for (int i = 0; i < 12; i++)
            {
                int usedColor = random.Next(colors.Length);
                string pickColor = colors[usedColor];

                //Debug.Log("12 colors: " + pickColor);
                fakecolour.Add(pickColor);
                _12colors = fakecolour.ToArray();

            }
            _20backup = _12colors;
            //Set 12 floor color
            for (int i = 0; i < 12; i++)
            {
                int randomnumber = random.Next(colors.Length);
                color_floor[i].GetComponent<TextMesh>().text = _12colors[i];

                //color_floor[i].GetComponent<TextMesh>().color = Orange;
                Randomcolor(randomnumber, i);
                //Debug.Log("Done");
                //Debug.Log( i + " Words: " + _20backup[i]);
                //Set answer floor and board color
            }
            //Random answer location
            int answer_floor_location = random.Next(color_floor.Length);

            SpawnPosition = color_floor[answer_floor_location].GetComponent<TextMesh>().transform.position;

            color_floor[answer_floor_location].GetComponent<TextMesh>().text = answerColor;
            color_board.GetComponent<TextMesh>().text = answerColor;

            GameObject answer_portal = Instantiate(ObjectToCreate, new Vector3(SpawnPosition.x, SpawnPosition.y + 1.5f, SpawnPosition.z), Quaternion.Euler(0, 0, 0));
            

        
    }

    void OnTriggerEnter(Collider answer_portal)
    {
        SetFloorColour();
        Destroy(triggerbox);
    }


    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }

    public  void Randomcolor(int randomnumber,int i)
    {
        switch (randomnumber)
        {
            case 0:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Red;
                    //Debug.Log("Done 0");
                }
                break;
            case 1:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Orange;
                    //Debug.Log("Done 1");
                }
                break;
            case 2:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Pink;
                    //Debug.Log("Done 2");
                }
                break;
            case 3:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Purple;
                   // Debug.Log("Done 3");
                }
                break;
            case 4:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Yellow;
                    //Debug.Log("Done 4");
                }
                break;
            case 5:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Green;
                    //Debug.Log("Done 5");
                }
                break;
            case 6:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Blue;
                    //Debug.Log("Done 6");
                }
                break;
            case 7:
                {
                    color_floor[i].GetComponent<TextMesh>().color = Grey;
                    //Debug.Log("Done 7");
                }
                break;
            case 8:
                {
                    color_floor[i].GetComponent<TextMesh>().color = White;
                    //Debug.Log("Done 8");
                }
                break;
        }
    }
   

}