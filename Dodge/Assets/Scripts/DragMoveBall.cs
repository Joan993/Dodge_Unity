using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragMoveBall : MonoBehaviour
{

    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float speed = 10f;

    private GameObject pumpkin;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
//        SpawnPumpkin();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            float x = touchPosition.x;
            if(x < -6.9f)
            {
                x = -6.9f;
            }
            else if (x > 6.9f)
            {
                x = 6.9f;
            }
            transform.position = new Vector3(x,transform.position.y, 0.0f);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Trap")
        {
            SceneManager.LoadScene("Restart");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            SceneManager.LoadScene("Restart");
        }

    }

}
