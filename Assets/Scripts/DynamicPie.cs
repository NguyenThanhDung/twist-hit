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
        Vector3[] vertices = new Vector3[3];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 1, 0);
        vertices[2] = new Vector3(1, 1, 0);
        return vertices;
    }

    private Vector2[] GetUVs()
    {
        Vector2[] uvs = new Vector2[3];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(0, 1);
        uvs[2] = new Vector2(1, 1);
        return uvs;
    }

    private int[] GetTriangles()
    {
        int[] triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        return triangles;
    }
}
