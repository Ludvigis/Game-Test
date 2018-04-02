using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {
    public Camera cam;

    public float RecallCooldown = 5.0f;
    private float RecallTimer;

    public float BlinkRechargeTime = 3.0f;
    public int MaxBlinkCharges = 3;
    private int BlinkCharges;
    private float BlinkRechargeTimer;

    public float weaponRange;
    public float weaponAccuracy;

    
    
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
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Blink();
        }

    }

    private void Fire()
    {
        float spreadX = Random.Range(-(1 - weaponAccuracy), 1 - weaponAccuracy);
        float spreadY = Random.Range(-(1 - weaponAccuracy), 1 - weaponAccuracy);
        Vector3 bulletSpread = new Vector3(spreadX, spreadY, 0);
        Vector3 targetDirection = cam.transform.forward + bulletSpread;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, targetDirection, out hit, weaponRange))
        {
            Debug.Log(hit.transform.name);
        }
        Debug.DrawRay(cam.transform.position, targetDirection * weaponRange, Color.red,1);
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
        Debug.Log(BlinkCharges);
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
