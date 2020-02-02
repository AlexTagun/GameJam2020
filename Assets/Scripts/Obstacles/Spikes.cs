using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Sprite activeSprite;
    [SerializeField] private Sprite inactiveSprite;
    [SerializeField] private float timeChangeOnActive;
    [SerializeField] private float timeChangeOnInactive;

    [SerializeField] private Collider2D colliderSpikes;

    public bool isActive = false;

    public SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(СhangeSprite());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(СhangeSprite());
    }

    IEnumerator СhangeSprite()
    {
        while (true)
        {
            if (sr.sprite == activeSprite)
            {
                yield return new WaitForSeconds(timeChangeOnInactive);
                sr.sprite = inactiveSprite;
                isActive = false;
                colliderSpikes.enabled = false;
            }
            else
            {
                yield return new WaitForSeconds(timeChangeOnActive);
                sr.sprite = activeSprite;
                isActive = true;
                colliderSpikes.enabled = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("вы в коллайдере");
        }
    }
}
