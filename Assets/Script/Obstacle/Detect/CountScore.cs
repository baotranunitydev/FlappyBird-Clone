
public class CountScore : BaseDetect
{
    private BaseDetect baseDetect;
    // Start is called before the first frame update
    void Start()
    {
        baseDetect = GetComponent<BaseDetect>();
        baseDetect.ScaleX = 2;
        baseDetect.ScaleY = 2;
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
