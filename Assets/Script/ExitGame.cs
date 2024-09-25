using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    // 退出游戏的方法
    public void QuitGame()
    {
        // 打包后的游戏，使用Application.Quit()
        Application.Quit();
    }
}