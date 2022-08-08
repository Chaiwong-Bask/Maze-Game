using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class colorTint : MonoBehaviour
{
    public List<Color> TintColors;
    // Start is called before the first frame update
    void Start()
    {

        Color c = TintColors[Random.Range(0, TintColors.Count)];

        GetComponent<Renderer>().material.color = c;
    }
}
