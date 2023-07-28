using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 23f;
    public float rotatespeed = 8f;

    private GameObject target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        //This is what Shumbham Sir Taught me during my interview
        Vector3 pointtarget = transform.position - target.transform.position;
        pointtarget.Normalize();

        float value = Vector3.Cross(pointtarget, transform.forward).y;

        rb.angularVelocity = rotatespeed * value * new Vector3(0, 1, 0);
        rb.velocity = transform.forward * speed;
    }
}
