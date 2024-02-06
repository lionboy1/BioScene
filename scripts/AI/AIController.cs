using UnityEngine;

namespace Bioscene
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] Transform location;
        [SerializeField] float movementSpeed;
        [SerializeField] float rotationSpeed;
        Location locationComponent;
        Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            locationComponent = FindObjectOfType<Location>();
            location = locationComponent.transform;
            transform.position = new Vector3(18, 10, 0);
        }
        // void FixedUpdate()
        // {
        //     rb.velocity = new Vector3(
        //         location.position.x * movementSpeed,
        //         location.position.y * movementSpeed,
        //         0).normalized;  
        // }
        void Update()
        {
            var step = movementSpeed * Time.deltaTime;
            transform.position  = Vector3.MoveTowards(transform.position, location.position, step);
            transform.LookAt(location);
            Rotate();
        }
        void Rotate()
        {
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, location.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}