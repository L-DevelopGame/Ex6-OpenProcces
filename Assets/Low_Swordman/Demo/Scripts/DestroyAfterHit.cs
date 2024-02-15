using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyAfterHits : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    [SerializeField] int HitPoints;
    [Tooltip("Every enemy hitting will decrease this field")]
    [SerializeField] NumberFieldGUI HealthField;
    [SerializeField] GameObject messagePanel;
    bool messageShown = false;

    private void Start()
    {
        HealthField.SetNumber(HitPoints);
        messagePanel.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag )
        {

            --HitPoints;
            HealthField.SetNumber(HitPoints);
             Destroy(other.gameObject);
            ShowMessagePanel();
            messageShown = true; // Ensure message is shown only once

            if (HitPoints == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void ShowMessagePanel()
    {
        messagePanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    void Update()
    {
        if (messageShown && Input.GetKeyDown(KeyCode.Space))
        {
            // Hide the message panel and resume the game
            messagePanel.SetActive(false);
            Time.timeScale = 1; // Resume the game
        }
    }

}