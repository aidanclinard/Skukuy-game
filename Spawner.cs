using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject lowlyFairyPrefab; // Reference to the prefab of the lowly fairy

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Level1Easy());

    }

    IEnumerator Level1Easy()
    {
        yield return new WaitForSeconds(3f);
        //*****************************\/=startpos***********\/=startcurve**********\/=midcurve***************\/=endcurve**********
        //SpawnLowlyFairy(new Vector3(-5, 6, 0), new Vector3(-5, 6, 0), new Vector3(-2, -10, 0), new Vector3(0, 6, 0), 3f);

        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            SpawnLowlyFairy(new Vector3(-8, 5, 0), new Vector3(-8, 5, 0), new Vector3(-2, -8, 0), new Vector3(3, 5, 0), 3f, lowlyFairyPrefab);
            yield return new WaitForSeconds(0.1f);
            SpawnLowlyFairy(new Vector3(3, 5, 0), new Vector3(3, 5, 0), new Vector3(-2, -8, 0), new Vector3(-8, 5, 0), 3f, lowlyFairyPrefab);
        }
        
    }

    public void SpawnLowlyFairy(Vector3 startPoint, Vector3 globalControlPoint1, Vector3 globalControlPoint2, Vector3 globalEndPoint, float duration, GameObject enemytype)
    {
        // Convert global positions to local positions relative to the spawner
        Vector3 localStartPoint = transform.InverseTransformPoint(startPoint);
        Vector3 localControlPoint1 = transform.InverseTransformPoint(globalControlPoint1);
        Vector3 localControlPoint2 = transform.InverseTransformPoint(globalControlPoint2);
        Vector3 localEndPoint = transform.InverseTransformPoint(globalEndPoint);

        // Instantiate the lowlyFairy GameObject at the specified start point
        GameObject newenemy = Instantiate(enemytype, startPoint, Quaternion.identity);

        // Start a coroutine to move the newLowlyFairy along the customized Bezier curve with the specified duration and local control points
        StartCoroutine(MoveAlongBezierCurve(newenemy, localStartPoint, localControlPoint1, localControlPoint2, localEndPoint, duration));
    }

IEnumerator MoveAlongBezierCurve(GameObject obj, Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 endPoint, float duration)
{
    float elapsedTime = 0f;
    float t = 0f;

    while (elapsedTime < duration)
    {
        // Check if the object is still valid
        if (obj == null)
        {
            yield break; // Exit the coroutine if the object has been destroyed
        }

        // Calculate 't' based on elapsed time and desired duration
        t = elapsedTime / duration;

        // Calculate the position along the Bezier curve using cubic Bezier interpolation
        Vector3 newPosition = Bezier(t, startPoint, controlPoint1, controlPoint2, endPoint);

        // Update the object's position
        obj.transform.position = newPosition;

        // Increment the elapsed time
        elapsedTime += Time.deltaTime;

        yield return null; // Wait for the next frame
    }

    // Ensure the object ends up exactly at the end point
    if (obj != null)
    {
        obj.transform.position = endPoint;
    }

    // Optionally, destroy the object after reaching the end point
    Destroy(obj);
}

    public Vector3 Bezier(float t, Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 endPoint)
    {
        // Calculate the points along the Bezier curve using cubic Bezier interpolation
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 position = uuu * startPoint; // (1-t)^3 * P0
        position += 3f * uu * t * controlPoint1; // 3 * (1-t)^2 * t * P1
        position += 3f * u * tt * controlPoint2; // 3 * (1-t) * t^2 * P2
        position += ttt * endPoint; // t^3 * P3

        return position;
    }
}