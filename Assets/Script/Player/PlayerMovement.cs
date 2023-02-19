using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float gravity;
    [SerializeField] var_Player player;

    void Start()
    {
        player.transform = transform;
        player.force = force;
        player.gravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fly();
        }
        else
        {
            Graviti();
        }
    }

    void Fly()
    {
        transform.Translate(new Vector3(0, player.force, 0) * Time.deltaTime);
        if (AudioManager.HasInstance && player.isSoundFly)
        {
           AudioManager.Instance.PlaySoundEffect("Fly");
        }
    }

    void Graviti()
    {
        transform.Translate(new Vector3(0,-player.gravity, 0) * Time.deltaTime);
    }
}

