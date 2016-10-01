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
        maximumRotationAngle = 20f;
        Ball.transform.position = StartZone.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        readInput();
    }

    public void reset(){
        Ball.transform.position = StartZone.transform.position;
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        RotationObject.transform.rotation = Quaternion.identity;
        }

    void readInput()
    {
        float fowardAngle = Mathf.DeltaAngle(RotationObject.transform.eulerAngles.x,0);
        float sideAngle = Mathf.DeltaAngle(RotationObject.transform.eulerAngles.z,0);

        
        if (Input.GetKey(KeyCode.UpArrow) && checkFowardAngle(fowardAngle))
            {
                //Debug.Log("Up arrow pressed");
                RotationObject.transform.Rotate(-Vector3.left, angleOfRotation, Space.World);
            }
  
            if(Input.GetKey(KeyCode.DownArrow) && checkBackAngle(fowardAngle))
            {
                //Debug.Log("Up down pressed");
                RotationObject.transform.Rotate(Vector3.left, angleOfRotation, Space.World);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && checkLeftAngle(sideAngle))
            {
                //Debug.Log("Up left pressed");
                RotationObject.transform.Rotate(Vector3.forward, angleOfRotation, Space.Self);
            }

            if (Input.GetKey(KeyCode.RightArrow) && checkRightAngle(sideAngle))
            {
                //Debug.Log("Up right pressed");
                RotationObject.transform.Rotate(-Vector3.forward, angleOfRotation, Space.Self);
            }

            
    }

    private bool checkBackAngle(float fowardAngle)
    {
        if(fowardAngle > maximumRotationAngle)
            return false;

        return true;
    }

    private bool checkLeftAngle(float sideAngle)
    {

        
        if (sideAngle < -maximumRotationAngle)
            return false;
        return true;    
    }

    private bool checkRightAngle(float sideAngle)
    {
        if (sideAngle > maximumRotationAngle)
            return false;
        return true;
    }

    private bool checkFowardAngle(float fowardAngle)
    {
        if (fowardAngle < -maximumRotationAngle)
            return false;

        return true;
    }

    private bool checkAllAngle(float angle)
    {
        double squareAngle = Math.Pow(Math.Floor(angle), 2);

        if (squareAngle <= 256)
            return true;

        return false;
    }
    
}
