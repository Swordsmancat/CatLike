using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AATest : FindObjecTest
{
    public Button click;
    public Button bbb;

    public override  void Awake()
    {
        base.Awake();
        click.onClick.AddListener(() => { Debug.Log("aa"); });
        bbb.onClick.AddListener(() => { Debug.Log("bb"); });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
