using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool jumpKey;
    private float horizontalInput;
    public float speedModifier = 4;
    private Rigidbody2D rigidbodyComponent;

    public GameObject Exit;
    public GameObject EscapeText;

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

        if (GameObject.Find("Fusebox UI Element")) speedModifier = 0; else speedModifier = 4;

        PlayerOnExit();
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

    void PlayerOnExit()
    {
        if(transform.position.x >= 5.5f && transform.position.x <= 8.5f)
        {
            if (Exit.GetComponent<Exit>().isOpen == true)
            {
                Debug.Log("Exit");

                EscapeText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    int sceneIndex = SceneManager.GetActiveScene().buildIndex;
                    sceneIndex++;
                    if (sceneIndex == 3) sceneIndex = 0;
                    SceneManager.LoadScene(sceneIndex);
                }
            }
        }
        else
            EscapeText.SetActive(false);
    }

}
