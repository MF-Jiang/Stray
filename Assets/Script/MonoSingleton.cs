using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// mono����ģʽ
/// </summary>
/// <typeparam name="T">����</typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.LogError(message: "������δ�ҵ�������ö�������Ϊ��" + typeof(T).Name);
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}