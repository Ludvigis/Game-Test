using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

    public float RecallCooldown = 5.0f;
    public Camera cam;
    private float RecallTimer;

    public float weaponRange;
    public float weaponAccuracy;

    
    
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
        if (Input.GetMouseButton(0))
        {
            Fire();
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
}
