using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public Node up;
    public Node down;
    public Node left;
    public Node right;
    public bool tunnel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(Node up, Node down, Node left, Node right) {
        this.up = up;
        this.down = down;
        this.left = left;
        this.right = right;
    }

    // public bool Past(float higher, float lower, float entity) {
    //     return !tunnel ? entity <= lower || higher <= entity : higher <= entity && entity <= lower;
    // }
}
