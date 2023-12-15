using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public Rigidbody2D rb;
    public Animator animator;

    public bool isAllowedToMove = true;

    public object CaptureState()
    {
        float[] position = new float[] { transform.position.x, transform.position.y };
        return position;
    }

    public void RestoreState(object state)
    {
        var position = (float[])state;
        transform.position = new Vector3(position[0], position[1]);
    }


    // Start is called before the first frame update
    void Start()
    {
        isAllowedToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAllowedToMove == true)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
            Vector2 normalizedInput = inputVector.normalized;

            rb.MovePosition(rb.position + new Vector2(normalizedInput.x * movementSpeed, normalizedInput.y * movementSpeed) * Time.deltaTime);
        }

    }

}
