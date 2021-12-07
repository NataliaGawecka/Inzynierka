using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCar : MonoBehaviour
{
    public Camera CarCam;
    public Camera MainCamera;
    public GameObject choosen_car;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...

            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(raycast, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want

                if (hit.collider.tag == "Car")
                {
                    Debug.Log(hit.collider.name);
                    choosen_car = hit.collider.gameObject;
                    hit.transform.gameObject.GetComponent<CarController>().enabled = true;
                    MainCamera.enabled = false;
                    CarCam.enabled = true;




                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("wciśnięto klawisz Q");
            choosen_car.GetComponent<CarController>().enabled = false;
            if (MainCamera.enabled == false)
            {
                MainCamera.enabled = true;
                CarCam.enabled = false;
            }
        }
    }

}


