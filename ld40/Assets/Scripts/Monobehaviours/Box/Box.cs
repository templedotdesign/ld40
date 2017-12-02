using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [SerializeField]Rigidbody2D body;
    [SerializeField]float speed;
    [SerializeField]Loss loss;

    bool landed = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "conveyor") 
        {
            landed = true;
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "conveyor")
        {
            landed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "loss") {
            loss.total++;
            Destroy(gameObject);
        }
    }


    void FixedUpdate () {
        if(landed && loss.total < 50) 
        {
            body.MovePosition((Vector2)transform.position + (Vector2.right * speed * Time.fixedDeltaTime));
        }
	}

    void OnMouseDown()
    {
        Debug.Log("clicked box"); 
    }
}
