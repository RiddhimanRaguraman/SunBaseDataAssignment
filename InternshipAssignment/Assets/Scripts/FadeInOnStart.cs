using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace
using DG.Tweening;

public class FadeInOnStart : MonoBehaviour
{
    public Image fadingOverlayImage;

    void Start()
    {
        FadeIn();
    }

    void FadeIn()
    {
        fadingOverlayImage.color = new Color(0f, 0f, 0f, 1f); // Set the initial color to fully opaque black
        fadingOverlayImage.DOFade(0f, 1f); // Gradually fade out the overlay over 1 second
    }
}
