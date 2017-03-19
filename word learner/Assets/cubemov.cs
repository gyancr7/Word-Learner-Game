//script for gun movement
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemov : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject spawn;
    //force of bullet
    public float bulletforce;
    //speed of bullet
    public float bulletspeed;
    float gunspeed = 1000.0f;
    //gameobject reference to the gun.
    GameObject gunref;

    // Use this for initialization
    void Start()
    {
        gunref = GameObject.Find("guncube");
    }

    //logic to fire bullet grom the gun
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        GameObject tempbullet;
        tempbullet = Instantiate(bulletPrefab, spawn.transform.position, spawn.transform.rotation) as GameObject;
        Rigidbody temprigidbody;
        temprigidbody = tempbullet.GetComponent<Rigidbody>();
        temprigidbody.AddForce(transform.forward * bulletforce);
        temprigidbody.velocity = new Vector3(0, bulletspeed, 0);
        // Destroy the bullet after 3 seconds
        Destroy(tempbullet, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //press left/right arrow keys to move the gun.
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
        gunref.transform.position += moveDir * gunspeed * Time.deltaTime;

        //press space to fire bullets
        if (Input.GetKeyDown("space"))
        {
            Fire();

        }



    }
}
