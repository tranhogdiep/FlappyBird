using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCreator : MonoBehaviour
{
    [SerializeField]
    Line topLineItems;
    [SerializeField]
    Line bottomLineItems;
    public GameObject Lines;
    Vector3 instanPosBottom = new Vector3(1000,-1000,0);
    Vector3 instanPosTop = new Vector3(1000,1000,0);
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Screen.height:"+Screen.height);
        for(int i =0;i<50;i++)
        {
            float middleHeight = Random.Range(300, 400);
            CreateLine(middleHeight, i);
        }
    }
    void CreateLine(float middleHeight, int index)
    {
        float lineTopHeight = Random.Range(200,Screen.height - middleHeight);
        CreateLineTop(lineTopHeight, index);
        CreateLineBottom(Screen.height - middleHeight- lineTopHeight, index);
    }
    void CreateLineBottom(float height, int index)
    {
        Line line = Instantiate(bottomLineItems, Lines.transform) as Line;
        Debug.Log(line.transform.position);
        line.SetupLine(150, height, line.transform.position.x+(index * GameManager.Instance.GetLineSpace()));
    }
    void CreateLineTop(float height, int index)
    {
        Line line = Instantiate(topLineItems, Lines.transform) as Line;
        Debug.Log(line.transform.position);
        line.SetupLine(150, height, line.transform.position.x + (index * GameManager.Instance.GetLineSpace()));
    }
}
