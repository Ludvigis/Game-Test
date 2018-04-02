using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {
    //public Camera cam;
    
    public float RecallCooldown = 5.0f;
    private float RecallTimer;

    public float BlinkRechargeTime = 3.0f;
    public int MaxBlinkCharges = 3;
    private int BlinkCharges;
    private float BlinkRechargeTimer;


    
    
	// Use this for initialization
	void Start () {
        BlinkCharges = MaxBlinkCharges;
	}
	
	// Update is called once per frame
	void Update () {
        CalculateCooldownAndCharges();
        if (Input.GetKey("e") && RecallTimer <= 0)
        {
            Debug.Log("Recall");
            RecallTimer = RecallCooldown;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Blink();
        }

    }


    private void Blink()
    {
        if(BlinkCharges > 0)
        {
            //Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("vertical");     //y = transform.position. y?

            BlinkCharges--;
        }
        
        Debug.Log("Blink");   
    }

    private void CalculateCooldownAndCharges()
    {
        //Debug.Log(BlinkCharges);
        RecallTimer -= Time.deltaTime;
        if (BlinkCharges < MaxBlinkCharges)
        {
            BlinkRechargeTimer -= Time.deltaTime;
        }

        if (BlinkRechargeTimer <= 0 && BlinkCharges < MaxBlinkCharges)
        {
            BlinkCharges++;
            BlinkRechargeTimer = BlinkRechargeTime;
        }

    }
}
