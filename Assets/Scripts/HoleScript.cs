using UnityEngine;
using System.Collections;

public class HoleScript : MonoBehaviour {

    public BrainScript Brain;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ball is in the hole");
        Brain.reset();
    }

}
