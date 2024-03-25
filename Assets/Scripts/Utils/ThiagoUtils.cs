using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
using UnityEditor;

public static class ThiagoUtils
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Ebac/Test")]
    public static void Test()
    {
        Debug.Log("test");
    }

    [UnityEditor.MenuItem("Ebac/Create Spheres %g")]
    public static void Test2()
    {
        for (int x = 0; x != 5; x++)
        {
            GameObject go = (GameObject.CreatePrimitive(PrimitiveType.Sphere));
            go.transform.position = new Vector3(x, 0, 0);
        }
        Debug.Log("test2");
    }
#endif

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
    public static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static void Scale(this GameObject t, float size = 1.2f)
    {
        t.transform.localScale = Vector3.one * size;
    }

    public static void ScaleVector(this Vector3 t, float size = 1.2f)
    {
        //t.localScale = Vector3.one * size;
    }
}
