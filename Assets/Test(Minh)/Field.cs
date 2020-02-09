using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Field : MonoBehaviour
{

    // References to mesh filter and renderer components
    MeshFilter mf;
    MeshRenderer mr;

    // Array specifying mesh vertices and triangles
    private Vector3[] vertices;
    private int[] triangles;

    // Reference to mesh
    private Mesh mesh;

    // Radius of the circle
    float radius = 2.609387f;
    // Number of points on circle's circumference
    int numPoints = 64;

    // Use this for initialization
    void Start()
    {
        // Get references to the mesh filter and renderer components
        mf = GetComponent<MeshFilter>();
        mr = GetComponent<MeshRenderer>();

        // Create new mesh and attach it to the mesh filter
        mesh = new Mesh();
        mf.mesh = mesh;

        // Set circle colour (and make it a bit transparent)
        mr.material.color = new Color(0f, 1f, 0f, 0.5f);

        // Initialise array for vertices and triangles (one extra
        // vertex is taken for the centre of the circle)
        vertices = new Vector3[numPoints + 1];
        triangles = new int[numPoints * 3];
    }

    void Update()
    {

        // Compute the angle between two triangles in the cricle
        float delta = 2f * Mathf.PI / (float)(numPoints - 1);
        // Stat with angle of 0
        float alpha = 0f;

        // The center vertex (index 0) is at location (0,0)
        vertices[0].x = 0;
        vertices[0].y = 0;
        vertices[0].z = transform.position.z;

        // Specify the layer mast for ray casting - ray casting will
        // only interact with layer 8
        int layerMask = 1 << 8;

        //Other vertices will be positioned evenly around the circle
        for (int i = 1; i <= numPoints; i++)
        {
            //Radius and alpha give a position of a point around
            //the circle in spherical coordinates 

            // Compute position x from spherical coordinates
            float x = radius * Mathf.Cos(alpha);
            // Compute position y from spherical coordinates
            float y = radius * Mathf.Sin(alpha);

            // Create a ray
            Vector2 ray = new Vector2(x, y);

            ray.x *= transform.lossyScale.x;
            ray.y *= transform.lossyScale.y;

            // Cast the ray 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ray, ray.magnitude, layerMask);
            // Check if ray has hit something, if yes, check how far from the ray's origin point
            // and adjust the distance of where the mesh point is going to be located.
            if (hit.collider != null)
            {
                float distance = hit.distance;
                x = distance * Mathf.Cos(alpha) / transform.lossyScale.x;
                y = distance * Mathf.Sin(alpha) / transform.lossyScale.y;
            }

            // Set the vertex values
            vertices[i].x = x;
            vertices[i].y = y;
            vertices[i].z = transform.position.z;

            //Specify the triangle going from 0 vertex (centre) to
            //the i vertex and the previous vertex on the circle
            triangles[(i - 1) * 3] = 0;
            if (i == 1)
            {
                // If current vertex is 1, then previous vertex is the
                // last vertex (to close the cricle)
                triangles[(i - 1) * 3 + 1] = numPoints;
            }
            else
            {
                triangles[(i - 1) * 3 + 1] = i - 1;
            }
            triangles[(i - 1) * 3 + 2] = i;

            // Increase the angle to get the next positon around the circle
            alpha += delta;
        }
        // Set the new vertices and triangles in the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Compute the angle between two triangles in the cricle
        float delta = 2f * Mathf.PI / (float)(numPoints - 1);
        // Stat with angle of 0
        float alpha = 0f;

        //Other vertices will be positioned evenly around the circle
        for (int i = 1; i <= numPoints; i++)
        {
            //Radius and alpha give a position of a point around
            //the circle in spherical coordinates 

            // Compute position x from spherical coordinates
            float x = radius * Mathf.Cos(alpha);
            // Compute position y from spherical coordinates
            float y = radius * Mathf.Sin(alpha);

            // Create a ray
            Vector3 ray = new Vector3(x, y, transform.position.z);

            ray.x *= transform.lossyScale.x;
            ray.y *= transform.lossyScale.y;

            Gizmos.DrawRay(transform.position, ray);

            // Increase the angle to get the next positon around the circle
            alpha += delta;
        }
    }
}