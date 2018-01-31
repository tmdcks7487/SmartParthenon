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

    [ContextMenu("Build")]
    void Build()
    {
        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localPosition = new Vector3(0, 0, 0);
        floor1.transform.localScale = new Vector3(FloorWidth, FloorHeight, FloorDepth);

        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localPosition = new Vector3(0, FloorHeight, 0);
        floor2.transform.localScale = new Vector3(FloorWidth * 0.95f, FloorHeight, FloorDepth * 0.95f);

        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localPosition = new Vector3(0, FloorHeight * 2, 0);
        floor3.transform.localScale = new Vector3(FloorWidth * 0.9025f, FloorHeight, FloorDepth * 0.9025f);

       

    }


}
