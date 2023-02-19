
public class Detect : BaseDetect
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
        baseDetect.Ground();
    }

    public override void Detected()
    {
        if (IsColliding(Player.transform, transform) && ! baseDetect.Player.isDetected)
        {
            baseDetect.SoundDie();
            Player.isSoundFly = false;
            baseDetect.Lose();
        }
    }
}
