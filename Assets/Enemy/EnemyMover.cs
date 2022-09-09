using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] private float speed = 1f;
    
    private void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PrintWaypointName());
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    private void FindPath()
    {
        path.Clear();
        GameObject parentPath = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parentPath.transform)
        {
            path.Add(child.GetComponent<Waypoint>());
        }
    }
    private IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPos);
            
            while (travelPercent < 1)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        Destroy(gameObject);
    }
}
