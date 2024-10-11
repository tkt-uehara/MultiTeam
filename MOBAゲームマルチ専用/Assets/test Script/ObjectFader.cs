using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public float fadeSpeed, fadeAmount;
    float originalOpacity;
    Material Mat;
    public bool DoFade = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mat = GetComponent<Renderer>().material;
        originalOpacity = Mat.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (DoFade)
            FadeNow();
        else
            ResetFade();
    }

    void FadeNow()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }

    void ResetFade()
    {
        Color currentColor = Mat.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
            Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        Mat.color = smoothColor;
    }
}
