using UnityEngine;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textoGame;
    public string textoVitoria;
    public float tempoParareiniciar = 3f;


    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        textoGame.text = $"Pong Win {textoVitoria} !";
        textoGame.gameObject.SetActive(true);

        Destroy(collision.gameObject);
        StartCoroutine(ReiniciarDepoisDeTempo());
    }

      IEnumerator ReiniciarDepoisDeTempo()
    {
        yield return new WaitForSeconds(tempoParareiniciar);
        UnityEditor.EditorApplication.isPlaying = false;
    }

     
}
    