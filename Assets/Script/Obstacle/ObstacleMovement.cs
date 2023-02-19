using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] var_Spawn spawn;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * spawn.speed * Time.deltaTime;
        if(transform.position.x < -6)
        {
            PipePool.Instance.ReturnPipeToPool(gameObject);
        }
    }
}
