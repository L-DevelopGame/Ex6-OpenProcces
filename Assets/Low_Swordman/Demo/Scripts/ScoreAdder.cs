using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]

/**
 * This component increases a given "score" field whenever it is triggered.
 */
public class ScoreAdder : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger adding score to the score field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointsToAdd;
    [SerializeField] GameObject wellDoneText;
    [SerializeField] TextMeshProUGUI pickedAnimalsText; // Reference to the UI Text element

    private List<string> pickedAnimals = new List<string>();


    private void Start()
    {
        wellDoneText.SetActive(false);
        pickedAnimalsText.text = ""; // Clear the text initially



    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && scoreField!=null) {
            Debug.Log(other.tag + " other.tag, " + triggeringTag + " triggeringTag=" );
            scoreField.AddNumber(pointsToAdd);

            pickedAnimals.Add(other.gameObject.name); // Add picked animal to the list

            UpdatePickedAnimalsText(); // Update the text when a new animal is picked
            Destroy(other.gameObject);
            StartCoroutine(ShowWellDoneText());

        }
    }

    private void UpdatePickedAnimalsText()
    {
        // Clear the previous text
        pickedAnimalsText.text = "Picked Animals:\n";

        // Append each picked animal to the text
        foreach (string animal in pickedAnimals)
        {
            pickedAnimalsText.text += animal + "\n";
        }
    }

    public void SetScoreField(NumberField newTextField) {
        this.scoreField = newTextField;
    }

    private IEnumerator ShowWellDoneText()
    {
        wellDoneText.SetActive(true);
        yield return new WaitForSeconds(2f);
        wellDoneText.SetActive(false);
    }



}
