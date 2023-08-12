// using UnityEngine;
// using DG.Tweening;

// public class CircleRemoval : MonoBehaviour
// {
//     public LayerMask sphereLayer;

//     void Update()
//     {
//         if (Input.GetMouseButtonUp(0))
//         {
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;

//             if (Physics.Raycast(ray, out hit, Mathf.Infinity, sphereLayer))
//             {
//                 Debug.Log("Sphere clicked: " + hit.collider.gameObject.name);

//                 // Apply a fade out animation using DOTween
//                 Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

//                 if (renderer != null)
//                 {
//                     Material material = renderer.material;
//                     Color originalColor = material.color;
                    
//                     // Start fading animation using DOTween
//                     DOTween.To(() => material.color, c => material.color = c, 
//                         new Color(originalColor.r, originalColor.g, originalColor.b, 0f), 0.5f)
//                         .OnComplete(() => Destroy(hit.collider.gameObject));
//                 }
//             }
//         }
//     }
// }
using UnityEngine;
using DG.Tweening;

public class CircleRemoval : MonoBehaviour
{
    public LayerMask sphereLayer;
    public float animationDuration = 0.5f;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, sphereLayer))
            {
                Debug.Log("Sphere clicked: " + hit.collider.gameObject.name);

                // Apply a fade out animation using DOTween
                GameObject circleObject = hit.collider.gameObject;
                Renderer renderer = circleObject.GetComponent<Renderer>();

                if (renderer != null)
                {
                    // Start fading radius animation using DOTween
                    circleObject.transform.DOScale(Vector3.zero, animationDuration)
                        .OnComplete(() => Destroy(circleObject));
                }
            }
        }
    }
}
