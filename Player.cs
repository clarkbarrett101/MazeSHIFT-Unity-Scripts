using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    Camera cam;
    public bool[] keys = new bool[4];
    public SpriteRenderer[] keySprites;
    public float turnAccel = 0;
    public float moveAccel = 0;
    public float moveSpeed = 1;
    public float turnSpeed = 1;
    bool shift = false;
    public SpriteRenderer vignette;
    public Vector3 move;
    private Animator anim;
    public static int level;
    public Sprite[] buttons;
    public Image button;
    public bool spinLock = false;
    public Interactable interactable;
    public Image interactButton;
    public AudioSource audioSource;
    public GameObject[] prompts;
    public AudioClip shiftSound;
    public static Color color1;
    public static Color color2;
    public SpriteRenderer[] compass;
    void Start()
    {
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        for(int i = 0; i < keys.Length; i++)
        {
            keys[i] = false;
        }
        Input.simulateMouseWithTouches = true;
        foreach (var VARIABLE in compass)
        {
            VARIABLE.color = color1;
        }
    }

    // Update is called once per frame
    void Update()
    { for(int i = 0; i < keys.Length; i++)
        {
            keySprites[i].enabled = keys[i];
        }
        anim.SetBool("Shiftable",CheckShift());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!Physics.Raycast(transform.position, transform.TransformDirection(move),
                (moveAccel * Time.deltaTime * moveSpeed + .1f), LayerMask.GetMask("Wall"),
                QueryTriggerInteraction.Ignore))
        {
            transform.position += transform.TransformDirection(move) * (moveAccel * Time.deltaTime * moveSpeed);
        }
        else
        {
            moveAccel = 0;
        }
        if (move.sqrMagnitude != 0)
        {
            moveAccel +=  Time.deltaTime;
            moveAccel = Mathf.Clamp(moveAccel, 0, 1.5f);
        }
        else
        {
            moveAccel = 0;
        }
    }

    public void OnShift()
    {
        if (spinLock || !CheckShift())
            return;
        shift = !shift;
        anim.SetTrigger("Shift");
      //  ShiftPosition();
       StartCoroutine(SpinLock());

    }
    bool CheckShift()
    {
        bool b = true;
        if (shift && Physics.Raycast(transform.position, -transform.up, 1, LayerMask.GetMask("Wall"), QueryTriggerInteraction.Ignore))
            b = false;
        if (!shift && Physics.Raycast(transform.position, transform.up, 1, LayerMask.GetMask("Wall"), QueryTriggerInteraction.Ignore))
            b = false;
        if (b)
        {
            button.gameObject.SetActive(true);
        }else
        {
            button.gameObject.SetActive(false);
        }
        return b;
    }

    public void ShiftPosition()
    {
        audioSource.PlayOneShot(shiftSound);
                if (shift)
                {
                    transform.position+=Vector3.up;
                    button.sprite = buttons[1];
                    foreach (SpriteRenderer s in compass)
                    {
                        s.color = color2;
                    }
                }
                else
                {
                    transform.position += Vector3.down;
                    button.sprite = buttons[0];
                    foreach (SpriteRenderer s in compass)
                    {
                        s.color = color1;
                    }
                }
    }

    public void OnMove(InputValue value)
    {
        move.z = value.Get<Vector2>().y;
        move.x = value.Get<Vector2>().x;
    }


    public void SetInteract(bool interact, Sprite sprite)
    {
        if (interact)
        {
            interactButton.gameObject.SetActive(true);
            interactButton.sprite = sprite;
        }
        else
        {
            interactButton.gameObject.SetActive(false);
        }
    }
    IEnumerator SpinLock()
    {
        spinLock = true;
        yield return new WaitForSeconds(.5f);
        spinLock = false;
    }

    public void Tutorial(int i, bool b)
    {
        prompts[i].SetActive(b);
    }

    public void OnInteract()
    {
        if(interactable != null)
            interactable.Interact();
    }
}