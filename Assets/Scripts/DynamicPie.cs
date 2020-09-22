using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPie : MonoBehaviour
{
    [SerializeField] private Material material = null;

    private void Start()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = meshFilter.mesh;
        mesh.Clear();

        DynamicMesh dynamicMesh = new DynamicMesh();
        mesh.vertices = dynamicMesh.GetVertices();
        mesh.uv = dynamicMesh.GetUVs();
        mesh.triangles = dynamicMesh.GetTriangles();
        mesh.normals = dynamicMesh.GetNormals();

        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = this.material;
    }
}
