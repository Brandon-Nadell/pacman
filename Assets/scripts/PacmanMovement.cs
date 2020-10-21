using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanMovement : MonoBehaviour
{

    public Node nextNode;
    public Node currentNode;
    public int vertInput;
    public int horizInput; 
    public float speed;
    public LastDirection lastDirection;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    public int score;
    public Text scoreText;
    public int pelletsCollected;
    public int totalPelletsCollected;
    public int level;
    public GameObject maze;
    public Color mazeColor;
    // float[] speeds = { .25f, .281f, .281f, .281f, .3125f };

    public int ghostPoints;

    public bool dead;
    public int lives;
    public GameObject lifeIcon;
    public Text readyText;
    bool extraLife;
    List<Fruit> fruits;

    public AudioSource chomp;
    public AudioSource siren;
    public AudioSource death;
    public AudioSource eatFruit;
    public AudioSource eatGhost;
    public AudioSource largePellet;
    


    public enum LastDirection {
        Horizontal,
        Vertical,
        None
    }

    // Start is called before the first frame update
    void Start()
    {


        scoreText.text = "0";
        ghostPoints = 200;

        for (int i = 0; i < lives; i++) {
            Instantiate(lifeIcon, new Vector3(24 + 20*i, 8, 0), Quaternion.identity);
        }

        GetComponent<Animator>().enabled = false;
        dead = true;

        GetComponent<GameLoad>().CreateNodes();
        PrepareLevel();
        currentNode = GetComponent<GameLoad>().start;
        nextNode = null;
        transform.position = new Vector2(currentNode.transform.position.x, currentNode.transform.position.y);
        lastDirection = LastDirection.None;

        Invoke("Ready", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        horizInput = Input.GetKey("right") || Input.GetKey("k") ? 1 : Input.GetKey("left") || Input.GetKey("j")? -1 : horizInput;
        vertInput = Input.GetKey("up") || Input.GetKey("i") ? 1 : Input.GetKey("down") || Input.GetKey("m") ? -1 : vertInput;

        if (dead) {
            horizInput = vertInput = 0;
        } else {
            if (!siren.isPlaying) {
                siren.Play();
            }
            if (nextNode == null) {
                if (lastDirection != LastDirection.Horizontal) {
                    if (vertInput > 0) {
                        nextNode = currentNode.up;
                    } else if (vertInput < 0) {
                        nextNode = currentNode.down;
                    }
                    if (horizInput > 0) {
                        nextNode = currentNode.right == null ? nextNode : currentNode.right;
                    } else if (horizInput < 0) {
                        nextNode = currentNode.left == null ? nextNode : currentNode.left;
                    }
                    if (nextNode == null) {
                        horizInput = vertInput = 0;
                    }
                } else if (lastDirection != LastDirection.Vertical) {
                    if (horizInput > 0) {
                        nextNode = currentNode.right;
                    } else if (horizInput < 0) {
                        nextNode = currentNode.left;
                    } 
                    if (vertInput > 0) {
                        nextNode = currentNode.up == null ? nextNode : currentNode.up;
                    } else if (vertInput < 0) {
                        nextNode = currentNode.down == null ? nextNode : currentNode.down;
                    }
                    if (nextNode == null) {
                        horizInput = vertInput = 0;
                    }
                }
            }

            if (nextNode != null) {
                if (nextNode == currentNode.left || nextNode == currentNode.right) {
                    vertInput = 0;
                    lastDirection = LastDirection.Horizontal;
                }
                if (nextNode == currentNode.up || nextNode == currentNode.down) {
                    horizInput = 0;
                    lastDirection = LastDirection.Vertical;
                }
                GetComponent<Animator>().SetFloat("DirX", horizInput);
                GetComponent<Animator>().SetFloat("DirY", vertInput);

                transform.position = new Vector2(transform.position.x + horizInput * speed, transform.position.y + vertInput * speed);

                if (nextNode.transform.position.x == transform.position.x && nextNode.transform.position.y == transform.position.y) {
                // if (nextNode == currentNode || 
                //     nextNode == currentNode.right && nextNode.Past(nextNode.transform.position.x, currentNode.transform.position.x, transform.position.x) || 
                //     nextNode == currentNode.left && nextNode.Past(currentNode.transform.position.x, nextNode.transform.position.x, transform.position.x)  || 
                //     nextNode == currentNode.up && transform.position.y >= nextNode.transform.position.y || 
                //     nextNode == currentNode.down && nextNode.transform.position.y >= transform.position.y) {

                    // transform.position = nextNode.transform.position;
                    currentNode = nextNode;
                    nextNode = null;
                } else if (currentNode.transform.position.x == transform.position.x && currentNode.transform.position.y == transform.position.y) {
                    nextNode = null;
                }
            }


            Vector2 newPos = transform.position;
            if (transform.position.y > screenTop) {
                newPos.y = screenBottom;
            }
            if (transform.position.y < screenBottom) {
                newPos.y = screenTop;
            }
            if (transform.position.x > screenRight) {
                newPos.x = screenLeft;
            }
            if (transform.position.x < screenLeft) {
                newPos.x = screenRight;
            }
            transform.position = newPos;

        }

    }

    void OnTriggerEnter2D(Collider2D co) {
        if (!dead) {
            if (co.CompareTag("pellet")) {
                Destroy(co.gameObject);
                ScorePoints(10);
                IncrementPellets();
            } else if (co.CompareTag("largePellet")) {
                Destroy(co.gameObject);
                ScorePoints(50);
                IncrementPellets();
                GetComponent<GameLoad>().FrightenGhosts();
            } else if (co.CompareTag("fruit")) {
                Destroy(co.gameObject);
                eatFruit.Play();
                ScorePoints(co.gameObject.GetComponent<Fruit>().points);
            } else if (co.CompareTag("blinky") || co.CompareTag("pinky") || co.CompareTag("inky") || co.CompareTag("clyde")) {
                if (co.gameObject.GetComponent<Animator>().GetFloat("Frightened") != 0) {
                    if (!co.GetComponent<Ghost>().invulnerable) {
                        ScorePoints(ghostPoints);
                        ghostPoints += 200;
                        eatGhost.Play();
                        co.GetComponent<Ghost>().Run();
                    }
                } else {
                    GetComponent<Animator>().SetFloat("DirX", 0);
                    GetComponent<Animator>().SetFloat("DirY", 0);
                    GetComponent<Animator>().enabled = false;
                    dead = true;
                    nextNode = currentNode = null;
                    pelletsCollected = 0;
                    Invoke("DeathAnimation", 1f);
                }
            }
        }
    }

    void DeathAnimation() {
        death.Play();
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetFloat("Death", 1f);
        Invoke("DecrementLife", 3f);
        Invoke("Reset", 3f);
    }

    void DecrementLife() {
        lives--;
        GameObject[] l = GameObject.FindGameObjectsWithTag("lifeIcon");
        Destroy(l[l.Length - 1].gameObject);
    }

    void Reset() {
        GetComponent<Animator>().SetFloat("Death", 0f);
        GetComponent<Animator>().Rebind();
        GetComponent<Animator>().enabled = false;
        currentNode = GetComponent<GameLoad>().start;
        nextNode = null;
        transform.position = new Vector2(currentNode.transform.position.x, currentNode.transform.position.y);
        lastDirection = LastDirection.None;
        GetComponent<GameLoad>().InitializeGhosts(level);
        readyText.enabled = true;
        if (lives > 0) {
            Invoke("Ready", 2f);
        } else {
            readyText.text = "Game Over!";
        }
    }

    void Ready() {
        GetComponent<Animator>().enabled = true;
        dead = false;
        readyText.enabled = false;
    }

    void IncrementPellets() {
        pelletsCollected++;
        if (!chomp.isPlaying)
            chomp.Play();
        totalPelletsCollected++;
        if (totalPelletsCollected == 70 || totalPelletsCollected == 170) {
            GetComponent<GameLoad>().SetCurrentFruit(Mathf.Min(level, 12));
        } else if (totalPelletsCollected == 244) {
            GetComponent<Animator>().enabled = false;
            dead = true;
            level++;
            pelletsCollected = totalPelletsCollected = 0;
            largePellet.Stop();
            Invoke("BlinkMaze", 1f);
            Invoke("PrepareLevel", 3f);
        }
        GetComponent<GameLoad>().TryCreateGhost(pelletsCollected);
    }

    void BlinkMaze() {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() {
        for (int i = 0; i < 8; i++) {
            maze.GetComponent<SpriteRenderer>().color = i % 2 == 0 ? Color.white : mazeColor;
            yield return new WaitForSeconds(.25f);
        }
    }

    void PrepareLevel() {
        // speed = speeds[Mathf.Min(level, speeds.Length - 1)];
        GetComponent<GameLoad>().InitializeGhosts(level);
        GetComponent<GameLoad>().CreatePellets();
        Reset();
    }

    void ScorePoints(int points) {
        score += points;
        scoreText.text = "" + score;
        if (score >= 10000 && !extraLife) {
            Instantiate(lifeIcon, new Vector3(24 + 20*lives, 8, 0), Quaternion.identity);
            lives++;
            extraLife = true;
        }
    }

    static int Sign(float number) {
      return number < 0 ? -1 : (number > 0 ? 1 : 0);
  }
}
