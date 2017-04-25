using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{

    public UIManager uim;
    public PlayerStats ps;

    public bool canFish = true;
    public float randomBiteChance;

    public Color defaultLoadbarColor;
    public Color fishStrikeLoadbarColor;
    public Color failedCatchTimingColor;

    public bool canAttemptToCath;
    public float caughtFishChance;
    public bool caughtFish;

    public List<string> fish = new List<string>();
    public List<Sprite> fishSprites = new List<Sprite>();
    public int listIndex;

    public CameraMovement camMove;
    public Camera cam;
    public GameObject fishingPerspective;
    public float moveSpeed = 3f;
    public float turnSpeed = 3f;

    void Start()
    {
        randomBiteChance = Random.value;
        defaultLoadbarColor = uim.fishingLoadbarFill.color;
        fishStrikeLoadbarColor = new Color(0, 255, 0, 255);
        failedCatchTimingColor = new Color(255, 0, 0, 255);
    }

    void Update()
    {
        if (canAttemptToCath)
        {
            if (Input.GetButtonDown("Jump"))
            {
                caughtFishChance = Random.value;

                if (caughtFishChance <= 0.65f)
                {
                    caughtFish = true;
                    listIndex = Random.Range(0, fish.Count);

                    if (fish[listIndex].StartsWith("a") || fish[listIndex].StartsWith("e") || fish[listIndex].StartsWith("i") || fish[listIndex].StartsWith("o") || fish[listIndex].StartsWith("u"))
                    {
                        uim.caughtText.text = "You've caught an " + fish[listIndex] + "!";
                    }
                    else
                    {
                        uim.caughtText.text = "You've caught a " + fish[listIndex] + "!";
                    }

                    uim.caughtImage.sprite = fishSprites[listIndex];
                    uim.caughtFishPanel.SetActive(true);
                }
                else
                {
                    StartCoroutine(Dialogue("The fish escaped.."));
                    canFish = true;
                }

                StopCoroutine("Load");

                uim.fishingLoadbarFill.fillAmount = 0;
                //fishingLoadbarPanel.SetActive(false);

                uim.fishingLoadbarFill.color = defaultLoadbarColor;
                randomBiteChance = Random.value;
            }
        }
        else if (canFish == false && Input.GetButtonDown("Jump"))
        {
            StartCoroutine(FailedCatchTiming());
        }
    }

    public IEnumerator Load()
    {
        canFish = false;

        //fishingLoadbarPanel.SetActive(true);
        uim.triggerPanel.SetActive(false);

        for (float f = uim.fishingLoadbarFill.fillAmount; f < 1; f += (Time.deltaTime / 5))
        {
            uim.fishingLoadbarFill.fillAmount += (Time.deltaTime / 5);
            yield return null;

            if (uim.fishingLoadbarFill.fillAmount >= (randomBiteChance - 0.002f) && uim.fishingLoadbarFill.fillAmount <= (randomBiteChance + 0.002f))
            {
                StartCoroutine(ChangeBarColor());
            }
        }

        if (uim.fishingLoadbarFill.fillAmount >= 0.99f)
        {
            uim.fishingLoadbarFill.fillAmount = 0;
            //fishingLoadbarPanel.SetActive(false);

            randomBiteChance = Random.value;
            canFish = true;
        }
    }

    public IEnumerator ChangeBarColor()
    {
        uim.fishingLoadbarFill.color = fishStrikeLoadbarColor;
        canAttemptToCath = true;

        yield return new WaitForSeconds(0.5f);

        canAttemptToCath = false;
        uim.fishingLoadbarFill.color = defaultLoadbarColor;

    }

    public IEnumerator FailedCatchTiming()
    {
        StopCoroutine("Load");

        uim.fishingLoadbarFill.color = failedCatchTimingColor;
        StartCoroutine(Dialogue("'I should work on my timing'"));

        yield return new WaitForSeconds(1);

        uim.fishingLoadbarFill.fillAmount = 0;
        //fishingLoadbarPanel.SetActive(false);

        uim.fishingLoadbarFill.color = defaultLoadbarColor;
        randomBiteChance = Random.value;
        canFish = true;
    }

    public IEnumerator Dialogue(string s)
    {
        uim.dialogueText.text = s;

        uim.dialogueTextObject.SetActive(true);
        uim.dialogueText.canvasRenderer.SetAlpha(0.01f);
        uim.dialogueText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(2.0f);

        uim.dialogueText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.dialogueTextObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider col)
    {
        uim.triggerPanelText.text = "Press E to start fishing\nand press Space to catch";
        uim.triggerPanel.SetActive(true);
    }

    public void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E) && canFish == true)
        {
            uim.triggerPanel.SetActive(false);
            StartCoroutine("Load");
        }

        camMove.mainView = false;
        cam.transform.position = Vector3.Lerp(cam.transform.position, fishingPerspective.transform.position, (moveSpeed * Time.deltaTime));
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, fishingPerspective.transform.rotation, (turnSpeed * Time.deltaTime));
    }

    public void OnTriggerExit(Collider col)
    {
        camMove.mainView = true;
        uim.triggerPanel.SetActive(false);
    }

    public void CloseCaughtFishPanel()
    {
        uim.caughtFishPanel.SetActive(false);
        canFish = true;
    }

    public void EatFish()
    {
        if (ps.hunger <= 75)
        {
            ps.StopAllCoroutines();
            ps.hunger += 25;
            ps.StartRoutines();
        }

        if (ps.water <= 95)
        {
            ps.StopAllCoroutines();
            ps.water += 5;
            ps.StartRoutines();
        }

        if (ps.health <= 85)
        {
            ps.StopAllCoroutines();
            ps.health += 15;
            ps.StartRoutines();
        }

        uim.caughtFishPanel.SetActive(false);
        canFish = true;
    }
}
