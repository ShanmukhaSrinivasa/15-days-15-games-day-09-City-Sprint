using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftBound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
