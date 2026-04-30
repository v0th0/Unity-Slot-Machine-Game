using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ReelController[] reels;
    public Animator leverAnimator;

    bool isSpinning = false;

    public void PullLever()
    {
        if (isSpinning) return;

        isSpinning = true;

        leverAnimator.SetTrigger("Pull");

        StartCoroutine(SpinRoutine());
    }

    IEnumerator SpinRoutine()
    {
        // 🎬 Start reels (staggered)
        foreach (var reel in reels)
        {
            reel.StartSpin();
            yield return new WaitForSeconds(0.15f);
        }

        yield return new WaitForSeconds(2.5f);

        // 🛑 Stop reels (staggered)
        for (int i = 0; i < reels.Length; i++)
        {
            reels[i].StopSpin();
            yield return new WaitForSeconds(0.3f + i * 0.1f);
        }

        // ⏳ wait for final alignment
        yield return new WaitForSeconds(0.8f);

        // 🎯 Collect results
        int[] results = new int[reels.Length];

        for (int i = 0; i < reels.Length; i++)
        {
            results[i] = reels[i].GetResult();
        }

        CheckWin(results);

        isSpinning = false;
    }

    void CheckWin(int[] r)
    {
        if (r[0] == r[1] && r[1] == r[2])
        {
            Debug.Log("🎉 WIN!");
        }
        else
        {
            Debug.Log("❌ TRY AGAIN");
        }
    }
}