using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIA : MonoBehaviour
{
    
    private int cambio;
    private string secuencia = "";

    public GameObject yo;

    public TextMeshPro myText;
    public TextMeshPro myText2;

    public Transform Impresora;

    public GameObject Previo;
    public GameObject Preguntas;
    public GameObject Plate_previo_preguntas;
    public GameObject PanelAux;
    public GameObject PanelTexto;

    public GameObject Extrusor;
    public GameObject Extrusor_rojo;
    public GameObject Plataforma;
    public GameObject Plataforma_rojo;
    public GameObject Correas;
    public GameObject Correas_rojo;


    // DEFINICION DE PANELES AUXILIARES, SOLUCIONADORES Y SOLUCIONES
    public GameObject Imagen1_1;
    public GameObject Imagen1_2;
    public GameObject Imagen1_3;
    public GameObject Imagen1_4;
    public GameObject Imagen1_5;
    public GameObject Imagen1_6;
    public GameObject Imagen1_7;

    public GameObject Imagen2_1;
    public GameObject Imagen2_2;
    public GameObject Imagen2_3;
    public GameObject Imagen2_4;
    public GameObject Imagen2_5;

    public GameObject Imagen3_1;
    public GameObject Imagen3_2;
    public GameObject Imagen3_3;
    public GameObject Imagen3_4;
    public GameObject Imagen3_5;

    public GameObject Imagen4_1;
    public GameObject Imagen4_2;
    public GameObject Imagen4_3;

    public GameObject Solucionador1_1;
    public GameObject Solucionador1_2;
    public GameObject Solucionador1_3;
    public GameObject Solucionador1_4;
    public GameObject Solucionador1_5;
    public GameObject Solucionador1_6;
    public GameObject Solucionador1_7;


    public GameObject Solucionador2_1;
    public GameObject Solucionador2_2;
    public GameObject Solucionador2_3;
    public GameObject Solucionador2_4;
    public GameObject Solucionador2_5;

    public GameObject Solucionador3_1;
    public GameObject Solucionador3_2;
    public GameObject Solucionador3_3;
    public GameObject Solucionador3_4;
    public GameObject Solucionador3_5;

    public GameObject Solucionador4_1;
    public GameObject Solucionador4_2;
    public GameObject Solucionador4_3;

    public GameObject solucion1;
    public GameObject solucion2;
    public GameObject solucion3;
    public GameObject solucion4;
    public GameObject solucion5;
    public GameObject solucion6;
    public GameObject solucion7;
    public GameObject solucion8;
    public GameObject solucion9;
    public GameObject solucion10;
    public GameObject solucion11;
    public GameObject solucion12;
    public GameObject solucion13;
    public GameObject solucion14;
    public GameObject solucion15;
    public GameObject solucion16;
    public GameObject solucion17;
    public GameObject solucion18;
    public GameObject solucion19;
    public GameObject solucion20;
    public GameObject solucion21;
    public GameObject solucion22;
    public GameObject solucion23;
    public GameObject solucion24;
    public GameObject solucion25;
    public GameObject solucion26;
    public GameObject solucion27;
    public GameObject solucion28;
    public GameObject solucion29;
    public GameObject solucion30;

    public void Comienzo()
    {
        yo.SetActive(false);
        PanelTexto.SetActive(true);
        PanelAux.SetActive(true);
        Previo.SetActive(true);
        Plate_previo_preguntas.SetActive(true);
        Preguntas.SetActive(false);
        
        solucion1.SetActive(false);
        solucion2.SetActive(false);
        solucion3.SetActive(false);
        solucion4.SetActive(false);
        solucion5.SetActive(false);
        solucion6.SetActive(false);
        solucion7.SetActive(false);
        solucion8.SetActive(false);
        solucion9.SetActive(false);
        solucion10.SetActive(false);
        solucion11.SetActive(false);
        solucion12.SetActive(false);
        solucion13.SetActive(false);
        solucion14.SetActive(false);
        solucion15.SetActive(false);
        solucion16.SetActive(false);
        solucion17.SetActive(false);
        solucion18.SetActive(false);
        solucion19.SetActive(false);
        solucion20.SetActive(false);
        solucion21.SetActive(false);
        solucion22.SetActive(false);
        solucion23.SetActive(false);
        solucion24.SetActive(false);
        solucion25.SetActive(false);
        solucion26.SetActive(false);
        solucion27.SetActive(false);
        solucion28.SetActive(false);
        solucion29.SetActive(false);
        solucion30.SetActive(false);

        Solucionador1_1.SetActive(false);
        Solucionador1_2.SetActive(false);
        Solucionador1_3.SetActive(false);
        Solucionador1_4.SetActive(false);
        Solucionador1_5.SetActive(false);
        Solucionador1_6.SetActive(false);
        Solucionador1_7.SetActive(false);

        Solucionador2_1.SetActive(false);
        Solucionador2_2.SetActive(false);
        Solucionador2_3.SetActive(false);
        Solucionador2_4.SetActive(false);
        Solucionador2_5.SetActive(false);

        Solucionador3_1.SetActive(false);
        Solucionador3_2.SetActive(false);
        Solucionador3_3.SetActive(false);
        Solucionador3_4.SetActive(false);
        Solucionador3_5.SetActive(false);

        Solucionador4_1.SetActive(false);
        Solucionador4_2.SetActive(false);
        Solucionador4_3.SetActive(false);

        quitarimagenes();
        secuencia = "0" ;
        SetMainTexture();
    }

    public void ComeToPrinter()
    {
        transform.position = new Vector3((float)(Impresora.position.x - 0.1), (float)(Impresora.position.y + 0.2), (float)(Impresora.position.z));
    }

    public void setSolucionador()
    {
        Previo.SetActive(false);
        Preguntas.SetActive(false);
        PanelAux.SetActive(false);
        Plate_previo_preguntas.SetActive(false);

    }

    public void setYes()
    {
            cambio = 1;
            secuencia = secuencia + "1";
    }

    public void setNo()
    {
            cambio = 1;
            secuencia = secuencia + "0";
        
    }
    
    public void setCambioArbolBinario(string value)
    {
        // Con esto nos quedamos solo con el primer carácter y aumentamos una unidad a dicho carácter
        secuencia = value;
        cambio = 1;
    }

    public void quitarimagenes()
    {
        Imagen1_1.SetActive(false);
        Imagen1_2.SetActive(false);
        Imagen1_3.SetActive(false);
        Imagen1_4.SetActive(false);
        Imagen1_5.SetActive(false);
        Imagen1_6.SetActive(false);
        Imagen1_7.SetActive(false);

        Imagen2_1.SetActive(false);
        Imagen2_2.SetActive(false);
        Imagen2_3.SetActive(false);
        Imagen2_4.SetActive(false);
        Imagen2_5.SetActive(false);

        Imagen3_1.SetActive(false);
        Imagen3_2.SetActive(false);
        Imagen3_3.SetActive(false);
        Imagen3_4.SetActive(false);
        Imagen3_5.SetActive(false);

        Imagen4_1.SetActive(false);
        Imagen4_2.SetActive(false);
        Imagen4_3.SetActive(false);
    }

    public void setPrevious()
    {
        if(secuencia == "1" || secuencia == "2" || secuencia == "3" || secuencia == "4")
        {
            Previo.SetActive(true);
            Preguntas.SetActive(false);
            PanelTexto.SetActive(true);
            PanelAux.SetActive(false);
            Plate_previo_preguntas.SetActive(true);

            Imagen1_1.SetActive(false);
            Imagen2_1.SetActive(false);
            Imagen3_1.SetActive(false);
            Imagen4_1.SetActive(false);
        }
        else
        {
            quitarimagenes();
            secuencia = secuencia.Remove(secuencia.Length - 1);
            cambio = 1;
            
            Previo.SetActive(false);
            Preguntas.SetActive(true);
            PanelAux.SetActive(true);
            Plate_previo_preguntas.SetActive(true);
        }
    }

    public void setPrevious_Sol()
    {
            cambio = 1;
    }

    public void ResaltarExtrusor()
    {
        Extrusor.SetActive(false);
        Extrusor_rojo.SetActive(true);
    }

    public void ResaltarPlataforma()
    {
        Plataforma.SetActive(false);
        Plataforma_rojo.SetActive(true);
    }

    public void ResaltarCorreas()
    {
        Correas.SetActive(false);
        Correas_rojo.SetActive(true);
    }

    public void SetMainTexture()
    {
        Extrusor.SetActive(true);
        Plataforma.SetActive(true);
        Correas.SetActive(true);
        Extrusor_rojo.SetActive(false);
        Plataforma_rojo.SetActive(false);
        Correas_rojo.SetActive(false);
    }

    public void AbrirSolucion(int solucion)
    {
        switch (solucion)
        {
            case 1:
                solucion1.SetActive(true);
                break;
            case 2:
                solucion2.SetActive(true);
                ResaltarExtrusor();
                ResaltarPlataforma();
                break;
            case 3:
                solucion3.SetActive(true);
                break;
            case 4:
                solucion4.SetActive(true);
                ResaltarPlataforma();
                break;
            case 5:
                solucion5.SetActive(true);
                break;
            case 6:
                solucion6.SetActive(true);
                break;
            case 7:
                solucion7.SetActive(true);
                break;
            case 8:
                solucion8.SetActive(true);
                break;
            case 9:
                solucion9.SetActive(true);
                break;
            case 10:
                solucion10.SetActive(true);
                ResaltarExtrusor();
                break;
            case 11:
                solucion11.SetActive(true);
                break;
            case 12:
                solucion12.SetActive(true);
                break;
            case 13:
                solucion13.SetActive(true);
                break;
            case 14:
                solucion14.SetActive(true);
                ResaltarExtrusor();
                break;
            case 15:
                solucion15.SetActive(true);
                break;
            case 16:
                solucion16.SetActive(true);
                break;
            case 17:
                solucion17.SetActive(true);
                ResaltarCorreas();
                break;
            case 18:
                solucion18.SetActive(true);
                ResaltarExtrusor();
                break;
            case 19:
                solucion19.SetActive(true);
                break;
            case 20:
                solucion22.SetActive(true);
                break;
            case 21:
                solucion29.SetActive(true);
                break;
            case 22:
                solucion22.SetActive(true);
                break;
            case 23:
                solucion23.SetActive(true);
                break;
            case 24:
                solucion24.SetActive(true);
                break;
            case 25:
                solucion25.SetActive(true);
                ResaltarExtrusor();
                break;
            case 26:
                solucion26.SetActive(true);
                break;
            case 27:
                solucion27.SetActive(true);
                break;
            case 28:
                solucion28.SetActive(true);
                break;
            case 29:
                solucion29.SetActive(true);
                break;
            case 30:
                solucion30.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( cambio == 1)
        {
            SetMainTexture();
            switch (secuencia)
            {
                case "0":
                    break;
                case "1":
                    myText.text = "¿Se te han creado pequeños hilos en la pieza?";
                    PanelAux.SetActive(true);
                    Imagen1_1.SetActive(true);
                    break;
                case "11":
                    // 1.1.	Generación de hilos (stringings)
                    setSolucionador();
                    Solucionador1_1.SetActive(true);
                    break;
                case "10":
                    myText.text = "¿La pieza tiene plástico sobrecalentado(como si se hubiese derretido)?";
                    PanelAux.SetActive(true);
                    Imagen1_1.SetActive(false);
                    Imagen1_2.SetActive(true);
                    break;
                case "101":
                    // 1.2.	Sobrecalentamiento
                    setSolucionador();
                    Solucionador1_2.SetActive(true);
                    break;
                case "100":
                    myText.text = "¿Tu pieza tiene el relleno débil?";
                    PanelAux.SetActive(true);
                    Imagen1_2.SetActive(false);
                    Imagen1_3.SetActive(true);
                    break;
                case "1001":
                    // 1.3.	Relleno débil 
                    setSolucionador();
                    Solucionador1_3.SetActive(true);
                    break;
                case "1000":
                    myText.text = "¿Tu pieza tiene huecos en las caras superiores?";
                    PanelAux.SetActive(true);
                    Imagen1_3.SetActive(false);
                    Imagen1_4.SetActive(true);
                    break;
                case "10001":
                    // 1.4.	Huecos en las caras superiores 
                    setSolucionador();
                    Solucionador1_4.SetActive(true);
                    break;
                case "10000":
                    myText.text = "¿Los pequeños detalles de la pieza no se han impreso?";
                    PanelAux.SetActive(true);
                    Imagen1_4.SetActive(false);
                    Imagen1_5.SetActive(true);
                    break;
                case "100001":
                    // 1.5.	Pequeños detalles no se imprimen
                    setSolucionador();
                    Solucionador1_5.SetActive(true);
                    break;
                case "100000":
                    myText.text = "¿Falta relleno en las paredes más finas?";
                    PanelAux.SetActive(true);
                    Imagen1_5.SetActive(false);
                    Imagen1_6.SetActive(true);
                    break;
                case "1000001":
                    // 1.6.	Falta de relleno en paredes finas
                    setSolucionador();
                    Solucionador1_6.SetActive(true);
                    break;
                case "1000000":
                    myText.text = "¿Hay espacios entre el relleno y los perímetros de la pieza?";
                    PanelAux.SetActive(true);
                    Imagen1_6.SetActive(false);
                    Imagen1_7.SetActive(true);
                    break;
                case "10000001":
                    // 1.7.	Espacios entre relleno y perímetros
                    setSolucionador();
                    Solucionador1_7.SetActive(true);
                    break;
                case "10000000":
                    Previo.SetActive(true);
                    myText2.text = "¡Prueba tomando otro camino!";
                    Preguntas.SetActive(false);
                    Imagen1_7.SetActive(false);
                    break;

                case "2":
                    myText.text = "¿La primera capa de impresión no se ha pegado?";
                    PanelAux.SetActive(true);
                    Imagen2_1.SetActive(true);
                    break;
                case "21":
                    // 2.1.	Primera capa no pega
                    setSolucionador();
                    Solucionador2_1.SetActive(true);
                    break;
                case "20":
                    myText.text = "¿Tienes algún problema de relleno?";
                    PanelAux.SetActive(true);
                    Imagen2_1.SetActive(false);
                    Imagen2_2.SetActive(true);
                    break;
                case "201":
                    // 2.2.
                    setSolucionador();
                    Solucionador2_2.SetActive(true);
                    break;
                case "200":
                    myText.text = "¿Se te han desplazado las capas de la pieza?";
                    PanelAux.SetActive(true);
                    Imagen2_2.SetActive(false);
                    Imagen2_3.SetActive(true);
                    break;
                case "2001":
                    // 2.3.
                    setSolucionador();
                    Solucionador2_3.SetActive(true);
                    break;
                case "2000":
                    myText.text = "¿Hay separación de capas en tu pieza?";
                    PanelAux.SetActive(true);
                    Imagen2_3.SetActive(false);
                    Imagen2_4.SetActive(true);
                    break;
                case "20001":
                    // 2.4.	
                    setSolucionador();
                    Solucionador2_4.SetActive(true);
                    break;
                case "20000":
                    myText.text = "¿Hay grietas en la primera capa?";
                    PanelAux.SetActive(true);
                    Imagen2_4.SetActive(false);
                    Imagen2_5.SetActive(true);
                    break;
                case "200001":
                    // 2.5.	
                    setSolucionador();
                    Solucionador2_5.SetActive(true);
                    break;
                case "200000":
                    Previo.SetActive(true);
                    myText2.text = "¡Prueba tomando otro camino!";
                    Preguntas.SetActive(false);
                    Imagen2_5.SetActive(false);
                    break;
                case "3":
                    myText.text = "¿La primera capa de impresión no se ha pegado?";
                    PanelAux.SetActive(true);
                    Imagen3_1.SetActive(true);
                    break;
                case "31":
                    // 3.1.	Primera capa no pega
                    setSolucionador();
                    Solucionador3_1.SetActive(true);
                    break;
                case "30":
                    myText.text = "¿Tienes el filamento mordido/desgastado?";
                    PanelAux.SetActive(true);
                    Imagen3_1.SetActive(false);
                    Imagen3_2.SetActive(true);
                    break;
                case "301":
                    // 3.2.
                    setSolucionador();
                    Solucionador3_2.SetActive(true);
                    break;
                case "300":
                    myText.text = "¿La pieza se despega de la base? (Warping)";
                    PanelAux.SetActive(true);
                    Imagen3_2.SetActive(false);
                    Imagen3_3.SetActive(true);
                    break;
                case "3001":
                    // 3.3.
                    setSolucionador();
                    Solucionador3_3.SetActive(true);
                    break;
                case "3000":
                    myText.text = "¿No extruye al iniciar la impresión?";
                    PanelAux.SetActive(true);
                    Imagen3_3.SetActive(false);
                    Imagen3_4.SetActive(true);
                    break;
                case "30001":
                    // 3.4.	
                    setSolucionador();
                    Solucionador3_4.SetActive(true);
                    break;
                case "30000":
                    myText.text = "¿Hay grietas en la primera capa?";
                    PanelAux.SetActive(true);
                    Imagen3_4.SetActive(false);
                    Imagen3_5.SetActive(true);
                    break;
                case "300001":
                    // 3.5.	
                    setSolucionador();
                    Solucionador3_5.SetActive(true);
                    break;
                case "300000":
                    Previo.SetActive(true);
                    myText2.text = "¡Prueba tomando otro camino!";
                    Preguntas.SetActive(false);
                    Imagen3_5.SetActive(false);
                    break;

                case "4":
                    myText.text = "¿Se ha interrumpido la extrusión durante la impresión?";
                    PanelAux.SetActive(true);
                    Imagen4_1.SetActive(true);
                    break;
                case "41":
                    // 4.1.	La extrusión se interrumpe durante la imrpesión
                    setSolucionador();
                    Solucionador4_1.SetActive(true);
                    break;
                case "40":
                    myText.text = "¿No extruye al iniciar la impresión?";
                    PanelAux.SetActive(true);
                    Imagen4_1.SetActive(false);
                    Imagen4_2.SetActive(true);
                    break;
                case "401":
                    // 4.2.
                    setSolucionador();
                    Solucionador4_2.SetActive(true);
                    break;
                case "400":
                    myText.text = "¿El extrusor se ha obturado?";
                    PanelAux.SetActive(true);
                    Imagen4_2.SetActive(false);
                    Imagen4_3.SetActive(true);
                    break;
                case "4001":
                    // 4.3.
                    setSolucionador();
                    Solucionador4_3.SetActive(true);
                    break;
                case "4000":
                    Previo.SetActive(true);
                    myText2.text = "¡Prueba tomando otro camino!";
                    Preguntas.SetActive(false);
                    Imagen4_3.SetActive(false);
                    break;
            }
            cambio = 0;
        }

    }
}
