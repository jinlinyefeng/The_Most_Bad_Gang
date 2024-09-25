using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;

public class AllControl : MonoBehaviour
{
    public class GameManager
    {
        //单例模式
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

        //计分板
        public int score = 0;
    }
}
