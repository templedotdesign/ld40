using UnityEngine;

public class Box : MonoBehaviour {

    public  Rigidbody2D body;
    public  BoxCollider2D col;

    [SerializeField] float speed;
    [SerializeField] Loss loss;
    [SerializeField] GameData data;

    [HideInInspector] public ColorTypes colorType;

    bool landed;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "loss") {
            loss.total++;
            Destroy(gameObject);
        }
    }

    void FixedUpdate () {
        if(landed && !data.gameOver) 
        {
            body.MovePosition((Vector2)transform.position + (Vector2.right * speed * Time.fixedDeltaTime));
        }
	}

    void OnMouseDown()
    {
        if(data.selectedBox != null) {
            data.selectedBox.body.isKinematic = false;
            data.selectedBox.col.enabled = true;
            data.selectedBox = null;
        }

        data.selectedBox = this;
        body.isKinematic = true;
        col.enabled = false;
    }
}
