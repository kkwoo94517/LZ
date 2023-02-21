using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    [SerializeField] private UIIntroButton UIIntroButton;
    [SerializeField] private GameObject Intro;
    [SerializeField] private GameObject InGame;
    [SerializeField] private Text LoadDataText;

    private bool LoadDone = false;

    public void Load()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        LoadDataText.text = "���� �غ���...";
        yield return new WaitForSeconds(0.2f);

        var datas = Database.Instance.LoadData();

        while (datas.MoveNext())
        {
            var doneText = datas.Current;

            LoadDataText.text = doneText;
            yield return new WaitForSeconds(0.5f);
        }

        LoadDone = true;
        LoadDataText.text = "������ �غ�Ǿ����ϴ� !";
    }

    public void OnButtonByIntroType(IntroButtonType type)
    {
        if (!LoadDone) { return; }

        switch (type)
        {
            case IntroButtonType.None: return;

            case IntroButtonType.NewGame:
                GameManager.Instance.BackGround_FadeIn(
                null,
                () =>
                {
                    Intro.SetActive(false);
                    InGame.SetActive(true);
                    GameManager.Instance.NewGame();
                }
                , duration: 15f);
                break;
            case IntroButtonType.Continue:
                GameManager.Instance.BackGround_FadeIn(
                    null,
                    () =>
                    {
                        Intro.SetActive(false);
                        InGame.SetActive(true);
                        GameManager.Instance.NewGame();
                    }
                , duration: 15f);
                break;
            case IntroButtonType.Exit:
                break;
        }
    }
}
