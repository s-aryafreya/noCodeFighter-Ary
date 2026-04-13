using UnityEngine;

public class Player : MonoBehaviour
{
    //3 did movement, shooting, teleporting
    //teleporting and movement together

    public GameObject projectilePrefab;
    private float playerSpeed;

    //prevent error by declaring input
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
        Movement();
    }
    void Movement()
    {
        //read wasd - "horizontal" and "vertical" axis
        horizontalInput = Input.GetAxis("Horizontal"); //capitalized always
        verticalInput = Input.GetAxis("Vertical"); //capitalized always

        //takes in one vector (direction) multiplied by time * speed
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);

        //player leaves horiz - Teleporting/Wrapping logic stays the same
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        //Vertical Constraint - Stay between bottom (-6.5) and middle (0)
        //If player goes above the middle (0), snap them back to 0
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        //If player goes below the bottom limit, snap them back to the bottom
        else if (transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //1st what we spawn, 2nd position we spawn, 3rd rotation we spawn
            Instantiate(projectilePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}