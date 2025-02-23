using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_switch : MonoBehaviour
{
    public Camera cameraMain;
    public Camera cameraProgress;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain.enabled = true;
        cameraMain.GetComponent<AudioListener>().enabled = true;
        cameraProgress.enabled = false;
        cameraProgress.GetComponent<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            cameraMain.enabled = !cameraMain.enabled;
            cameraMain.GetComponent<AudioListener>().enabled = !cameraMain.GetComponent<AudioListener>().enabled;
            cameraProgress.enabled = !cameraProgress.enabled;
            cameraProgress.GetComponent<AudioListener>().enabled = !cameraProgress.GetComponent<AudioListener>().enabled;
        }
    }
}
