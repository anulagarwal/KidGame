using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hasPlaced;
    public int tolerance;
    void Start()
    {

        transform.position = Camera.main.transform.position;
        transform.rotation = Camera.main.transform.rotation;
        GetComponent<Rigidbody>().AddForce(transform.forward * 1, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {

        
        GameObject.Find("Teacher").GetComponent<Teacher>().Angry(collision.contacts[0].point);
        GameObject.Find("Teacher").GetComponent<Teacher>().IncreaseTolerance(tolerance);

     //   GameObject.Find("Teacher").GetComponent<Teacher>().Move(collision.contacts[0].point);
            Destroy(gameObject);
      
    }
}
