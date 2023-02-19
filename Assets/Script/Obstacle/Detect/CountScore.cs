using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : BaseDetect
{
    private BaseDetect baseDetect;
    // Start is called before the first frame update
    void Start()
    {
        baseDetect = GetComponent<BaseDetect>();
    }

    // Update is called once per frame
    void Update()
    {
        Detected();
    }

    public override void Detected()
    {
        if (IsColliding(Player.transform, transform) && !baseDetect.Player.isChange)
        {
            baseDetect.SoundScore();
            Score();
        }
    }
}
