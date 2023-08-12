// using UnityEngine;

// public class CircleSpawner : MonoBehaviour
// {
//     public GameObject circlePrefab;
//     public int minCircles = 5;
//     public int maxCircles = 10;
//     public RectTransform canvasRect;

//     void Start()
//     {
//         SpawnCircles();
//     }

//     public void SpawnCircles()
//     {
//         int numCircles = Random.Range(minCircles, maxCircles + 1);

//         for (int i = 0; i < numCircles; i++)
//         {
//             Vector3 spawnPos = new Vector3(
//                 Random.Range(canvasRect.rect.xMin, canvasRect.rect.xMax),
//                 Random.Range(canvasRect.rect.yMin, canvasRect.rect.yMax),
//                 0
//             );
            
//             Vector3 worldSpawnPos = canvasRect.TransformPoint(spawnPos);

//             GameObject circle = Instantiate(circlePrefab, worldSpawnPos, Quaternion.identity);
//             circle.transform.SetParent(canvasRect);
//         }
//     }
// } 
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab;
    public int minCircles = 5;
    public int maxCircles = 10;
    public RectTransform canvasRect;

    void Start()
    {
        SpawnCircles();
    }

    public void SpawnCircles()
    {
        int numCircles = Random.Range(minCircles, maxCircles + 1);

        for (int i = 0; i < numCircles; i++)
        {
            Vector3 spawnPos = GetRandomPositionOnCanvas();

            GameObject circle = Instantiate(circlePrefab, spawnPos, Quaternion.identity);
            circle.transform.SetParent(canvasRect);
        }
    }

    Vector3 GetRandomPositionOnCanvas()
    {
        Vector2 randomPoint = RandomPointInRectTransform(canvasRect);
        return canvasRect.TransformPoint(randomPoint); // Convert to world position
    }

    Vector2 RandomPointInRectTransform(RectTransform rectTransform)
    {
        Vector2 randomPoint = new Vector2(
            Random.Range(rectTransform.rect.xMin, rectTransform.rect.xMax),
            Random.Range(rectTransform.rect.yMin, rectTransform.rect.yMax)
        );

        return randomPoint;
    }
}
