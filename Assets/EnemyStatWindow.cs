using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyStatWindow : MonoBehaviour
{
    public GameObject enemyCharacter;
    public EnemyController script = null;
    private SpriteRenderer spriteRenderer = null;

    public Image charImage;

    public bool hiding = true;
    private float speed = 10f;
    private float distance = 3f;
    private float startingY;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;


    private Vector3 targetPosition;
    
    void Start()
    {
        startingY = transform.position.y;
        targetPosition = new Vector3(transform.position.x, startingY - distance, transform.position.z);

        ChangeChar(enemyCharacter);
    }

    // call whenever a user clicks on a different character
    public void ChangeChar(GameObject character)
    {
        spriteRenderer = character.GetComponent<SpriteRenderer>();
        charImage.sprite = spriteRenderer.sprite;
        script = character.GetComponent<EnemyController>();
    }

    public void Display()
    {
        if (hiding)
        {
            hiding = false;
        }
    }

    public void Hide()
    {
        if (!hiding)
        {
            hiding = true;
        }
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition;

        if (hiding)
        {
            newPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            newPosition = Vector3.MoveTowards(currentPosition, new Vector3(currentPosition.x, startingY, currentPosition.z), speed * Time.deltaTime);
        }

        transform.position = newPosition;

        hpText.text = "HP[" + script.health.ToString() + "]";
        atkText.text = "ATK[" + script.attack.ToString() + "]";
    }
}
