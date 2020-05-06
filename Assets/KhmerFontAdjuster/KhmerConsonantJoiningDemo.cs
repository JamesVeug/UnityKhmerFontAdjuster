using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KhmerConsonantJoiningDemo : MonoBehaviour
{
    public Dropdown ConsonantDropdown;
    public Text OriginalText;
    public TextMeshProUGUI AdjustedText;

    private void Start()
    {
        PrepareFontDropdown();
        ShowText();
    }

    private void PrepareFontDropdown()
    {
        ConsonantDropdown.options.Clear();
        foreach (char consonant in KhmerFontAdjuster.ConsonantToSubscriptForm.Keys)
        {
            ConsonantDropdown.options.Add(new Dropdown.OptionData("" + consonant));
        }

        ConsonantDropdown.captionText.text = ConsonantDropdown.options[0].text;
    }

    public void OnDropdownChanged()
    {
        ShowText();
    }

    public void PreviousFontButtonPressed()
    {
        int v = ConsonantDropdown.value - 1 < 0 ? ConsonantDropdown.options.Count - 1 : ConsonantDropdown.value - 1;
        ConsonantDropdown.value = v;
    }

    public void NextFontButtonPressed()
    {
        int v = ConsonantDropdown.value + 1 >= ConsonantDropdown.options.Count ? 0 : ConsonantDropdown.value + 1;
        ConsonantDropdown.value = v;
    }

    private void ShowText()
    {
        string left = ConsonantDropdown.options[ConsonantDropdown.value].text;
        string s = left;
        foreach (char right in KhmerFontAdjuster.ConsonantToSubscriptForm.Keys)
        {
            s += "\t" + left + KhmerFontAdjuster.ConsonantJoiner + right;
        }

        ShowText(s);
    }

    private void ShowText(string s)
    {
        OriginalText.text = s;
        AdjustedText.text = KhmerFontAdjuster.Adjust(s);
    }
}
