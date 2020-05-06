using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KhmerFontAdjusterDemo : MonoBehaviour
{
    public Dropdown FontDropdown;
    public Font[] Fonts;
    public Text OriginalText;
    public Text AdjustedText;
    public TextMeshProUGUI AdjustedText2;

    private void Start()
    {
        PrepareFontDropdown();
        ShowText();
    }

    private void PrepareFontDropdown()
    {
        FontDropdown.options.Clear();
        foreach (var font in Fonts)
            FontDropdown.options.Add(new Dropdown.OptionData(font.name));
        FontDropdown.captionText.text = Fonts[0].name;
    }

    public void OnFontDropdownValueChange()
    {
        ShowText();
    }

    public void PreviousFontButtonPressed()
    {
        int v = FontDropdown.value - 1 < 0 ? FontDropdown.options.Count - 1 : FontDropdown.value - 1;
        FontDropdown.value = v;
    }

    public void NextFontButtonPressed()
    {
        int v = FontDropdown.value + 1 >= FontDropdown.options.Count ? 0 : FontDropdown.value + 1;
        FontDropdown.value = v;
    }

    private void ShowText()
    {
        var s = "ខ ្ រ      ខ្រ";

        ShowText(s);
    }

    private void ShowText(string s)
    {
        var font = Fonts[FontDropdown.value];
        OriginalText.font = font;
        OriginalText.text = s;
        
        AdjustedText.font = font;
        AdjustedText.text = KhmerFontAdjuster.Adjust(s);
        
        AdjustedText2.text = KhmerFontAdjuster.Adjust(s);
    }
}
