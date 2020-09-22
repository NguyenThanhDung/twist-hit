using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMesh
{
    private List<Vector3[]> slices;

    public DynamicMesh()
    {
        this.slices = new List<Vector3[]>();
        for (float angle = 0f; angle < 60f; angle += 50f)
        {
            Vector3[] slice = GetSliceAtAngle(angle);
            this.slices.Add(slice);
        }
    }

    private Vector3[] GetSliceAtAngle(float angle)
    {
        Vector3[] verticesOfSlice = new Vector3[]{
            new Vector3(0, 0, -1),
            new Vector3(0, 1, -1),
            new Vector3(0, 1, -2),
            new Vector3(0, 0, -2)
        };
        for (int i = 0; i < 4; i++)
            verticesOfSlice[i] = Quaternion.Euler(0, angle, 0) * verticesOfSlice[i];
        return verticesOfSlice;
    }

    public Vector3[] GetVertices()
    {
        return this.slices[0];
    }

    public Vector2[] GetUVs()
    {
        Vector2[] uvs = new Vector2[]{
            new Vector2(0, 1),
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1)};
        return uvs;
    }

    public int[] GetTriangles()
    {
        int[] triangles = new int[]{
            0, 1, 2,
            0, 2, 3};
        return triangles;
    }

    public Vector3[] GetNormals()
    {
        Vector3[] normals = new Vector3[]{
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(-1, 0, 0)};
        return normals;
    }
}
