using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargePellet : MonoBehaviour
{

    public Color normal;
    public Color invisible;

    // Start is called before the first frame update
    void Start()
    {
        Normal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Normal() {
        GetComponent<SpriteRenderer>().color = normal;
        Invoke("Invisible", .4f);
    }

    void Invisible() {
        GetComponent<SpriteRenderer>().color = invisible;
        Invoke("Normal", .4f);
    }
}
