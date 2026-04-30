using UnityEngine;
using TMPro;
using System.Collections;

public class WinManager : MonoBehaviour
{
    public GameObject jackpotPanel;
    public GameObject savePanel;
    public GameObject losePanel;

    public TextMeshProUGUI creditText;

    int credits = 0;

    public void Evaluate(int[] r)
    {
        StopAllCoroutines(); // ⭐ prevent overlap

        // Reset all panels
        jackpotPanel.SetActive(false);
        savePanel.SetActive(false);
        losePanel.SetActive(false);

        if (r[0] == r[1] && r[1] == r[2])
        {
            credits += 30;
            StartCoroutine(ShowPanel(jackpotPanel));
        }
        else if (r[0] == r[1] || r[1] == r[2] || r[0] == r[2])
        {
            credits += 15;
            StartCoroutine(ShowPanel(savePanel));
        }
        else
        {
            credits -= 5;
            StartCoroutine(ShowPanel(losePanel));
        }

        creditText.text = "Credits: " + credits;
    }

    IEnumerator ShowPanel(GameObject panel)
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
    }
}