using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    public Mode mode;
    public float speed;
    public Node currentNode;
    public Node nextNode;
    public PacmanMovement pacman;
    public GameObject blinky;
    public Vector3 scatterTile;
    public int seconds;
    public bool invulnerable;
    public AudioSource scared;

    // float[] speeds = { .125f, .142f, .142f, .142f, .16f };
    Mode[] modes = { Mode.Scatter, Mode.Chase, Mode.Scatter, Mode.Chase, Mode.Scatter, Mode.Chase, Mode.Scatter, Mode.Chase };
    int[,] modeTimers = {
        { 0, 7, 27, 34, 54, 59, 79, 84 },
        { 0, 7, 27, 34, 54, 59, 1092, 1092 },
        { 0, 5, 25, 30, 50, 55, 1092, 1092 },
    };
    int modeIteration = 0;

    public enum Mode {
        Chase,
        Scatter,
        Frightened,
        None
    }

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.None;
        Invoke("Timer", 1f);
        BeginScatter();
    }

    // Update is called once per frame
    void Update() {
    }

    void FixedUpdate()
    {
        if (!pacman.dead) {
            if (mode == Mode.Frightened && !pacman.largePellet.isPlaying) {
                pacman.largePellet.Play();
            }
            if (nextNode != null && (nextNode == currentNode || nextNode.transform.position.x == transform.position.x && nextNode.transform.position.y == transform.position.y)) {
                if (GetComponent<Animator>().GetBool("Scared")) {
                    if (nextNode == pacman.GetComponent<GameLoad>().ghostStart)
                        EndFrightened();
                    if (!scared.isPlaying) {
                        scared.Play();
                    }
                }
                List<Node> nodes = new List<Node>();
                if (nextNode.up != null && nextNode.up != currentNode) nodes.Add(nextNode.up);
                if (nextNode.down != null && nextNode.down != currentNode) nodes.Add(nextNode.down);
                if (nextNode.right != null && nextNode.right != currentNode) nodes.Add(nextNode.right);
                if (nextNode.left != null && nextNode.left != currentNode) nodes.Add(nextNode.left);

                if (mode == Mode.Frightened && !GetComponent<Animator>().GetBool("Scared")) {
                    currentNode = nextNode;
                    nextNode = nodes[Random.Range(0, nodes.Count - 1)];
                } else if (mode != Mode.None) {
                    Vector3 target = NextTarget();

                    Node shortestDistanceNode = nodes[0];
                    float shortestDistance = Vector3.Distance(shortestDistanceNode.transform.position, target);
                    for (int i = 1; i < nodes.Count; i++) {
                        float dist = Vector3.Distance(nodes[i].transform.position, target);
                        if (dist < shortestDistance) {
                            shortestDistance = dist;
                            shortestDistanceNode = nodes[i];
                        }
                    }

                    currentNode = nextNode;
                    nextNode = shortestDistanceNode;
                }
            }
            if (currentNode != null) {
                if (nextNode == currentNode.right) {
                    transform.position = new Vector2(transform.position.x + speed, transform.position.y);
                    if (GetComponent<Animator>().GetFloat("Frightened") == 0) {
                        GetComponent<Animator>().SetFloat("DirX", 1);
                        GetComponent<Animator>().SetFloat("DirY", 0);
                    }
                } else if (nextNode == currentNode.left) {
                    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
                    if (GetComponent<Animator>().GetFloat("Frightened") == 0) {
                        GetComponent<Animator>().SetFloat("DirX", -1);
                        GetComponent<Animator>().SetFloat("DirY", 0);
                    }
                } else if (nextNode == currentNode.up) {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed);
                    if (GetComponent<Animator>().GetFloat("Frightened") == 0) {
                        GetComponent<Animator>().SetFloat("DirX", 0);
                        GetComponent<Animator>().SetFloat("DirY", 1);
                    }
                } else if (nextNode == currentNode.down) {
                    transform.position = new Vector2(transform.position.x, transform.position.y - speed);
                    if (GetComponent<Animator>().GetFloat("Frightened") == 0) {
                        GetComponent<Animator>().SetFloat("DirX", 0);
                        GetComponent<Animator>().SetFloat("DirY", -1);
                    }
                }
            }
            
            Vector2 newPos = transform.position;
            if (transform.position.y > pacman.screenTop) {
                newPos.y = pacman.screenBottom;
            }
            if (transform.position.y < pacman.screenBottom) {
                newPos.y = pacman.screenTop;
            }
            if (transform.position.x > pacman.screenRight) {
                newPos.x = pacman.screenLeft;
            }
            if (transform.position.x < pacman.screenLeft) {
                newPos.x = pacman.screenRight;
            }
            transform.position = newPos;
        } else {
            GetComponent<Animator>().enabled = false;
        }
    }

    Vector3 NextTarget() {
        if (mode == Mode.Chase) {
            if (gameObject.CompareTag("blinky"))
                return pacman.transform.position;
            else if (gameObject.CompareTag("pinky")) {
                return new Vector3(pacman.transform.position.x + 32*pacman.GetComponent<Animator>().GetFloat("DirX"),
                                    pacman.transform.position.y + 32*pacman.GetComponent<Animator>().GetFloat("DirY"), 0);
            } else if (gameObject.CompareTag("inky")) {
                return (new Vector3(pacman.transform.position.x + 16*pacman.GetComponent<Animator>().GetFloat("DirX"),
                                    pacman.transform.position.y + 16*pacman.GetComponent<Animator>().GetFloat("DirY"), 0)
                        - blinky.transform.position) * 2;
            } else if (gameObject.CompareTag("clyde")) {
                return Vector3.Distance(pacman.transform.position, transform.position) > 64 ? pacman.transform.position : scatterTile;
            } else {
                throw new System.Exception("Ghost does not match a name");
            }
        } else if (mode == Mode.Scatter) {
            return scatterTile;
        } else {
            return pacman.GetComponent<GameLoad>().ghostStart.transform.position;
        }
    }

    void SwitchDirections() {
        if ((mode == Mode.Chase || mode == Mode.Scatter) && nextNode != pacman.GetComponent<GameLoad>().ghostStart) {
            Node temp = currentNode;
            currentNode = nextNode;
            nextNode = temp;
        }
    }

    void BeginChase() {
        SwitchDirections();
        mode = Mode.Chase;
    }

    void BeginScatter() {
        SwitchDirections();
        mode = Mode.Scatter;
    }

    public void BeginFrighten() {
        SwitchDirections();
        mode = Mode.Frightened;
        GetComponent<Animator>().SetFloat("Frightened", 1f);
        GetComponent<Animator>().SetFloat("DirX", 0);
        GetComponent<Animator>().SetFloat("DirY", 0);
        CancelInvoke();
        Invoke("BlinkFrightened", 4f);
    }

    void BlinkFrightened() {
        GetComponent<Animator>().SetFloat("Frightened", -1f);
        Invoke("EndFrightened", 2f);
        Invoke("StopSound", 2f);
    }

    void StopSound() {
        pacman.largePellet.Stop();
    }

    void EndFrightened() {
        GetComponent<Animator>().SetBool("Scared", false);
        GetComponent<Animator>().SetFloat("Frightened", 0f);
        GetComponent<Animator>().SetFloat("DirX", 1);
        mode = modes[modeIteration];
        invulnerable = false;
        CancelInvoke();
        Invoke("Timer", 1f);
    }

    public void Run() {
        GetComponent<Animator>().SetBool("Scared", true);
        invulnerable = true;
    }

    public void Reset(int level) {
        nextNode = currentNode = null;
        GetComponent<Animator>().SetFloat("DirX", 0);
        GetComponent<Animator>().SetFloat("DirY", 0);
        GetComponent<Animator>().Rebind();
        CancelInvoke();
        Invoke("Ready", 2f);
        seconds = 0;
        modeIteration = 0;
        mode = modes[modeIteration];
        // speed = speeds[Mathf.Min(level, speeds.Length - 1)];
    }

    void Ready() {
        GetComponent<Animator>().enabled = true;
        Invoke("Timer", 1f);
    }

    void Timer() {
        seconds++;
        if (modeIteration <= 6) {
            int index = pacman.level == 0 ? 0 : pacman.level <= 3 ? 1 : 2;
            if (seconds == modeTimers[index, modeIteration + 1]) {
                if (modes[modeIteration + 1] == Mode.Chase) {
                    BeginChase();
                    modeIteration++;
                } else {
                    BeginScatter();
                    modeIteration++;
                }
            }
        }
        Invoke("Timer", 1f);
    }
}