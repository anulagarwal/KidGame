using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public bool hasPlaced;
    // Start is called before the first frame update
    void Start()
    {
        hasPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPlaced)
        {

            Destroy(gameObject);

        }
    }
}
