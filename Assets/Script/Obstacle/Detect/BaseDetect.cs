using UnityEngine;

public class BaseDetect : MonoBehaviour
{
    [SerializeField] var_Player player;
    float scaleX;
    float scaleY;

    public var_Player Player { get => player; set => player = value; }
    public float ScaleX { get => scaleX; set => scaleX = value; }
    public float ScaleY { get => scaleY; set => scaleY = value; }

    public virtual void Detected()
    {

    }

    public void Lose()
    {
        Player.isDetected = true;
    }

    public void Score()
    {
        Player.currentScore++;
        Player.isChange = true;
    }

    public void Ground()
    {
        if (Player.transform.position.y <= -3.65 && !Player.isDetected)
        {
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySoundEffect("Die");
            }
            Player.isDetected = true;
        }
    }

    public void SoundDie()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("Die");
        }
    }

    public void SoundScore()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("CountScore");
        }
    }

    public bool IsColliding(Transform rect1, Transform rect2)
    {
        float rect1Left = rect1.position.x - rect1.localScale.x / 2.3f;
        float rect1Right = rect1.position.x + rect1.localScale.x / 2.3f;
        float rect1Top = rect1.position.y + rect1.localScale.y / 2.3f;
        float rect1Bottom = rect1.position.y - rect1.localScale.y / 2.3f;

        float rect2Left = rect2.position.x - rect2.localScale.x / ScaleX;
        float rect2Right = rect2.position.x + rect2.localScale.x / ScaleX;
        float rect2Top = rect2.position.y + rect2.localScale.y / ScaleY;
        float rect2Bottom = rect2.position.y - rect2.localScale.y / ScaleY;

        if (rect1Left < rect2Right && rect1Right > rect2Left && rect1Top > rect2Bottom && rect1Bottom < rect2Top)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
