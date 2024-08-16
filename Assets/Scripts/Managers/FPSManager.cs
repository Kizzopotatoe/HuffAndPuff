using UnityEngine;

public class FPSManager : MonoBehaviour
{
    public int frameTarget;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameTarget;
    }
}
