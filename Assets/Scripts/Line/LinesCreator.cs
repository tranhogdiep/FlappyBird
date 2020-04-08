using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCreator : MonoSingleton<LinesCreator>
{
    [SerializeField]
    Line topLineItems;
    [SerializeField]
    Line bottomLineItems;

    float line_space = 1.5f;
    float current_time = 1;
    float instanPosX = 7f;
    private void Start()
    {
        //Debug.Log("Screen.height:"+Screen.height);
        //for(int i =0;i<10;i++)
        //{
        //    float middleHeight = Random.Range(300, 400);
        //    CreateLine(middleHeight);
        //}
        current_time = line_space;
    }
    private void Update()
    {
        if (GameManager.Instance.Current_state == GameManager.GAMESTATE.PLAYING)
        {
            current_time -= Time.deltaTime;
            if (current_time <= 0)
            {
                float middleHeight = Random.Range(400 - GameManager.Instance.GetLevel() * 10, 500 - GameManager.Instance.GetLevel() * 10);
                CreateLine(middleHeight);
                current_time = line_space;
            }
        }
    }
    void CreateLine(float middleHeight)
    {
        float lineTopHeight = Random.Range(200,Screen.height - middleHeight);
        CreateLineTop(lineTopHeight);
        CreateLineBottom(Screen.height - middleHeight- lineTopHeight);
    }
    void CreateLineBottom(float height)
    {
        Line line = Instantiate(bottomLineItems, gameObject.transform) as Line;
        //Debug.Log(line.transform.position);
        line.SetupLine(150, height, instanPosX, true);
    }
    void CreateLineTop(float height)
    {
        Line line = Instantiate(topLineItems, gameObject.transform) as Line;
        //Debug.Log(line.transform.position);
        line.SetupLine(150, height, instanPosX);
    }
    public void DestroyAllLine()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
