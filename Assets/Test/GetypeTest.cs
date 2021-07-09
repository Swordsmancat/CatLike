using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class GetypeTest : MonoBehaviour
{
    public Button aa;
    private int id;
    private Button bb;
    public static int staint;
    private Vector2 gogo;
    private Vector3[] gogogo = new Vector3[2];
    private GameObject qaq;

    // Start is called before the first frame update
    void Start()
    {
        var fileds = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var item in fileds)
        {
            var name = item.Name;
            Transform obj = FindDeep(name, transform);
            if(obj != null)
            {
                if (typeof(GameObject).Equals(item.FieldType))
                {
                    item.SetValue(this, obj.gameObject);
                }
                else
                {
                    item.SetValue(this, obj.GetComponent(item.FieldType));
                }
            }
        }
        if (qaq != null)
        {
            qaq.AddComponent<Collider2D>();
            Debug.Log("not null");
        }
    }

    private Transform FindDeep(string name ,Transform parent)
    {
        if (parent.name.Equals(name))
            return parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            var child = FindDeep(name, parent.GetChild(i));
            if (child) return child;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
