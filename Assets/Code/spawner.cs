using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Vector3[] positions;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, positions.Length);
        transform.position = positions[randomNum];
    }
    
  
}
