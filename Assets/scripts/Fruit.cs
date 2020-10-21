using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    public int points;

    public Sprite cherry;
    public Sprite strawberry;
    public Sprite orange;
    public Sprite apple;
    public Sprite melon;
    public Sprite galaxia;
    public Sprite bell;
    public Sprite key;
    public Sprite[] textures;
    public int[] pointValues;
    // public static List<Fruit> fruits;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        textures = new Sprite[] { cherry, strawberry, orange, orange, apple, apple, melon, melon, galaxia, galaxia, bell, bell, key };
        pointValues = new int[] { 100, 300, 500, 500, 700, 700, 1000, 1000, 2000, 2000, 3000, 3000, 5000};
    }

    public void Initialize(int index) {
        GetComponent<SpriteRenderer>().sprite = textures[index];
        points = pointValues[index];
        transform.position = new Vector2(112, 124);
    }
}
