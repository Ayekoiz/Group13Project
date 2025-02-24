using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){
            this.transform.position = new Vector3(this.transform.position.x + .05f, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.A)){
            this.transform.position = new Vector3(this.transform.position.x - .05f, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.W)){
            this.transform.position = new Vector3(this.transform.position.x, transform.position.y + .05f, transform.position.z);
        }
        if(Input.GetKey(KeyCode.S)){
            this.transform.position = new Vector3(this.transform.position.x, transform.position.y - .05f, transform.position.z);
        }
    }
}
