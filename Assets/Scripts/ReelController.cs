using UnityEngine;

public class ReelController : MonoBehaviour
{
    public RectTransform[] symbols;

    public float spinSpeed = 800f;
    public float symbolHeight = 34f;

    float currentSpeed;
    bool isSpinning = false;
    bool isStopping = false;

    void Update()
    {
        if (!isSpinning) return;

        // 🔄 Move symbols
        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition -= new Vector2(0, currentSpeed * Time.deltaTime);

            // 🔁 Loop symbols to top
            if (symbol.anchoredPosition.y < -symbolHeight * 2)
            {
                float highestY = GetHighestY();
                symbol.anchoredPosition = new Vector2(
                    symbol.anchoredPosition.x,
                    highestY + symbolHeight
                );
            }
        }

        // 🛑 Smooth stop
        if (isStopping)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * 3f);

            // 🔥 STRICT STOP (no random threshold)
            if (currentSpeed < 20f)
            {
                isSpinning = false;
                isStopping = false;
                currentSpeed = 0;

                SnapToCenter(); // ⭐ perfect alignment
            }
        }
    }

    float GetHighestY()
    {
        float max = float.MinValue;

        foreach (RectTransform s in symbols)
        {
            if (s.anchoredPosition.y > max)
                max = s.anchoredPosition.y;
        }

        return max;
    }

    public void StartSpin()
    {
        isSpinning = true;
        isStopping = false;

        // 🔥 slight variation for realism
        currentSpeed = spinSpeed + Random.Range(-50f, 50f);
    }

    public void StopSpin()
    {
        isStopping = true;
    }

    // ⭐ PERFECT GRID SNAP
    void SnapToCenter()
    {
        float closest = float.MaxValue;
        RectTransform target = null;

        foreach (RectTransform symbol in symbols)
        {
            float dist = Mathf.Abs(symbol.anchoredPosition.y);

            if (dist < closest)
            {
                closest = dist;
                target = symbol;
            }
        }

        if (target == null) return;

        // 🔥 snap exactly to grid (no offset errors)
        float snappedY = Mathf.Round(target.anchoredPosition.y / symbolHeight) * symbolHeight;

        float offset = target.anchoredPosition.y - snappedY;

        foreach (RectTransform symbol in symbols)
        {
            symbol.anchoredPosition -= new Vector2(0, offset);
        }
    }

    // 🎯 Get center symbol index
    public int GetResult()
    {
        float closest = float.MaxValue;
        int index = 0;

        for (int i = 0; i < symbols.Length; i++)
        {
            float dist = Mathf.Abs(symbols[i].anchoredPosition.y);

            if (dist < closest)
            {
                closest = dist;
                index = i;
            }
        }

        return index;
    }
}