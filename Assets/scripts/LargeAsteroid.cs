using UnityEngine;

public class LargeAsteroid : MonoBehaviour
{
    public Transform player;
    public float detectDistance;
    public float startSpeed;
    public float speed;
    private bool isFollowing = false;
    private bool isMovingToRandomPosition = false;
    private Vector3 randomPosition;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = startSpeed;
        SetRandomPostion();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (isMovingToRandomPosition)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                randomPosition,
                startSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, randomPosition) < 0.1f)
            {
                isMovingToRandomPosition = false;
            }

            return;
        }
        
        if (!isFollowing && distance <= detectDistance)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }

        if (isFollowing && distance > detectDistance)
        {
            isFollowing = false;
            SetRandomPostion();
            isMovingToRandomPosition = true;
            return;
        }
    }
    
    void SetRandomPostion()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));

        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        float randomX = Random.Range(bottomLeft.x, topRight.x);
        float randomY = Random.Range(bottomLeft.y, topRight.y);

        randomPosition = new Vector3(randomX, randomY, transform.position.z);
    }
    
}
