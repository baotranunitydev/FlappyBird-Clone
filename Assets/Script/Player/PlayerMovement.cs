using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] var_Player player;

    private void Start()
    {
        player.transform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fly();
        }
        Gravity();
    }

    void Fly()
    {
        var playerForce = new Vector3(0,Mathf.Clamp(player.force * Time.deltaTime,0,0.8f), 0);
        transform.Translate(playerForce);
        if (AudioManager.HasInstance && player.isSoundFly)
        {
           AudioManager.Instance.PlaySoundEffect("Fly");
        }
    }

    void Gravity()
    {
        transform.Translate(new Vector3(0,-player.gravity, 0) * Time.deltaTime);
    }
}

