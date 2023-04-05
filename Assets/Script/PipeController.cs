using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PipeMovement();
    }

    void PipeMovement()
    {
        Vector3 temp = transform.position; 
        temp.x -= moveForce * Time.deltaTime;
        transform.position = temp;  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DestroyPipe")
        {
            Destroy(gameObject);
        }
    }
}
