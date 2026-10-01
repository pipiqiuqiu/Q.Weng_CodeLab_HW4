using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    
    public Transform targetPosition;
    public Transform startPosition;
    public float AsteroidSpeed = 2f;
    private bool MovingToTargrt = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (MovingToTargrt)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, AsteroidSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            MovingToTargrt = false;
        }

        if (MovingToTargrt == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition.position, AsteroidSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, startPosition.position) < 0.1f)
        {
            MovingToTargrt = true;
        }
       

    }
}
