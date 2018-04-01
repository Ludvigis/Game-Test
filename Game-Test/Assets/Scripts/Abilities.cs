using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

    public float RecallCooldown = 5.0f;
    private float RecallTimer;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        RecallTimer -= Time.deltaTime;
        if (Input.GetKey("e") && RecallTimer <= 0)
        {
            Debug.Log("Recall");
            RecallTimer = RecallCooldown;
        }
		
	}
}
