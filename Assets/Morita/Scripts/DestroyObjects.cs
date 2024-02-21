using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//生成したオブジェクトをdestroyTimeb秒後に削除
public class DestroyObjects : MonoBehaviour
{
    [SerializeField] float destroyTime = 3.0f;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
