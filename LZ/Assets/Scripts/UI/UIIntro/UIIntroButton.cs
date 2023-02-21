using UnityEngine;

public class UIIntroButton : MonoBehaviour
{
    public IntroButtonType IntroButtonType = IntroButtonType.None;

    public void OnClick_Active(int index)
    {
        Refresh();

        var type = (IntroButtonType)index;

        if (IntroButtonType == type)
        {
            GameManager.Instance.IntroController.OnButtonByIntroType(type);
        }
        else
        {
            IntroButtonType = type;
        }

        transform.GetChild(index - 1).transform.GetChild(0).gameObject.SetActive(true);
    }

    private void Refresh()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
