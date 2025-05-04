using System.Collections;
using TMPro;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime;

    [SerializeField] private GameObject textPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private int currentPoint = 0;
    private int currentDialogueIndex = 0;

    private bool isInteracting = false;
    void Awake()
    {
        transform.position = movementPoints[0].position;
        StartCoroutine(NPCMove());
    }
    IEnumerator NPCMove()
    {
        while (true)
        {
            Transform target = movementPoints[currentPoint];
            while (Vector3.Distance(transform.position, target.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                yield return null;
            }
            yield return new WaitForSeconds(waitingTime);
            currentPoint = (currentPoint + 1) % movementPoints.Length;
        }
    }
    public IEnumerator Interact()
    {
        if (isInteracting) yield break;

        isInteracting = true;

        speed = 0f;
        textPanel.SetActive(true);
        switch (currentDialogueIndex)
        {
            case 0:
                dialogueText.text = "GAAAAAAAA";
                break;
            case 1:
                dialogueText.text = "Con fuerza el próximo ciclo";
                break;
            case 2:
                dialogueText.text = "Entregar todo es avaricia";
                break;
            case 3:
                dialogueText.text = "Mejor me duermo";
                break;
            case 4:
                dialogueText.text = "ZZZ";
                break;
            default:               
                break;
        }
        currentDialogueIndex = (currentDialogueIndex + 1) % 5;

        yield return new WaitForSeconds(3f);

        textPanel.SetActive(false);
        speed = 5f;

        isInteracting = false;
    }
}