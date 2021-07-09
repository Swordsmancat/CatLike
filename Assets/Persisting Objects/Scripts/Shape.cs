using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : PersistableObject
{
    private int shapeId =int.MinValue;
    public int ShapeId
    {
        get
        {
            return shapeId;
        }
        set
        {
            if (shapeId == int.MinValue &&value !=int.MinValue)
            {
                shapeId = value;
            }
            else
            {
                Debug.LogError("Not allowed to change shapeId.");
            }
            shapeId = value;
        }
    }


    public int MaterialId { get; private set; }

    public void SetMaterial (Material material,int materialId)
    {
        // GetComponent<MeshRenderer>().material = material;
        meshRenderer.material = material;
        MaterialId = materialId;
    }

    private Color color;

    private MeshRenderer meshRenderer;

    public static int colorPropertyId = Shader.PropertyToID("_Color");

    public static MaterialPropertyBlock sharedPropertyBlock;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    public void SetColor(Color color)
    {
        this.color = color;
        // GetComponent<MeshRenderer>().material.color = color;
        if(sharedPropertyBlock == null)
        {
            sharedPropertyBlock = new MaterialPropertyBlock();
        }
        sharedPropertyBlock.SetColor(colorPropertyId, color);
        meshRenderer.SetPropertyBlock(sharedPropertyBlock);
    }

    public override void Save(GameDataWriter writer)
    {
        base.Save(writer);
        writer.Write(color);
    }

    public override void Load(GameDataReader reader)
    {
        base.Load(reader);
        SetColor(reader.Version>0?reader.ReadColor():Color.white);
    }
}
