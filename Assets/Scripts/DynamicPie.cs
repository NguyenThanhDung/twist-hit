using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPie : MonoBehaviour
{
    [SerializeField] private Material material;

    private void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = meshFilter.mesh;
        mesh.Clear();
        mesh.vertices = GetVertices();
        mesh.uv = GetUVs();
        mesh.triangles = GetTriangles();
        mesh.normals = GetNormals();

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = this.material;
    }

    private Vector3[] GetVertices()
    {
        List<Vector3[]> listOfVertices = new List<Vector3[]>();
        for (float angle = 0f; angle < 60f; angle += 50f)
        {
            Vector3[] slice = GetSliceAtAngle(angle);
            listOfVertices.Add(slice);
        }
        return ListOfVerticesToArray(listOfVertices);
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

    private Vector3[] ListOfVerticesToArray(List<Vector3[]> listOfVertices)
    {
        Vector3[] arrayOfVertices = new Vector3[listOfVertices.Count * 4];
        for (int i = 0; i < listOfVertices.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                arrayOfVertices[i * 4 + j] = listOfVertices[i][j];
            }
        }
        return arrayOfVertices;
    }

    private Vector2[] GetUVs()
    {
        Vector2[] uvs = new Vector2[]{
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(0, 0),
            new Vector2(0, 1)};
        return uvs;
    }

    private int[] GetTriangles()
    {
        int[] triangles = new int[]{
            0, 1, 2,
            0, 2, 3,
            0, 5, 1,
            0, 4, 5,
            2, 1, 5,
            2, 5, 6,
            3, 2, 6,
            3, 6, 7,
            0, 3, 7,
            0, 7, 4,
            7, 6, 5,
            7, 5, 4};
        return triangles;
    }

    private Vector3[] GetNormals()
    {
        Vector3[] normals = new Vector3[]{
            new Vector3(-1, -1, 1),
            new Vector3(-1, 1, 1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, -1, -1),
            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, -1),
            new Vector3(1, -1, -1)};
        return normals;
    }
}
