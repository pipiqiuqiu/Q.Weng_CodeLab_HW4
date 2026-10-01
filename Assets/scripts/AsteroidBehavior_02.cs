using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform targetPosition;
    public Transform startPosition;
    public float AsteroidSpeed = 2f;

    void Start()
    {
        
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, AsteroidSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            transform.position = startPosition.position;
        }
        
    }
}
