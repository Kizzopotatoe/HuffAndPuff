using UnityEngine;

public class FPSManager : MonoBehaviour
{
    public int frameTarget;     //Value that the framerate will target

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameTarget;
    }
}
