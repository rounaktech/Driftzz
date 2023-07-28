using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float MoveSpeed = 50f;
    public float Drag = 0.98f;
    public float MaxSpeed = 15f;
    private Vector3 moveforce;
    public static float steerinput = 0;
    public float steerangle = 20f;
    public float traction = 1;
    public GameObject kill;
    float verticalint = 0;
    public GameObject EndMenu;

    public ParticleSystem driftsmoke;
    public ParticleSystem destruction;
  
    void Start()
    {
        
    }

    void Update()
    {
        

       
        //Drift Smoke
        if (steerinput > 0.5 || steerinput < -0.5)
        {
            driftsmoke.Play();
       
        }
        else
        {
            driftsmoke.Stop();
            ;
        }
       

        
    }

    private void FixedUpdate()
    {
        //Vertical input - Accelerate Car Smoothly
        if (verticalint < 1)
        {
            verticalint += 0.05f;
        }

        //Moving - Moving Forward 
        moveforce += transform.forward * MoveSpeed * verticalint * Time.deltaTime;
        transform.position += moveforce * Time.deltaTime;

        //Drifting
        
        transform.Rotate(Vector3.up * steerinput * moveforce.magnitude * steerangle * Time.deltaTime);

        //Limiting Speed and Drag
        moveforce *= Drag;
        moveforce = Vector3.ClampMagnitude(moveforce, MaxSpeed);

        //Traction
        /*Debug.DrawRay(transform.position, moveforce.normalized * 10);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);*/
        moveforce = Vector3.Lerp(moveforce.normalized, transform.forward, traction * Time.deltaTime) * moveforce.magnitude;
        //Finally I understood how lerp finds the mid val between two lines. Here, we are tring to close out gap between car's direction and moveforce direction

    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.tag == "Enemy")
        {
            Vector3 finalPosition = gameObject.transform.position;
            Instantiate(destruction,finalPosition,Quaternion.identity);
            kill.SetActive(true);
            EndMenu.SetActive(true);
            Destroy(gameObject);
        }
    }
}
