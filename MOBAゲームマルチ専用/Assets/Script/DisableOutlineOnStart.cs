using UnityEngine;

public class DisableOutlineOnStart : MonoBehaviour
{
    private float delay = 0.01f;
    Outline outline;

    //開始
    void Start ()
    {
        outline = GetComponent<Outline>();
        Invoke("DisableOutline", delay);
    }

    private void DisableOutline()
    {
        outline.enabled = false;
    }
}
