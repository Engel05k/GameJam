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
    [SerializeField] private GameObject botonPosponer;
    [Header("Ida Bus")]
    [SerializeField] private GameObject botonEscucharMusica;
    [SerializeField] private GameObject botonIdaMirarVentana;
    [SerializeField] private GameObject botonDormir;
    [Header("En clase")]
    [SerializeField] private GameObject botonDibujarDia2;
    [SerializeField] private GameObject botonParticiparClaseDia2;
    [SerializeField] private GameObject botonDormirClaseDia2;   
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
     


    static private bool dibujoHecho = false;   
    static private bool hasDormiidoClase1 = false;      
    static bool hasConocidoJoshua = false;
    static private bool hasHabladoJoshuaBus = false;  
    static private bool hasEscritoJoshua = false;      
    
    void Start()
    {
        TomarDecision(escena);
    }

    public void TomarDecision(string Escena)
    {
        switch (Escena)
        {
            case "Alarma":
                if (StatsScript.day == 2)
                {
                    botonLevantarse.SetActive(true);
                    botonPosponer.SetActive(true);
                }
                else if (StatsScript.day == 3)
                {
                    botonRevisarCelular.SetActive(true);
                    botonLevantarse.SetActive(true);
                }
                else if (StatsScript.day == 4)
                {
                    botonRevisarCelular.SetActive(true);
                    botonLevantarse.SetActive(true);
                    if (hasConocidoJoshua && hasHabladoJoshuaBus)
                    {
                        //tercer bool
                        botonEscribirleJoshua.SetActive(true);
                    }
                }
                break;
            case "Ida Bus":
                if (StatsScript.day == 2)
                {
                    botonEscucharMusica.SetActive(true);
                    botonDormirTodoCamino.SetActive(true);
                }
                else if (StatsScript.day == 3)
                {
                    botonHacerteElDormido.SetActive(true);
                    //primer bool
                    botonSaludarJoshua.SetActive(true);
                }
                else if (StatsScript.day == 4)
                {
                    botonDormirTodoCamino.SetActive(true);
                    if (hasConocidoJoshua && hasHabladoJoshuaBus && hasEscritoJoshua)
                    {
                        //final Bueno
                        botonSalirConJoshua.SetActive(true);
                    }
                    botonPensarVida.SetActive(true);
                }
            break;
            case "En clase":
                if (StatsScript.day == 2)
                {
                    botonDibujarDia2.SetActive(true);
                    botonDormirClaseDia2.SetActive(true);
                    botonParticiparClaseDia2.SetActive(true);
                }
                else if (StatsScript.day == 3)
                {
                    if (hasDormiidoClase1 == false)
                    {
                        botonParticiparClaseDia3.SetActive(true);
                    }                    
                    if (dibujoHecho)
                    {
                        botonPracticarDibujoDia3.SetActive(true);
                    }
                    //neutro
                    botonAtenderClase.SetActive(true);
                } 
                else if (StatsScript.day == 4)
                {
                    botonSalirteDeLaClase.SetActive(true);
                    botonAtenderClase.SetActive(true);                    
                }
            break;
            case "Regresar bus":
                if (StatsScript.day == 2)
                {
                    botonEscucharMusica.SetActive(true);                    
                    botonDormirTodoCamino.SetActive(true);
                }
                else if (StatsScript.day == 3)
                {
                    if (hasConocidoJoshua)
                    {
                        //segundo bool
                        botonEscribirleJoshua.SetActive(true);
                    }
                    botonDormirTodoCamino.SetActive(true);
                    botonEscucharMusica.SetActive(true);
                }
                else if (StatsScript.day == 4)
                {
                    if (hasConocidoJoshua && hasHabladoJoshuaBus && hasEscritoJoshua)
                    {
                        botonSalirConJoshua.SetActive(true);
                    }
                    botonDormirTodoCamino.SetActive(true);
                }


             break;
            case "Casa":
                if (StatsScript.day == 2)
                {
                    botonEscribirDiario.SetActive(true);
                    botonIgnorarDiario.SetActive(true);
                }
                else if (StatsScript.day == 3)
                {
                   botonIgnorarDiario.SetActive(true) ;
                   botonEscribirDiario.SetActive(true);
                }
                else if (StatsScript.day == 4)
                {
                    botonEscribirDiario.SetActive(true);
                    botonIgnorarDiario.SetActive(true);
                }
            break;
        }

       
    }          
    void SubirSalud(int suma)
    {
        StatsScript.felicidad += suma;
    }
    void BajarSalud(int resta)
    {
        StatsScript.felicidad -= resta;
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
        hasHabladoJoshuaBus = true;
    }
    void BotonConocerJoshua()
    {
        hasConocidoJoshua = true;
    }
    void BotonEscribirJoshua()
    {
        hasEscritoJoshua = true;
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
        if (StatsScript.felicidad <= 49)
        {
            SceneManager.LoadScene(finalMalo.name);
        }
        else
        {
            SceneManager.LoadScene(FinalBueno.name);
        }
    }
}
