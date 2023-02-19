using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(transform.position.x < -6)
        {
            PipePool.Instance.ReturnPipeToPool(gameObject);
        }
    }
}
