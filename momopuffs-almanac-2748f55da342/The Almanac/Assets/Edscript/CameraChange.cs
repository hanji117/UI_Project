using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//switching between 3rd and 1st person.
//Youtube video:
//Unity Mini Tutorial - How To Switch First Person & Third Person View
//Jimmy Vegas
public class CameraChange : MonoBehaviour
{



    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;

    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }
    }
        IEnumerator CamChange(){
            yield return new WaitForSeconds(0.01f); //allows the script to catch up in development.
            if (CamMode == 0){
                ThirdCam.SetActive(true);
                FirstCam.SetActive(false);
            }
            if (CamMode == 1){
                FirstCam.SetActive(true);
                ThirdCam.SetActive(false);
            }
        }
}
