using UnityEngine;

public class CheckActivation : MonoBehaviour
{
    public GameObject checkAGameObject;
    public GameObject checkBGameObject;
    public GameObject congratsCanvas;

    private ScoreManager scoreManager;
    private Merge mergeScript;
    private bool checkAActivated;
    private bool checkBActivated;

    void Start()
    {
        scoreManager = ScoreManager.instance;
    }

    void Update()
    {
        if (scoreManager != null && !checkAActivated)
        {
            int currentScore = scoreManager.GetCurrentScore();

            if (currentScore >= 1200)
            {
                ActivateCheckA();
                checkAActivated = true;
            }
        }

        if (!checkBActivated)
        {
            ActivateCheckB();
        }

        if (checkAActivated && checkBActivated)
        {
            ActivateCongratsCanvas();
        }
    }

    void ActivateCheckA()
    {
        if (checkAGameObject != null)
        {
            checkAGameObject.SetActive(true);
        }
    }

    void ActivateCheckB()
    {
        if (mergeScript == null)
        {
            mergeScript = FindObjectOfType<Merge>();
        }

        if (mergeScript != null)
        {
            mergeScript.replaceKue(checkBGameObject);
            checkBActivated = mergeScript.IsCheckBActivated();
        }
    }

    void ActivateCongratsCanvas()
    {
        if (congratsCanvas != null)
        {
            congratsCanvas.SetActive(true);
        }
    }
}
