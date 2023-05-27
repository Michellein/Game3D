using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (horizontal < 0)
        {
            transform.position = transform.position - Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (transform.position.x >= 2.8f) 
        {
            transform.position -= new Vector3(5.6f, 0, 0);
        }
        else if (transform.position.x <= -2.8f)
        {
            transform.position += new Vector3(5.6f, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (this.GetComponent<Rigidbody2D>().velocity.y <= 0) 
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 400);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WinBox"))
        {
            Debug.Log("Win");
            UIManager.Instance.OnWin();
            gameObject.SetActive(false);
        }
        if (collision.CompareTag("LoseBox"))
        {
            Debug.Log("Lose");
            UIManager.Instance.OnLose();
            gameObject.SetActive(false);
        }
    }
}
