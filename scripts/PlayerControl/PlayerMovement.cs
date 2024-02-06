using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bioscene
{    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _speed;
        [SerializeField] Rigidbody2D _rigidBody;
        float h;
        float v;
        void Start()
        {
            transform.position = new Vector3(0, -3, 0);
        }
        void Update()
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(h, v).normalized;

            // movement *= _speed * Time.deltaTime; //for use without rigidbody
        }
        void FixedUpdate()
        {
           Move();
        }
        void Move()
        {
            //transform.Translate(movement);//for use without rigidbody

            _rigidBody.velocity = new Vector3(h * _speed, v * _speed, 0);

            if(transform.position.y >= 1)
            {
                transform.position = new Vector3(transform.position.x, 1, 0);
            }
            else if(transform.position.y <= -5)
            {
                transform.position = new Vector3(transform.position.x, -5, 0);
            }
            if(transform.position.x >= 8)
            {
                transform.position = new Vector3(8, transform.position.y, 0);
            }
            else if(transform.position.x <= -8)
            {
                transform.position = new Vector3(-8, transform.position.y, 0);
            }
        }
    }
}
