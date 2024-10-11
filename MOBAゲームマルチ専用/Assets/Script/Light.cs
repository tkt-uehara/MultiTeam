using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject thePlayer;

    void Update()
    {
        transform.LookAt(thePlayer.transform);
    }
}
