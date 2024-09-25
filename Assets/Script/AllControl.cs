using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;

public class AllControl : MonoBehaviour
{
    public class GameManager
    {
        //����ģʽ
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }

        //�Ʒְ�
        public int score = 0;
    }
}
