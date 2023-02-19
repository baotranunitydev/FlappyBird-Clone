using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float force;
    [SerializeField] float gravity;
    [SerializeField] var_Player player;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        player.transform = transform;
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
        Ground();
    }

    void Fly()
    {
        if(AudioManager.HasInstance && player.isSoundFly)
        {
           AudioManager.Instance.PlaySoundEffect("Fly");
        }
        transform.Translate(new Vector3(0,force,0) * Time.deltaTime);
    }

    void Graviti()
    {
        transform.Translate(new Vector3(0,-gravity,0) * Time.deltaTime);

    }

    void Ground()
    {
        if (transform.position.y <= -3.65 && !player.isDetected)
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySoundEffect("Die");
            }
            player.isDetected = true;  
        }
    }
}

