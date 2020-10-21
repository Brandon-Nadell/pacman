using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoad : MonoBehaviour
{

    public Node node;
    public Node start;
    public Node ghostStart;
    Node ghostBox;
    public GameObject pellet;
    public GameObject largePellet;
    public Fruit fruit;
    public Fruit currentFruit;

    public Ghost blinky;
    public Ghost pinky;
    public Ghost inky;
    public Ghost clyde;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (blinky.GetComponent<Animator>().GetFloat("Frightened") == 0f &&
            pinky.GetComponent<Animator>().GetFloat("Frightened") == 0f &&
            inky.GetComponent<Animator>().GetFloat("Frightened") == 0f &&
            clyde.GetComponent<Animator>().GetFloat("Frightened") == 0f) {
            blinky.pacman.ghostPoints = 0;
        }
    }

    public void CreateNodes() {
        Node n0 = Instantiate(node, new Vector3(12, 252, 0), Quaternion.identity);
        Node n1 = Instantiate(node, new Vector3(52, 252, 0), Quaternion.identity);
        Node n2 = Instantiate(node, new Vector3(100, 252, 0), Quaternion.identity);
        Node n3 = Instantiate(node, new Vector3(124, 252, 0), Quaternion.identity);
        Node n4 = Instantiate(node, new Vector3(172, 252, 0), Quaternion.identity);
        Node n5 = Instantiate(node, new Vector3(212, 252, 0), Quaternion.identity);

        Node n6 = Instantiate(node, new Vector3(12, 220, 0), Quaternion.identity);
        Node n7 = Instantiate(node, new Vector3(52, 220, 0), Quaternion.identity);
        Node n8 = Instantiate(node, new Vector3(76, 220, 0), Quaternion.identity);
        Node n9 = Instantiate(node, new Vector3(100, 220, 0), Quaternion.identity);
        Node n10 = Instantiate(node, new Vector3(124, 220, 0), Quaternion.identity);
        Node n11 = Instantiate(node, new Vector3(148, 220, 0), Quaternion.identity);
        Node n12 = Instantiate(node, new Vector3(172, 220, 0), Quaternion.identity);
        Node n13 = Instantiate(node, new Vector3(212, 220, 0), Quaternion.identity);

        Node n14 = Instantiate(node, new Vector3(12, 196, 0), Quaternion.identity);
        Node n15 = Instantiate(node, new Vector3(52, 196, 0), Quaternion.identity);
        Node n16 = Instantiate(node, new Vector3(76, 196, 0), Quaternion.identity);
        Node n17 = Instantiate(node, new Vector3(100, 196, 0), Quaternion.identity);
        Node n18 = Instantiate(node, new Vector3(124, 196, 0), Quaternion.identity);
        Node n19 = Instantiate(node, new Vector3(148, 196, 0), Quaternion.identity);
        Node n20 = Instantiate(node, new Vector3(172, 196, 0), Quaternion.identity);
        Node n21 = Instantiate(node, new Vector3(212, 196, 0), Quaternion.identity);

        Node n22 = Instantiate(node, new Vector3(76, 172, 0), Quaternion.identity);
        Node n23 = Instantiate(node, new Vector3(100, 172, 0), Quaternion.identity);
        Node n24 = Instantiate(node, new Vector3(124, 172, 0), Quaternion.identity);
        Node n25 = Instantiate(node, new Vector3(148, 172, 0), Quaternion.identity);

        Node n26 = Instantiate(node, new Vector3(52, 148, 0), Quaternion.identity);
        Node n27 = Instantiate(node, new Vector3(76, 148, 0), Quaternion.identity);
        Node n28 = Instantiate(node, new Vector3(148, 148, 0), Quaternion.identity);
        Node n29 = Instantiate(node, new Vector3(172, 148, 0), Quaternion.identity);
        n26.tunnel = true;
        n29.tunnel = true;

        Node n30 = Instantiate(node, new Vector3(76, 124, 0), Quaternion.identity);
        Node n31 = Instantiate(node, new Vector3(148, 124, 0), Quaternion.identity);

        Node n32 = Instantiate(node, new Vector3(12, 100, 0), Quaternion.identity);
        Node n33 = Instantiate(node, new Vector3(52, 100, 0), Quaternion.identity);
        Node n34 = Instantiate(node, new Vector3(76, 100, 0), Quaternion.identity);
        Node n35 = Instantiate(node, new Vector3(100, 100, 0), Quaternion.identity);
        Node n36 = Instantiate(node, new Vector3(124, 100, 0), Quaternion.identity);
        Node n37 = Instantiate(node, new Vector3(148, 100, 0), Quaternion.identity);
        Node n38 = Instantiate(node, new Vector3(172, 100, 0), Quaternion.identity);
        Node n39 = Instantiate(node, new Vector3(212, 100, 0), Quaternion.identity);

        Node n40 = Instantiate(node, new Vector3(12, 76, 0), Quaternion.identity);
        Node n41 = Instantiate(node, new Vector3(28, 76, 0), Quaternion.identity);
        Node n42 = Instantiate(node, new Vector3(52, 76, 0), Quaternion.identity);
        Node n43 = Instantiate(node, new Vector3(76, 76, 0), Quaternion.identity);
        Node n44 = Instantiate(node, new Vector3(100, 76, 0), Quaternion.identity);
        Node n45 = Instantiate(node, new Vector3(124, 76, 0), Quaternion.identity);
        Node n46 = Instantiate(node, new Vector3(148, 76, 0), Quaternion.identity);
        Node n47 = Instantiate(node, new Vector3(172, 76, 0), Quaternion.identity);
        Node n48 = Instantiate(node, new Vector3(196, 76, 0), Quaternion.identity);
        Node n49 = Instantiate(node, new Vector3(212, 76, 0), Quaternion.identity);

        Node n50 = Instantiate(node, new Vector3(12, 52, 0), Quaternion.identity);
        Node n51 = Instantiate(node, new Vector3(28, 52, 0), Quaternion.identity);
        Node n52 = Instantiate(node, new Vector3(52, 52, 0), Quaternion.identity);
        Node n53 = Instantiate(node, new Vector3(76, 52, 0), Quaternion.identity);
        Node n54 = Instantiate(node, new Vector3(100, 52, 0), Quaternion.identity);
        Node n55 = Instantiate(node, new Vector3(124, 52, 0), Quaternion.identity);
        Node n56 = Instantiate(node, new Vector3(148, 52, 0), Quaternion.identity);
        Node n57 = Instantiate(node, new Vector3(172, 52, 0), Quaternion.identity);
        Node n58 = Instantiate(node, new Vector3(196, 52, 0), Quaternion.identity);
        Node n59 = Instantiate(node, new Vector3(212, 52, 0), Quaternion.identity);

        Node n60 = Instantiate(node, new Vector3(12, 28, 0), Quaternion.identity);
        Node n61 = Instantiate(node, new Vector3(100, 28, 0), Quaternion.identity);
        Node n62 = Instantiate(node, new Vector3(124, 28, 0), Quaternion.identity);
        Node n63 = Instantiate(node, new Vector3(212, 28, 0), Quaternion.identity);
        
        ghostStart = Instantiate(node, new Vector3(112, 172, 0), Quaternion.identity);

        n0.Initialize(null, n6, null, n1);
        n1.Initialize(null, n7, n0, n2);
        n2.Initialize(null, n9, n1, null);
        n3.Initialize(null, n10, null, n4);
        n4.Initialize(null, n12, n3, n5);
        n5.Initialize(null, n13, n4, null);

        n6.Initialize(n0, n14, null, n7);
        n7.Initialize(n1, n15, n6, n8);
        n8.Initialize(null, n16, n7, n9);
        n9.Initialize(n2, null, n8, n10);
        n10.Initialize(n3, null, n9, n11);
        n11.Initialize(null, n19, n10, n12);
        n12.Initialize(n4, n20, n11, n13);
        n13.Initialize(n5, n21, n12, null);

        n14.Initialize(n6, null, null, n15);
        n15.Initialize(n7, n26, n14, null);
        n16.Initialize(n8, null, null, n17);
        n17.Initialize(null, n23, n16, null);
        n18.Initialize(null, n24, null, n19);
        n19.Initialize(n11, null, n18, null);
        n20.Initialize(n12, n29, null, n21);
        n21.Initialize(n13, null, n20, null);

        n22.Initialize(null, n27, null, n23);
        n23.Initialize(n17, null, n22, ghostStart);
        n24.Initialize(n18, null, ghostStart, n25);
        n25.Initialize(null, n28, n24, null);

        n26.Initialize(n15, n33, n29, n27);
        n27.Initialize(n22, n30, n26, null);
        n28.Initialize(n25, n31, null, n29);
        n29.Initialize(n20, n38, n28, n26);

        n30.Initialize(n27, n34, null, n31);
        n31.Initialize(n28, n37, n30, null);

        n32.Initialize(null, n40, null, n33);
        n33.Initialize(n26, n42, n32, n34);
        n34.Initialize(n30, null, n33, n35);
        n35.Initialize(null, n44, n34, null);
        n36.Initialize(null, n45, null, n37);
        n37.Initialize(n31, null, n36, n38);
        n38.Initialize(n29, n47, n37, n39);
        n39.Initialize(null, n49, n38, null);

        n40.Initialize(n32, null, null, n41);
        n41.Initialize(null, n51, n40, null);
        n42.Initialize(n33, n52, null, n43);
        n43.Initialize(null, n53, n42, n44);
        n44.Initialize(n35, null, n43, n45);
        n45.Initialize(n36, null, n44, n46);
        n46.Initialize(null, n56, n45, n47);
        n47.Initialize(n38, n57, n46, null);
        n48.Initialize(null, n58, null, n49);
        n49.Initialize(n39, null, n48, null);

        n50.Initialize(null, n60, null, n51);
        n51.Initialize(n41, null, n50, n52);
        n52.Initialize(n42, null, n51, null);
        n53.Initialize(n43, null, null, n54);
        n54.Initialize(null, n61, n53, null);
        n55.Initialize(null, n62, null, n56);
        n56.Initialize(n46, null, n55, null);
        n57.Initialize(n47, null, null, n58);
        n58.Initialize(n48, null, n57, n59);
        n59.Initialize(null, n63, n58, null);

        n60.Initialize(n50, null, null, n61);
        n61.Initialize(n54, null, n60, n62);
        n62.Initialize(n55, null, n61, n63);
        n63.Initialize(n59, null, n62, null);
        
        start = Instantiate(node, new Vector3(112, 76, 0), Quaternion.identity);
        start.Initialize(null, null, n44, n45);

        ghostStart.Initialize(null, null, n23, n24);

        ghostBox = Instantiate(node, new Vector3(112, 148, 0), Quaternion.identity);
        ghostBox.Initialize(ghostStart, null, null, null);
    }

    public void InitializeGhosts(int level) {
        blinky.Reset(level);
        blinky.currentNode = blinky.nextNode = ghostStart;
        blinky.transform.position = new Vector3(112, 172, -2);
        pinky.Reset(level);
        pinky.transform.position = new Vector3(112, 148, -2);
        inky.Reset(level);
        inky.transform.position = new Vector3(96, 148, -2);
        clyde.Reset(level);
        clyde.transform.position = new Vector3(128, 148, -2);
    }

    public void CreatePellets() {
        //29 x 26
        int[,] pellets = new int[29, 26] {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {2, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0}, 
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1}, 
            {2, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 2}, 
            {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0}, 
            {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0}, 
            {1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1}, 
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, 
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, 
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
        };
        
        for (int r = 0; r < pellets.GetLength(0); r++) {
            for (int c = 0; c < pellets.GetLength(1); c++) {
                if (pellets[pellets.GetLength(0) - 1 - r, c] == 1)
                    Instantiate(pellet, new Vector3(12 + c*8, 28 + r*8, 1), Quaternion.identity);
                else if (pellets[pellets.GetLength(0) - 1 - r, c] == 2)
                    Instantiate(largePellet, new Vector3(12 + c*8, 28 + r*8, 1), Quaternion.identity);
            }
        }
    }

    public void SetCurrentFruit(int index) {
        // Debug.Log("new fruit from gameload.cs:250");
        currentFruit = Instantiate(fruit);
        currentFruit.Initialize(index);
        Invoke("DestroyFruit", 10f);
    }

    void DestroyFruit() {
        Destroy(currentFruit.gameObject);
        currentFruit = null;
    }

    public void TryCreateGhost(int pelletsCollected) {
        if (pelletsCollected == 1) {
            pinky.currentNode = pinky.nextNode = ghostBox;
            pinky.transform.position = ghostBox.transform.position;
            pinky.mode = Ghost.Mode.Scatter;
        } else if (pelletsCollected == 30) {
            inky.currentNode = inky.nextNode = ghostBox;
            inky.transform.position = ghostBox.transform.position;
            inky.mode = Ghost.Mode.Scatter;
        } else if (pelletsCollected == 80) {
            clyde.currentNode = clyde.nextNode = ghostBox;
            clyde.transform.position = ghostBox.transform.position;
            clyde.mode = Ghost.Mode.Scatter;
        }
    }

    public void FrightenGhosts() {
        blinky.BeginFrighten();
        pinky.BeginFrighten();
        inky.BeginFrighten();
        clyde.BeginFrighten();
    }

}
