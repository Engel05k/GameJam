using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesicionGame : MonoBehaviour
{
    public Text diaTexto;
    public Text energiaTexto;
    public Text felicidadTexto;

    private Scene scene;
    [SerializeField] string escena;
    [SerializeField] int Dia;

    [SerializeField] Image Alarma;
    [SerializeField] Image BusSolo;
    [SerializeField] Image BusJoshua;
    [SerializeField] Image clase;
    [SerializeField] Image regresoBus;
    [SerializeField] Image salidaFinalJoshua;
    [SerializeField] Image YaEnCasa;

    [Header("Día 2")]
    [Header("Alarma")]
    [SerializeField] private GameObject botonLevantarse;
    [SerializeField] private GameObject botonposponerdia2;
    [Header("Ida Bus")]
    [SerializeField] private GameObject botonEscucharMusica;
    [SerializeField] private GameObject botonIdaMirarVentana;
    [SerializeField] private GameObject botonDormir;
    [Header("En clase")]
    [SerializeField] private GameObject botonDibujarDia2;
    [SerializeField] private GameObject botonParticiparClaseDia2;
    [SerializeField] private GameObject botonDormirClaseDia2;
    [SerializeField] private GameObject botonTriviaOpcion1Dia2;
    [SerializeField] private GameObject botonTriviaOpcion2Dia2;
    [Header("Regreso Bus")]    
    [SerializeField] private GameObject botonRegresoEscucharMusica;
    [SerializeField] private GameObject botonRedesSociales;
    [Header("Casa")]
    [SerializeField] private GameObject botonEscribirDiario;
    [SerializeField] private GameObject botonIgnorarDiario;
    [Header("Día 3")]
    [Header("Alarma")]    
    [SerializeField] private GameObject botonRevisarCelular;
    [Header("Ida Bus")]
    [SerializeField] private GameObject botonSaludarJoshua;
    [SerializeField] private GameObject botonHacerteElDormido;
    [Header("En clase")]
    [SerializeField] private GameObject botonPracticarDibujoDia3;
    [SerializeField] private GameObject botonAtenderClase;    
    [SerializeField] private GameObject botonParticiparClaseDia3;
    [SerializeField] private GameObject botonTriviaOpcion1Dia3;
    [SerializeField] private GameObject botonTriviaOpcion2Dia3;
    [Header("Regreso Bus")]
    [SerializeField] private GameObject botonEscribirJeremy;    
    [SerializeField] private GameObject botonPensarVida;     
    [Header("Día 4")]
    [Header("alarma")]
    [SerializeField] private GameObject botonEscribirleJoshua;     
    [Header("Ida Bus")]
    [SerializeField] private GameObject botonLeerDocumentosDia4;
    [SerializeField] private GameObject botonDormirDia4;
    [SerializeField] private GameObject botonHablarConJoshua;
    [Header("En clase")]
    [SerializeField] private GameObject botonParticipar;
    [SerializeField] private GameObject botonSalirteDeLaClase;
    [Header("Regreso Bus")]
    [SerializeField] private GameObject botonSalirConJoshua;
    [SerializeField] private GameObject botonDormirTodoCamino;
    [SerializeField] private GameObject botonEscucharMusicaDia4;
     


    private bool dibujoHecho = false;   
    private bool hasDormiidoClase1 = false;      
    private bool hasConocidoJoshua = false;
    private bool hasHabladoJoshua = false;    

    StatsScript estado;
    // para q puedan elegirlo en el UI tienen que ir al boton luego onclick luego agregar este script y
    // luego elegir la funcion TomarDecision y luego escribir el nombre de la decision que quieren tomar
    // y asi pueden hacer un boton para cada decision, por ejemplo: viajar bus, en clase, pelicula, etc
    void Start()
    {
        MostrarEstado();

    }

    public void TomarDecision(string Escena)
    {
        switch (Escena)
        {
            case "Alarma":
                if (estado.day == 2)
                {
                    botonLevantarse.SetActive(true);
                    botonposponerdia2.SetActive(true);
                }
                else if (estado.day == 3)
                {
                    botonRevisarCelular.SetActive(true);
                    botonLevantarse.SetActive(true);
                }
                else if (estado.day == 4)
                {
                    botonRevisarCelular.SetActive(true);
                    botonLevantarse.SetActive(true);
                    if (hasConocidoJoshua && hasHabladoJoshua)
                    {
                        botonEscribirleJoshua.SetActive(true);
                    }
                }
                    break;
            case "En clase":
                if (estado.day == 2)
                {
                    botonDibujarDia2.SetActive(true);
                    botonDormirClaseDia2.SetActive(true);
                    botonParticiparClaseDia2.SetActive(true);
                }
                break;
            case "Regresar":
               
                estado.felicidad += 15;
                break;
            case "Dormir":
              
                estado.felicidad += 15;
                break;
        }

        SiguienteDia();
    }

    public void TomarDecisionClase(string Escena)  // y asi pueden separarlo, pero tengan uno global y luego vayan 
    // cambiando de escena jugando con la camara y ns cuando elija estudiar q ahora salgan otros botones q le aparezcan estudiar dormir o socializar
    {
        switch (Escena)
        {
            case "estudiar":
              
                estado.felicidad -= 10;
                break;
            case "dormir":
               
                break;
            case "socializar":
                
                estado.felicidad += 10;
                break;
        }
        SiguienteDia();
    }

    void SiguienteDia()
    {
        estado.day++;
        MostrarEstado();
    }

    void MiniGame()
    {
        // Aquí iría su juego q ns esta en level 2
        // ns hare cualquier wea como minijuego xd
        int resultado = Random.Range(0, 2); // 0 o 1
        if (resultado == 1)
        {
            estado.felicidad += 10;
        }
        else
        {
            estado.felicidad -= 5;
        }

        SiguienteDia();
    }

    void MostrarEstado()
    {
        // esto mostrar los textos de la UI con el estado del juego, vi q querian al final poner como se sentia, podrian ponerlo al final tmbn lo puse al q termine el dia
        // y asi pueden agregar mas cosas al estado del juego, como esperanza, autocuidado, etc. depende q lo usen y todo eso.
        /*diaTexto.text = "Día: " + estado.day;
        energiaTexto.text = "Energía: " + estado.energia;
        felicidadTexto.text = "Felicidad: " + estado.felicidad;*/
    }
    void SubirSalud(int suma)
    {
        estado.felicidad += suma;
    }
    void BajarSalud(int resta)
    {
        estado.felicidad -= resta;
    }
    void UsarBoton (GameObject boton,GameObject boton2, GameObject boton3, GameObject boton4)
    {
        if (boton != null)
        {
            boton.SetActive(false);
        }
        if (boton2 != null)
        {
            boton2.SetActive(false);
        }
        if (boton3 != null)
        {
            boton3.SetActive(false);
        }
        if (boton4 != null)
        {
            boton4.SetActive(false);
        }        
    }
    void ChageScene(string NuevaEscena)
    {
        escena = NuevaEscena;
        TomarDecision(escena);
    }
    void BotonDormirClase1()
    {
        hasDormiidoClase1 = true;
    }
    void BotonHablarJoshua()
    {
        hasHabladoJoshua = true;
    }
    void BotonConocerJoshua()
    {
        hasConocidoJoshua = true;
    }
    void DibujoHecho()
    {
        dibujoHecho = true;
    }
    void BotonFinalJoshua(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
    }
    void BotonFinal(Scene finalMalo, Scene FinalBueno)
    {
        if (estado.felicidad <= 49)
        {
            SceneManager.LoadScene(finalMalo.name);
        }
        else
        {
            SceneManager.LoadScene(FinalBueno.name);
        }
    }
}
