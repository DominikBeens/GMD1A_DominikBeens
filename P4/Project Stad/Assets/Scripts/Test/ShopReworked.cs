using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopReworked : MonoBehaviour
{

    public GameObject triggerTextObject;
    public Text triggerText;
    public string triggerTextInput;

    public int amountOfButtons;
    public GameObject buttonPrefab;

    public Transform exitShopButtonSpawn;
    public GameObject exitShopButton;
    public GameObject exitShopButtonReference;

    public GameObject shopUI;
    public GameObject scrollViewContent;
    public bool shopActive;

    public GameObject player;
    public Animator anim;
    public RigidbodyConstraints2D defaultConstraints;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        defaultConstraints = player.GetComponent<Rigidbody2D>().constraints;
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerText.text = triggerTextInput;
            triggerTextObject.SetActive(true);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButtonDown("e"))
            {
                if (!shopActive)
                {
                    StartCoroutine(EnterShop());
                }
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerTextObject.SetActive(false);
        }
    }

    public IEnumerator EnterShop()
    {
        shopActive = true;
        anim.SetTrigger("OpenDoor");
        player.GetComponent<Charactercontroller>().enabled = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        yield return new WaitForSeconds(0.5f);

        player.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        triggerTextObject.SetActive(false);
        shopUI.SetActive(true);
        CreateButtons();
    }

    public IEnumerator ExitShop()
    {
        DestroyButtons();
        shopUI.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        player.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(0.5f);

        player.GetComponent<Charactercontroller>().enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = defaultConstraints;
        anim.SetTrigger("CloseDoor");
        triggerTextObject.SetActive(true);
        shopActive = false;
    }

    public void CreateButtons()
    {
        for (int i = 0; i < amountOfButtons; i++)
        {
            Instantiate(buttonPrefab, transform.position, Quaternion.identity).transform.SetParent(scrollViewContent.transform, false);
        }

        GameObject exitShopButtonInstantiate =  Instantiate(exitShopButton, exitShopButtonSpawn.position, Quaternion.identity);
        exitShopButtonInstantiate.transform.SetParent(exitShopButtonSpawn.transform, true);

        exitShopButtonInstantiate.GetComponent<Button>().onClick.AddListener(CloseShopButton);

        exitShopButtonReference = exitShopButtonInstantiate;
    }

    public void DestroyButtons()
    {
        foreach (Transform button in scrollViewContent.transform)
        {
            Destroy(button.gameObject);
        }

        Destroy(exitShopButtonReference);
    }

    public void CloseShopButton()
    {
        DestroyButtons();
        StartCoroutine(ExitShop());
    }
}
