using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool jumpKey;
    private float horizontalInput;
    public float speedModifier = 3;
    private Rigidbody2D rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        if(jumpKey)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5);
            jumpKey = false;
        }

        rigidbodyComponent.velocity = new Vector3(speedModifier * horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

}
