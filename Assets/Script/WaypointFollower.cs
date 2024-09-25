using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;//移动点，用来标记移动范围
    private int currentWaypointIndex = 0; //移动点索引
    [SerializeField] private float speed = 2f; //平台移动速度

    // Update is called once per frame
    void Update()
    {
        //判断与移动点的距离小于0.1就表示已经到达移动点
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            { 
                currentWaypointIndex = 0;
            }
        }
        //给予物体当前位置赋值一个移动朝向，通过当前位置（起始位置，目标点位置，时间增量*移动速度）来变化，达到移动目的
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
