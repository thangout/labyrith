using UnityEngine;
using System.Collections;
using System;

public class BrainScript : MonoBehaviour {

    public GameObject Ball;
    public GameObject RotationObject;
    public GameObject StartZone;

    public float RotationSpeed;
    public float MaxRotation;

    private float angleOfRotation;
    private float maximumRotationAngle;
	// Use this for initialization
	void Start () {
        angleOfRotation = 0.5f;
        maximumRotationAngle = 25f;
        Ball.transform.position = StartZone.transform.position;

        float an = Quaternion.Angle(Quaternion.Euler(new Vector3(0, 0, 0)), Quaternion.Euler(new Vector3(0, 30, 30)));

        Debug.Log(an);
	}
	
	// Update is called once per frame
	void Update () {
        readInput();

        // Debug.Log(RotationObject.transform.eulerAngles.x); foward backwwards
        Debug.Log(RotationObject.transform.eulerAngles.z);
    }

    public void reset(){
        Ball.transform.position = StartZone.transform.position;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        RotationObject.transform.rotation = Quaternion.identity;
        }

    void readInput()
    {
        float fowardAngle = RotationObject.transform.eulerAngles.x;
        float sideAngle = RotationObject.transform.eulerAngles.z;

        if (Input.GetKey(KeyCode.UpArrow) && checkFowardAngle())
            {
                Debug.Log("Up arrow pressed");
                RotationObject.transform.Rotate(-Vector3.left, angleOfRotation, Space.World);
            }
  
            if(Input.GetKey(KeyCode.DownArrow) && checkFowardAngle())
            {
                Debug.Log("Up down pressed");
                RotationObject.transform.Rotate(Vector3.left, angleOfRotation, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && checkSideAngle())
            {
                Debug.Log("Up left pressed");
                RotationObject.transform.Rotate(Vector3.forward, angleOfRotation, Space.Self);
            }

            if (Input.GetKey(KeyCode.RightArrow) && checkSideAngle())
            {
                Debug.Log("Up right pressed");
                RotationObject.transform.Rotate(-Vector3.forward, angleOfRotation, Space.Self);
            }

            
    }

    private bool checkSideAngle()
    {
        throw new NotImplementedException();
    }

    private bool checkFowardAngle()
    {
        throw new NotImplementedException();
    }

    bool checkTiltAngle()
    {
        if(Quaternion.Angle(Quaternion.identity, RotationObject.transform.rotation) > 45)
        {
            //Quaternion.x
           // Debug.Log("Got over the limit");
            return true;
        }

        return false;
        
    }
}
