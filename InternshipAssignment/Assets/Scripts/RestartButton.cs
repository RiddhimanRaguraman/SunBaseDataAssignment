using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Import the UnityEngine.UI namespace
using DG.Tweening;

public class RestartButton : MonoBehaviour
{
    public Image fadingOverlayImage;
    public RectTransform canvasRect;

    public void RestartScene()
    {
        // Fade in the overlay using DOTween
        fadingOverlayImage.DOFade(1f, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }
}
