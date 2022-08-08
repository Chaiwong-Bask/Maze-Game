using UnityEngine.AI;
using UnityEngine;

public class playercon : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;



    private void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
    // Update is called once per frame
    void Update()
    {


   /*         if(Input.GetKeyDown("z"))
           {
               Cursor.lockState = CursorLockMode.Locked;
               Cursor.visible = false;
           }

           if (Input.GetKeyDown("c"))
           {
               Cursor.lockState = CursorLockMode.None;
               Cursor.visible = true;
           }
        */
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit)){
                agent.SetDestination(hit.point);
            }
        }

       

    }
}
