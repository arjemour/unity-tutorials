using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float FadeInTime;
    private Image fadePanel;
    private Color currentColor = Color.black;

    // Use this for initialization
    private void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeSinceLevelLoad < FadeInTime)
        {
            float alphaChange = Time.deltaTime / FadeInTime;
            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}