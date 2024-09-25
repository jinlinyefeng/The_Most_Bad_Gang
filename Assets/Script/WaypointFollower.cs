using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;//�ƶ��㣬��������ƶ���Χ
    private int currentWaypointIndex = 0; //�ƶ�������
    [SerializeField] private float speed = 2f; //ƽ̨�ƶ��ٶ�

    // Update is called once per frame
    void Update()
    {
        //�ж����ƶ���ľ���С��0.1�ͱ�ʾ�Ѿ������ƶ���
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            { 
                currentWaypointIndex = 0;
            }
        }
        //�������嵱ǰλ�ø�ֵһ���ƶ�����ͨ����ǰλ�ã���ʼλ�ã�Ŀ���λ�ã�ʱ������*�ƶ��ٶȣ����仯���ﵽ�ƶ�Ŀ��
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
