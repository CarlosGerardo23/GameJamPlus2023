using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonMultipleSprites : Button
{
    [SerializeField] private List<Graphic> m_TargetGraphics = new List<Graphic>();

    [SerializeField] private UnityEvent highlightEvents;

    protected override void Start()
    {
        base.Start();
        m_TargetGraphics = GetComponentsInChildren<Graphic>().ToList();
        highlightEvents.AddListener(AddHighlightEvent);
    }

    void AddHighlightEvent()
    {
        FindAnyObjectByType<SoundLibraryScript>().PlaySound(1);
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        if (!gameObject.activeInHierarchy)
            return;

        Color tintColor;

        switch (state)
        {
            case SelectionState.Normal:
                tintColor = colors.normalColor;
                break;
            case SelectionState.Highlighted:
                highlightEvents.Invoke();
                tintColor = colors.highlightedColor;
                break;
            case SelectionState.Pressed:
                tintColor = colors.pressedColor;
                break;
            case SelectionState.Selected:
                tintColor = colors.selectedColor;
                break;
            case SelectionState.Disabled:
                tintColor = colors.disabledColor;
                break;
            default:
                tintColor = Color.black;
                break;
        }

        StartColorTween(tintColor * colors.colorMultiplier, instant);
    }

    void StartColorTween(Color targetColor, bool instant)
    {
        if (m_TargetGraphics.Count <= 0)
            return;

        foreach (Graphic g in m_TargetGraphics)
        {
            if (g != null)
            {
                g.CrossFadeColor(targetColor, instant ? 0f : colors.fadeDuration, true, true);
            }
        }
    }
}
