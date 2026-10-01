using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    InputAction upButton;
    InputAction downButton;
    InputAction leftButton;
    InputAction rightButton;

    public float StartSpeed = 2;
    public float speed = 2;
    private AudioSource myCDPlayer;
    
    private Vector3 StartPosition;
    
    public SpeedUpBoxMechenics speedUpBox;
    void Start()
    {
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");
        leftButton = InputSystem.actions.FindAction("Left");
        rightButton = InputSystem.actions.FindAction("Right");
        
        myCDPlayer = GetComponent<AudioSource>();
        StartPosition = transform.position;
        speed = StartSpeed;
    }

   
    void Update()
    {
        Vector3 playerPosition = transform.position;
        if (upButton.IsPressed())
        {
            playerPosition.y += speed * Time.deltaTime;
        }
        if (downButton.IsPressed())
        {
            playerPosition.y -= speed * Time.deltaTime;
        }
        if (leftButton.IsPressed())
        {
            playerPosition.x -= speed * Time.deltaTime;
        }
        if (rightButton.IsPressed())
        {
            playerPosition.x += speed * Time.deltaTime;
        }
        //player begin to move
        transform.position = playerPosition;
        
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        //playerPosition.x = Mathf.Clamp(playerPosition.x, bottomLeft.x, topRight.x);
        //playerPosition.y = Mathf.Clamp(playerPosition.y, bottomLeft.y, topRight.y);

        transform.position = playerPosition;

        if (transform.position.y > topRight.y ||  transform.position.y < bottomLeft.y || 
            transform.position.x > topRight.x ||  transform.position.x < bottomLeft.x)
        {
            speed = StartSpeed;
            speedUpBox.gameObject.SetActive(true);
            transform.position = StartPosition;
            speedUpBox.ResetPostion();
        }

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            myCDPlayer.Play();
            Debug.Log("Touched something");
            
            speedUpBox.gameObject.SetActive(true);
            transform.position = StartPosition;
            speedUpBox.ResetPostion();
            speed = StartSpeed;
        }
        
        if (other.gameObject.tag == "SpeedUpBox")
        {
            speed = 2*StartSpeed;
        }
        
    }
    
    
    
}
