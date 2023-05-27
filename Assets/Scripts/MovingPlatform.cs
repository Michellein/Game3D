using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private int direct = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.right * speed * direct * Time.deltaTime;
        if (transform.position.x >= 2f)
        {
            direct = -1;
        }
        else if (transform.position.x <= -2f)
        {
            direct = 1;
        }
    }
}
