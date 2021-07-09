using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class FindObjecTest : MonoBehaviour
{

    public virtual void Awake()
    {
        var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        foreach (var field in fields)
        {
            var name = field.Name;
            Transform obj = FindDeep(transform, name);

            if(obj != null)
            {
                if (typeof(GameObject).Equals(field.FieldType))
                {
                    field.SetValue(this, obj.gameObject);
                }
                else
                {
                    field.SetValue(this, obj.GetComponent(field.FieldType));
                }
            }
        }
    }

    private Transform FindDeep(Transform t, string childName)
    {
        if (t.name.Equals(childName))
            return t;
        for (int i = 0; i < t.childCount; i++)
        {
            var child = FindDeep(t.GetChild(i), childName);
            if (child) return child;
        }
        return null;
    }
}
