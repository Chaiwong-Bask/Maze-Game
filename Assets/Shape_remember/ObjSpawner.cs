using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    //public GameObject objectToSpawn;

    public List<GameObject> objectsToSpawn = new List<GameObject>();

    public GameObject spawnToObject;

    //public List<GameObject> spawnToObject = new List<GameObject>();

   // [SerializeField] Transform[] destinations;

    public bool isRandomized;

    // Start is called before the first frame update
    void Start()
    {
        int index = isRandomized ? Random.Range(0, objectsToSpawn.Count) : 0;

        if (objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[index], spawnToObject.transform.position, Quaternion.identity);
           


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
