using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineToPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject linePrefab;
    public GameObject lineObject;
    public Transform startTransform;
    public Transform endTransform;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineObject = Instantiate(linePrefab);
        lineRenderer = lineObject.GetComponent<LineRenderer>();

        player = GameObject.Find("PlayerBasics");

        if (player != null)
        {
            // Find 'Player' object in 'Player Basic' object
            endTransform = player.transform.Find("Player");

            if (endTransform == null)
            {
                Debug.LogWarning("Child object with the specified name not found.");
            }
        }


        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not found in the prefab.");
            return;
        }

        // set line start point and end point
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // start point
            lineRenderer.SetPosition(1, endTransform.position); // end point
        }
        else
        {
            Debug.LogWarning("Start or end transform is not assigned.");
        }
    }

    void Update()
    {
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // start point
            lineRenderer.SetPosition(1, endTransform.position); // end point
        }
    }

    private void OnDisable()
    {
        if (lineObject)
        {
            lineObject.SetActive(false);
        }
    }
}
