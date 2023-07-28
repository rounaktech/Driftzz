using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{

    public GameObject floor;
    public GameObject inspoint;
    bool used = false;
    public GameObject triggerdestroy;
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && used == false)
        {
            Debug.Log("Trigger Detection");
            Vector3 floorspawnlocation = inspoint.transform.position;
            Instantiate(floor, floorspawnlocation, Quaternion.identity);
            used = true;
            
        }
    }
}
