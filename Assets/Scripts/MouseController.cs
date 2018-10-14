using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class MouseController {
    private static bool isClicked = false;

    public enum MouseButton
    {
        LeftButton,
        RightButton,
        MiddleButton
    };

    public static bool IsMouseButtonClicked(MouseButton button)
    {
        if (Input.GetMouseButtonDown((int)button))
        {
            isClicked = true;
        }

        if (Input.GetMouseButtonUp((int)button))
        {
            isClicked = false;
        }

        return isClicked;
    }

    public static bool IsMouseButtonHolded(MouseButton button)
    {
        if (Input.GetMouseButton((int)button) && isClicked) return true;

        return false;
    }
}
