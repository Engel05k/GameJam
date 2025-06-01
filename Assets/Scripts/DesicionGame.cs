using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesicionGame : MonoBehaviour
{   
    [SerializeField] string escena;   

    /*[SerializeField] Image Alarma;
    [SerializeField] Image BusSolo;
    [SerializeField] Image BusJoshua;
    [SerializeField] Image clase;
    [SerializeField] Image regresoBus;
    [SerializeField] Image salidaFinalJoshua;
    [SerializeField] Image YaEnCasa;*/

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
    [SerializeField] private GameObject botonHablarConJoshua;
    [Header("En clase")]
    [SerializeField] private GameObject botonParticipar;
    [SerializeField] private GameObject botonSalirteDeLaClase;
    [Header("Regreso Bus")]
    [SerializeField] private GameObject botonSalirConJoshua;
    [SerializeField] private GameObject botonDormirTodoCamino;    
     


    static private bool dibujoHecho = false;   
    static private bool hasDormidoClase1 = false;      
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
                    //solo
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
            case "Ida b us":
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
                    //pensarvida
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
                    if (hasDormidoClase1 == false)
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
                        //true
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
    public void addScene()
    {
        if (StatsScript.scene < 5)
        {
            StatsScript.scene += 1;
        }
        else
        {
            StatsScript.scene = 1;
        }
    }
    public void SubirSalud(int suma)
    {
        StatsScript.felicidad += suma;
    }
    public void ChangeDay()
    {
        StatsScript.day++;
    }    
    public void BajarSalud(int resta)
    {
        StatsScript.felicidad -= resta;
    }
    public void UsarBoton (GameObject boton)
    {
        if (boton != null)
        {
            boton.SetActive(false);
        }
        gameObject.SetActive(false);
    }
    public void ChageScene(string NuevaEscena)
    {
        escena = NuevaEscena;
        TomarDecision(escena);
    }
    public void BotonDormirClase1()
    {
        hasDormidoClase1 = true;
    }
    public void BotonHablarJoshua()
    {
        hasHabladoJoshuaBus = true;
    }
    public void BotonConocerJoshua()
    {
        hasConocidoJoshua = true;
    }
    public void BotonEscribirJoshua()
    {
        hasEscritoJoshua = true;
    }
    public void DibujoHecho()
    {
        dibujoHecho = true;
    }
    public void BotonCambiarEscenaGrande(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void BotonFinal(Scene finalMalo)
    {
        if (StatsScript.felicidad <= 49)
        {
            SceneManager.LoadScene(finalMalo.name);
        }
        else
        {
            //agregar Scena final bueno
        }        
    }

    public void PreguntaRandom()
    {
        int ram = Random.Range(0, 11);
        if (ram <= 4)
        {
            StatsScript.felicidad += 5;
        }
        else
        {
            StatsScript.felicidad -= 5;
        }
    }
}
