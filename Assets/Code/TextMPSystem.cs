using System.Collections;
using UnityEngine;
using TMPro;
public class TextMPSystem : MonoBehaviour
{
    [TextArea] [SerializeField] string[] texts;
    [SerializeField] float timeToAddACharacter = 0.1f;
    [SerializeField] GameObject SpaceUI;
    [SerializeField] bool playOnAwake = true;
    TextMeshProUGUI textUI;
    AudioSource audioSource;
    void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
        switch (playOnAwake) { case true: StartCoroutine(TextShow()); break; }
    }
    internal IEnumerator TextShow()
    {
        SpaceUI.SetActive(false);
        foreach (string t in texts)
        {
            foreach (char c in t)
            {
                yield return new WaitForSeconds(timeToAddACharacter);
                audioSource.Play();
                textUI.text += c;
            }
            SpaceUI.SetActive(true);
            yield return new WaitUntil(() => Input.GetButtonDown("Jump"));
            SpaceUI.SetActive(false);
            textUI.text = "";
        }
    }
}