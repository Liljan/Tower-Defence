using UnityEngine;

public class FastForward : MonoBehaviour
{
    private float timeScale = 10.0f;
    private bool isFast = false;

    public void ChangeSpeed()
    {
        if (isFast)
        {
            Time.timeScale = 1.0f;
            isFast = false;
        }

        else {
            Time.timeScale = timeScale;
            isFast = true;
        }
    }
}
