using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static MusicController instance;

    void Awake()
    {
        // 如果实例已存在且不是当前实例，则销毁当前实例
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 设置当前实例为唯一实例，并在场景切换时不销毁
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
