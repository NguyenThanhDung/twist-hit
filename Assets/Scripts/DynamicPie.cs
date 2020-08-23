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

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = this.material;
    }

    private Vector3[] GetVertices()
    {
        Vector3[] vertices = new Vector3[]{
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 1, -1),
            new Vector3(0, 0, -1),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, -1),
            new Vector3(1, 0, -1)};
        return vertices;
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
            1, 2, 3,
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
}
