using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class BackField : MonoBehaviour
{

    // References to mesh filter and renderer components
    MeshFilter bmf;
    MeshRenderer bmr;

    // Array specifying mesh vertices and triangles
    private Vector3[] bvertices;
    private int[] btriangles;

    // Reference to mesh
    private Mesh bmesh;

    // Radius of the circle
    float bradius = 2.609387f;
    // Number of points on circle's circumference
    int bnumPoints = 64;

    // Use this for initialization
    void Start()
    {
        // Get references to the mesh filter and renderer components
        bmf = GetComponent<MeshFilter>();
        bmr = GetComponent<MeshRenderer>();

        // Create new mesh and attach it to the mesh filter
        bmesh = new Mesh();
        bmf.mesh = bmesh;

        // Set circle colour (and make it a bit transparent)
        bmr.material.color = new Color(0f, 0f, 0f, 1f);

        // Initialise array for vertices and triangles (one extra
        // vertex is taken for the centre of the circle)
        bvertices = new Vector3[bnumPoints + 1];
        btriangles = new int[bnumPoints * 3];
    }

    void Update()
    {

        // Compute the angle between two triangles in the cricle
        float delta = 2f * Mathf.PI / (float)(bnumPoints - 1);
        // Stat with angle of 0
        float alpha = 0f;

        // The center vertex (index 0) is at location (0,0)
        bvertices[0].x = 0;
        bvertices[0].y = 0;
        bvertices[0].z = transform.position.z;

        //Other vertices will be positioned evenly around the circle
        for (int i = 1; i <= bnumPoints; i++)
        {
            //Radius and alpha give a position of a point around
            //the circle in spherical coordinates 

            // Compute position x from spherical coordinates
            float x = bradius * Mathf.Cos(alpha);
            // Compute position y from spherical coordinates
            float y = bradius * Mathf.Sin(alpha);

            // Set the vertex values
            bvertices[i].x = x;
            bvertices[i].y = y;
            bvertices[i].z = transform.position.z;

            //Specify the triangle going from 0 vertex (centre) to
            //the i vertex and the previous vertex on the circle
            btriangles[(i - 1) * 3] = 0;
            if (i == 1)
            {
                // If current vertex is 1, then previous vertex is the
                // last vertex (to close the cricle)
                btriangles[(i - 1) * 3 + 1] = bnumPoints;
            }
            else
            {
                btriangles[(i - 1) * 3 + 1] = i - 1;
            }
            btriangles[(i - 1) * 3 + 2] = i;

            // Increase the angle to get the next positon around the circle
            alpha += delta;
        }
        // Set the new vertices and triangles in the mesh
        bmesh.vertices = bvertices;
        bmesh.triangles = btriangles;
    }
}