using System.Collections;
using System.Collections.Generic;
using NRKernal;
using NRKernal.NRExamples;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GemBehaviour Gem;
    public GameObject GemPrefab;
    public ReticleBehaviour Reticle;

    public static Vector3 RandomInTriangle(Vector3 v1, Vector3 v2)
    {
        float u = Random.Range(0.0f, 1.0f);
        float v = Random.Range(0.0f, 1.0f);
        if (v + u > 1)
        {
            v = 1 - v;
            u = 1 - u;
        }

        return (v1 * u) + (v2 * v);
    }

    public Vector3 FindRandomLocation(GameObject plane)
    {
        // 获取平面的网格信息
        var mesh = plane.GetComponent<PolygonPlaneVisualizer>().m_PlaneMesh;
        // 获取平面的三角形索引
        var triangles = mesh.triangles;
        var triangle = triangles[(int) Random.Range(0, triangles.Length - 1)] / 3 * 3;
        // 获取平面的顶点信息
        var vertices = mesh.vertices;
        // 在选定的三角形内生成一个随机点
        var randomInTriangle = RandomInTriangle(vertices[triangle], vertices[triangle + 1]);
        // 将局部坐标系中的随机点转换到世界坐标系
        var randomPoint = plane.transform.TransformPoint(randomInTriangle);
        // 修正随机点的高度值
        randomPoint.y = Reticle.CurrentPlane.GetComponent<NRTrackableBehaviour>().Trackable.GetCenterPose().position.y;
        // 返回新的随机位置
        return randomPoint;
    }


    public void SpawnGem(GameObject plane)
    {
        var gemClone = Instantiate(GemPrefab);
        gemClone.transform.position = FindRandomLocation(plane);

        Gem = gemClone.GetComponent<GemBehaviour>();
    }

    private void Update()
    {
        if (Reticle.CurrentPlane != null)
        {
            if (Gem == null)
            {
                SpawnGem(Reticle.CurrentPlane);
            }
        }
    }
}