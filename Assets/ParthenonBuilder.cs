using System;
using System.Linq;
using UnityEngine;

public class ParthenonBuilder : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject cylinderPrefab;
    public float FloorWidth = 5.0f;
    public float FloorDepth = 10.0f;
    public float FloorHeight = 0.25f;
    public float PillarRadius = 0.2f;
    public float PillarHeight = 2.0f;
    public float PillarCountWidth = 6.0f;
    public float PillarCountDepth = 10.0f;
    public float RoofHeight = 1.0f;
    public Material FloorMaterial;
    public Material PillarMaterial;
    public Material RoofMaterial;
    private float topFloorWidth;
    private float topFloorDepth;
    private Material pillarMaterial;

    [ContextMenu("Build")]
    void Build()
    {
        DestroyAllChildren();
        BuildFloors();
        BuildPillars();
        BuildRoof();
        //var floor1 = Instantiate(cubePrefab, transform);
        //floor1.transform.localPosition = new Vector3(0, 0, 0);
        //floor1.transform.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);

        //var floor2 = Instantiate(cubePrefab, transform);
        //floor2.transform.localPosition = new Vector3(0, FloorHeight, 0);
        //floor2.transform.localScale = new Vector3(FloorWidth * 0.95f, FloorHeight, FloorDepth * 0.95f);

        //var floor3 = Instantiate(cubePrefab, transform);
        //floor3.transform.localPosition = new Vector3(0, FloorHeight * 2, 0);
        //floor3.transform.localScale = new Vector3(FloorWidth * 0.9025f, FloorHeight, FloorDepth * 0.9025f);
    }

    private void BuildRoof()
    {
        var roof = Instantiate(cubePrefab, transform);
        roof.transform.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);
        roof.transform.localPosition = new Vector3(0, FloorHeight * 3 + PillarHeight, 0);
        roof.GetComponentInChildren<MeshRenderer>().material = RoofMaterial;
    }

    private void BuildPillars()
    {
        xpillar();
        zpillar();

    }

    private void xpillar()
    {
        //var pillar = Instantiate(cylinderPrefab, transform);
        var pillarX0 = -topFloorWidth / 2 + PillarRadius;
        var pillarZ0 = -topFloorDepth / 2 + PillarRadius;
        var distanceX = (-pillarX0 * 2) / (PillarCountWidth - 1);
        for (int i = 0; i < PillarCountWidth; i++)
        {
            var pillar1 = Instantiate(cylinderPrefab, transform);
            pillar1.transform.localPosition = new Vector3(pillarX0 + i * distanceX, FloorHeight * 3, pillarZ0);
            pillar1.transform.localScale = new Vector3(PillarRadius / 0.5f, PillarHeight, PillarRadius / 0.5f);
            pillar1.GetComponentInChildren<MeshRenderer>().material = PillarMaterial;

            var pillar2 = Instantiate(cylinderPrefab, transform);
            pillar2.transform.localPosition = new Vector3(pillarX0 + i * distanceX, FloorHeight * 3, -pillarZ0);
            pillar2.transform.localScale = new Vector3(PillarRadius / 0.5f, PillarHeight, PillarRadius / 0.5f);
            pillar2.GetComponentInChildren<MeshRenderer>().material = PillarMaterial;
        }
    }

    private void zpillar()
    {
        //var pillar = Instantiate(cylinderPrefab, transform);
        var pillarX0 = -topFloorWidth / 2 + PillarRadius;
        var pillarZ0 = -topFloorDepth / 2 + PillarRadius;
        var distanceZ = (-pillarZ0 * 2) / (PillarCountDepth - 1);
        for (int i = 1; i < PillarCountDepth; i++)
        {
            var pillar1 = Instantiate(cylinderPrefab, transform);
            pillar1.transform.localPosition = new Vector3(pillarX0 , FloorHeight * 3, pillarZ0 + i * distanceZ);
            pillar1.transform.localScale = new Vector3(PillarRadius / 0.5f, PillarHeight, PillarRadius / 0.5f);
            pillar1.GetComponentInChildren<MeshRenderer>().material = PillarMaterial;

            var pillar2 = Instantiate(cylinderPrefab, transform);
            pillar2.transform.localPosition = new Vector3(-pillarX0 , FloorHeight * 3, pillarZ0 + i * distanceZ);
            pillar2.transform.localScale = new Vector3(PillarRadius / 0.5f, PillarHeight, PillarRadius / 0.5f);
            pillar2.GetComponentInChildren<MeshRenderer>().material = PillarMaterial;
        }
    }

    private void BuildFloors()
    {
        var sizeDecrement = FloorWidth * 0.1f;

        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);
        floor1.GetComponentInChildren<MeshRenderer>().material = FloorMaterial;

        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localScale = new Vector3(FloorWidth- sizeDecrement, FloorHeight, FloorDepth- sizeDecrement);
        floor2.transform.localPosition = new Vector3(0, FloorHeight, 0);
        floor2.GetComponentInChildren<MeshRenderer>().material = FloorMaterial;

        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localScale = new Vector3(FloorWidth - sizeDecrement*2, FloorHeight, FloorDepth - sizeDecrement*2);
        floor3.transform.localPosition = new Vector3(0, FloorHeight*2, 0);
        floor3.GetComponentInChildren<MeshRenderer>().material = FloorMaterial;

        topFloorWidth = FloorWidth - sizeDecrement * 2;
        topFloorDepth = FloorDepth - sizeDecrement * 2;
    }

    [ContextMenu("Destroy All")]
    void DestroyAllChildren()
    {   //새로운 array생성??
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }
        // foreach(Transform t in ~) - in뒤에 있는 배열에 있는 항목을 꺼내서 t에 넣고 실행
        //cube A(g.o) - go1,go2,go3(자식들)
        //모든 g.o는 transform(component)이 있다. 생성되면 transform이 array로 생성된다. (a.transform, go1.transform~)
        //삭제할때 for i =0 ; i<transform.childCount;i++ 이렇게 하면 띄엄띄엄 삭제하는 경우가 있기 떄문에
    }


}
