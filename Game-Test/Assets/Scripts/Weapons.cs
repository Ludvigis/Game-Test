using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {
    public Transform leftGunMuzzle;
    public Transform rightGunMuzzle;

    public float weaponRange;
    public float weaponAccuracy = 0.95f;
    public float fireRate = 40.0f;
    
    private float timeToNextShot = 0;

    private void Start()
    {
          
    }

    // Update is called once per frame
    void Update () {
        timeToNextShot -= Time.deltaTime;
        

        if (Input.GetMouseButton(0) && timeToNextShot <= 0)
        {
            Fire();
            timeToNextShot = 1 / fireRate;
        }
    }

    private void Fire()
    {
        float spreadX = Random.Range(-(1 - weaponAccuracy), 1 - weaponAccuracy);
        float spreadY = Random.Range(-(1 - weaponAccuracy), 1 - weaponAccuracy);
        Vector3 bulletSpread = new Vector3(spreadX, spreadY, 0);
        Vector3 targetDirection = leftGunMuzzle.forward + bulletSpread;
        RaycastHit hit;
        if (Physics.Raycast(leftGunMuzzle.position, targetDirection, out hit, weaponRange) || Physics.Raycast(rightGunMuzzle.position, targetDirection, out hit, weaponRange))
        {
            Debug.Log(hit.transform.name);
        }
        Debug.DrawRay(leftGunMuzzle.position, targetDirection * weaponRange, Color.red, 1);
        Debug.DrawRay(rightGunMuzzle.position, targetDirection * weaponRange, Color.red, 1);
    }

}
