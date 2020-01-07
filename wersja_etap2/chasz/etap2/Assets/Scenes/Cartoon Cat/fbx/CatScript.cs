using System.Collections;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animCat;
    float speed = 1.0f;
    bool canMove = true;

    //public GameObject objectToDestroy;
    public GameObject[] objectsToDestroy;
    public GameObject[] statusBars;

    public int howMuchToDestroy = 0;
    public int allObjects = 0;
    public int howMuchDestroyed = 0;

    public GameObject niewolnik;
    public GameObject kitku;
    public GameObject gameobject;
    public GameObject ui_wait;
    public GameObject sound;

    private static int _things_all = 1;
    private static int _things_destroyed = 0;
    private static int _level = 1;


    public static int Things_all
    {
        get { return _things_all; }
    }

    public static int Things_destroyed
    {
        get { return _things_destroyed; }
    }

    public static int Level
    {
        get { return _level; }
    }

    


    void Start()
    {
        animCat = GetComponent<Animator>();
        objectsToDestroy = GameObject.FindGameObjectsWithTag("StatusBar");
        allObjects = objectsToDestroy.Length;
        _things_all = allObjects;
        Debug.Log("GAME start");
    }

    public GameObject FindClosestToDestroy() //finds objects that can be destroyed by the cat
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("StatusBar");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                if (curDistance < 1.5)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }

        return closest;
    }

    private IEnumerator Wait()
    {
        canMove = false;
        yield return new WaitForSeconds(6);
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //walk animation cat
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            animCat.SetBool("WalkCat", true);
            animCat.SetBool("stopCat", false);
        }

        //stop animation cat
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            animCat.SetBool("WalkCat", false);
            animCat.SetBool("stopCat", true);
        }


        if (Input.GetKeyDown(KeyCode.Space)) //destroying stuff
        {
            animCat.SetBool("jumpCat", true);
            animCat.SetBool("stopJump", false);
            GameObject willBeDestroyed = FindClosestToDestroy();
            Material matDestroyed = Resources.Load("Materials/StateBarDestroyed", typeof(Material)) as Material;
            if (willBeDestroyed != null)
            {
                if (willBeDestroyed.tag == "StatusBar")
                {
                    willBeDestroyed.tag = "StatusBarDestroyed";
                    willBeDestroyed.GetComponent<Renderer>().material = matDestroyed;
                    //StartCoroutine(Wait());
                    howMuchDestroyed++;
                    howMuchToDestroy = allObjects - howMuchToDestroy;
                    sound = GameObject.Find("AudioObject");
                    sound.GetComponent<AudioScript>().SthIsDestroyed();
                    _things_destroyed = howMuchDestroyed;

                    if (_things_destroyed == 6 && LevelControl.Level == 1)
                    {
                        LevelControl.NextLevel_bedroom();
                        LevelControl.Level=2;
                        objectsToDestroy = GameObject.FindGameObjectsWithTag("StatusBar");
                        allObjects = objectsToDestroy.Length;
                        _things_destroyed = 0;
                        howMuchDestroyed = 0;
                        //ui_wait.SetActive(true);
                        //StartCoroutine(PauseGame(3f));
                        // ui_wait.SetActive(false);
                    }


                    if (_things_destroyed == 7 && LevelControl.Level == 2)
                    {
                        LevelControl.NextLevel_livingroom();
                        LevelControl.Level = 3;
                        objectsToDestroy = GameObject.FindGameObjectsWithTag("StatusBar");
                        allObjects = objectsToDestroy.Length;
                        _things_destroyed = 0;
                        howMuchDestroyed = 0;
                        //ui_wait.SetActive(true);
                        // StartCoroutine(PauseGame(3f));
                        // ui_wait.SetActive(false);
                    }

                    if (_things_destroyed == 8 && LevelControl.Level == 3)
                    {
                        //+plus fajerwerki
                        gameobject.SetActive(true);
                    }

                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animCat.SetBool("stopJump", true);
            animCat.SetBool("jumpCat", false);
        }
    }

    public IEnumerator PauseGame(float pauseTime)// to miało być wstrzymanie na parę sekund gry po utracie zycia ale slabo to wyglądało
    {
        Debug.Log("Inside PauseGame()");

        Time.timeScale = 0f;
        int wait = 0;
        int wait_tmp = 0;
        float pauseEndTime = Time.realtimeSinceStartup + pauseTime;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
            wait_tmp +=1;
            wait = wait_tmp/100;

        }
        Time.timeScale = 1f;
        Debug.Log("Done with my pause");

    }


    void FixedUpdate()
    {
        //CatMove code...
        if (canMove)
        {
            float distance = Vector3.Distance(niewolnik.transform.position, kitku.transform.position);
            if (LevelControl.Lives == 0)
            {
                gameobject.SetActive(true);
                sound = GameObject.Find("AudioObject");
                sound.GetComponent<AudioScript>().GameLost();
            }
            if (distance > 0.5)
            {
                //Move cat forward
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
                    if (transform.GetComponent<Rigidbody>().position.z > -8.5)
                        transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, (float)1.05, (float)-8.5);
                    else
                        transform.GetComponent<Rigidbody>().position += Vector3.forward * Time.deltaTime * speed;
                }
                //Move cat Back
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                    if (transform.GetComponent<Rigidbody>().position.z < -11.7)
                        transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, (float)1.05, (float)-11.83);
                    else
                        transform.GetComponent<Rigidbody>().position -= Vector3.forward * Time.deltaTime * speed;
                }
                //Move cat left
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                    if (transform.GetComponent<Rigidbody>().position.x < -1.6)
                        transform.GetComponent<Rigidbody>().position = new Vector3((float)-1.6, (float)1.05, (float)-11.83);
                    else
                        transform.GetComponent<Rigidbody>().position += Vector3.left * Time.deltaTime * speed;
                }
                //Move cat right
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
                    if (transform.GetComponent<Rigidbody>().position.x > 1.6)
                        transform.GetComponent<Rigidbody>().position = new Vector3((float)1.6, (float)1.05, (float)-11.83);
                    else
                        transform.GetComponent<Rigidbody>().position -= Vector3.left * Time.deltaTime * speed;
                }
            }
            else
            {
                //catch handler - kot zostaje przesunięty trochę do tyłu po utracie życia. why? ponieważ zaraz straciłby kolejne po wznowieniu gry bo byłby za blisko 
                if (LevelControl.Lives > 0)
                {
                    LevelControl.Lives -= 1;
                    sound = GameObject.Find("AudioObject");
                    sound.GetComponent<AudioScript>().Caught();
                    if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.back))
                    {
                        if (transform.GetComponent<Rigidbody>().position.z < -9.0)
                        {
                               transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, transform.GetComponent<Rigidbody>().position.y, (float)(transform.GetComponent<Rigidbody>().position.z + 0.5));
                        }
                    }

                    else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.forward))
                    {
                        if (transform.GetComponent<Rigidbody>().position.z > -11.0)
                        {                            
                                transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, transform.GetComponent<Rigidbody>().position.y, (float)(transform.GetComponent<Rigidbody>().position.z - 1));
                        }

                    }
                    else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.left))
                    {
                        if (transform.GetComponent<Rigidbody>().position.x > -0.7)
                        {
                                transform.GetComponent<Rigidbody>().position = new Vector3((float)(transform.GetComponent<Rigidbody>().position.x + 0.5), transform.GetComponent<Rigidbody>().position.y, transform.GetComponent<Rigidbody>().position.z);
                        }
                    }
                    else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.right))
                    {
                        if (transform.GetComponent<Rigidbody>().position.x < 0.55)
                        {
                                transform.GetComponent<Rigidbody>().position = new Vector3((float)(transform.GetComponent<Rigidbody>().position.x - 0.5), transform.GetComponent<Rigidbody>().position.y, transform.GetComponent<Rigidbody>().position.z);
                        }
                    }
                    StartCoroutine(PauseGame(1f));
                }
                else
                {
                    gameobject.SetActive(true);
                    sound = GameObject.Find("AudioObject");
                    sound.GetComponent<AudioScript>().GameLost();
                }
            }


        }
    }
}
