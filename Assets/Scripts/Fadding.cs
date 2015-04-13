using UnityEngine;
using System.Collections;

public class Fadding : MonoBehaviour {

	public Texture2D fadeOutTexture; //A textura que vai aparecer na tela. Pode ser uma imagem em branco (preta, sei la) ou um grafico de loading :)
	public float fadeSpeed = 0.8f; //Parece meio obvio

	private int drawDepth = -1000; // A ordem da textura na hierarquia de desenho. Um numero pequeno significa que ela renderiza no topo.
	private float alpha = 1.0f; // Um numero que varia entre 0 e 1, indicando o quao visivel a cena de fade esta.
	private int fadeDirection = -1; // a direçao do fade: in : -1 out:1


	// Use this for initialization
	void OnGUI(){
		// fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds.
		alpha += fadeDirection * fadeSpeed * Time.deltaTime;
		// força (clamp) o numero entre 0 e 1 porque GUI.color so usa valor alpha entre 0 e 1.
		alpha = Mathf.Clamp01 (alpha);

		//configura a cor do nosso ecra (GUI) (neste caso, nossa textura). Todas os valores das correr permanecem os mesmos, e apenas o alpha e configurado.
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha); // configura o valor do alpha
		GUI.depth = drawDepth; // faz a textura renderizar no topo (ultima a ser desenhada)
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); // Desenha a textura na tela toda.
	}

	public float BeginFade(int direction){
		fadeDirection = direction;
		return (fadeSpeed); //Retorna a velocidade do fade para ficar facil de sincronizar o Application.LoadLevel();
	}

	void OnLevelWasLoaded(){
		//alpha = -1; //Usar isso se o alpha nao estiver configurado como 1 por default.
		BeginFade (-1);
	}
}


















