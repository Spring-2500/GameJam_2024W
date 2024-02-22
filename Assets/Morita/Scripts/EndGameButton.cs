using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndGameButton : MonoBehaviour
{
    public void EndGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
          Application.Quit();//ゲームプレイ終了
#endif
    }
}
