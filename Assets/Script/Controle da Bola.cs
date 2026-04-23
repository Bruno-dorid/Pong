using UnityEngine;

public class Bola : MonoBehaviour

{
    //===================Variaveis=============
    private Rigidbody2D rb;

    [SerializeField]
    private float velocidade = 8f;

    [SerializeField]
    private float aumentoVelocidade = 0.5f;

    [SerializeField]
    private float velocidadeMaxima = 25f;

    //======================Métodos==============

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //iniciar a bola em um lado aleatório
        float x = Random.value > 0.5f ? 1f : -1f;
        float y = Random.Range(-0.5f, 0.5f);

        rb.linearVelocity = new Vector2(x, y).normalized * velocidade;

    }
      
    private void FixedUpdate()
    {
       //Matem uma velocidade constante
       rb.linearVelocity =
             rb.linearVelocity.normalized* velocidade;


    }

    private void OncollisionEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player")
          || collision.gameObject.CompareTag("Enemy"))
        {

            velocidade += aumentoVelocidade;
            if(velocidade > velocidadeMaxima)
            {
                velocidade = velocidadeMaxima;
            }
             //Descobrir o ponto de impacto da bolinha 
            float impactoy = transform.position.y - collision.transform.position.y;

            //Defenir direção da bolinha 
            float direcaox = collision.gameObject.CompareTag("Player") ? 1f : -1f;

            //Nova direção da bolinha
            Vector2 novaDirecao = new Vector2(direcaox, impactoy).normalized;

            //aplicar nova velocidade á bola
            rb.linearVelocity = novaDirecao * velocidade;
        }

        





    }
}
        
    

