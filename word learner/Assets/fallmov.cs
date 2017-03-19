//script for motion of the falling spheres of alphabets
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallmov : MonoBehaviour {
    //force of fall
    public float fallforce = 90.0f;
    //speed of fall
    public float fallspeed = 400.0f;
    GameObject fallob;
    // Use this for initialization
    void Start()
    {
        fallob = this.gameObject;
    }

    //logic for falling movement
    void fall()
    {
        
        Rigidbody temprigidbody;
        temprigidbody = fallob.GetComponent<Rigidbody>();
        temprigidbody.AddForce(transform.forward * fallforce);
        temprigidbody.velocity = new Vector3(0, fallspeed, 0);
    }

    // Update is called once per frame
    void Update()
    {

        fall();
    }

    }
