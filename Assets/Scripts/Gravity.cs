using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{

    public GameObject attractedTo;
    public Rigidbody rb;
    public Mesh mesh;
    public float strengthOfAttraction = 50.0f;

    public Vector3 NearestVertexTo(Vector3 point)
    {

        point = transform.InverseTransformPoint(point);

        float minDistanceSqr = Mathf.Infinity;
        Vector3 nearestVertex = Vector3.zero;
        // scan all vertices to find nearest
        foreach (Vector3 vertex in mesh.vertices)
        {
            Vector3 diff = point - vertex;
            float distSqr = diff.sqrMagnitude;
            if (distSqr > minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                nearestVertex = vertex;
            }
        }
        // convert nearest vertex back to world space
        return transform.TransformPoint(nearestVertex);
    }

    public void Start() { }
    public void Update()
    {

        //Vector3 direction = attractedTo.transform.position - transform.position;
        Vector3 v = transform.position;
        Vector3 direction = -NearestVertexTo(v);
        rb.AddForce(strengthOfAttraction * direction);

    }


}