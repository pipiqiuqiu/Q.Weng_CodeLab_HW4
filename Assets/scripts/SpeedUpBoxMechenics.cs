using UnityEngine;

public class SpeedUpBoxMechenics : MonoBehaviour
{
    public void ResetPostion()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));

        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));

        float randomX = Random.Range(bottomLeft.x, topRight.x);
        float randomY = Random.Range(bottomLeft.y, topRight.y);

        transform.position = new Vector3(randomX, randomY, transform.position.z);
    }
    
    void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetPostion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
