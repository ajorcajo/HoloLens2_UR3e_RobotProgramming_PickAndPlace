using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.XR;

// HAND TRACKING PACKAGES
using MixedReality.Toolkit;
using MixedReality.Toolkit.Input;
using MixedReality.Toolkit.Subsystems;

using TMPro;
using System.Collections.Specialized;


public class PointsManagement : MonoBehaviour
{

    public string[] coordinates = new string[6] { "0.0", "0.0", "0.0", "0.0", "0.0", "0.0" };
    public static Vector3 targetpos = new Vector3();
    public Vector3 rot = new Vector3();
    public Quaternion newRotation = new Quaternion();
    public Vector3 eulerDegrees = new Vector3();
    public Vector3 eulerRadians = new Vector3();
    public Vector3 offsetpos = new Vector3();
    private static bool completed = false;

    //Pruebas
    public Vector3 real_rot_Degree = new Vector3();
    public Vector3 real_rot_Radian = new Vector3();

    // Robot Programation
    public GameObject PanelProgramation;

    // Pick and Place + HAND TRACKING VARIABLES
    public GameObject PickAndPlace;
    public GameObject RightHand;
    public GameObject LeftHand;
    private GameObject Hand;

    private HandsAggregatorSubsystem aggregator;

    public int case_pickandplace;
    public int activar_pinza;

    public GameObject Origin;
    public GameObject Origin_BaseRef;
    public GameObject Rastro;
    public Transform PointsParent;
    // -------------------- UTF8Encoding -------------------- //
    private UTF8Encoding utf8 = new UTF8Encoding();

    // Ejemplos de Puntos, para cogerlos como referencia y poder duplicarlos luego
    public GameObject MoveL_Point;
    public GameObject MoveJ_Point;
    public GameObject MoveP_Point;
    public GameObject Gripper_Point;

    // Objetos de representación en la tabla que tambien se van a duplicar
    public GameObject MoveL_Point_table;
    public GameObject MoveJ_Point_table;
    public GameObject MoveP_Point_table;
    public GameObject Gripper_Point_table;

    public Transform MoveL_Point_Pos;
    public Transform MoveJ_Point_Pos;
    public Transform MoveP_Point_Pos;
    public Transform tcp;

    // Contadores
    public int cont_points = 0;
    public int cont_timer = 0;
    public int cont = 1;
    public int aviso_type = 0;

    //TIPO CLASE PUNTO
    public class point
    {
        // Type is 0 = MoveL ; 1 = MoveJ ; 2 = MoveP
        public int type;
        public GameObject PointObject;
        public LineRenderer line;
    }

    public point[] Points;
    public int segments = 20;

    //public LineRenderer[] lineRenderer;
    //public GameObject[] lines;
    public Material lineMaterial;
    LineRenderer newline;

    public bool bandera_sendcommand;
    public bool gripper_state;
    public static bool gripper_action;
    public bool gripper_bandera;

    //Avisos
    public TextMeshProUGUI aviso;
    public GameObject avisos;

    // ¿Dentro de esfera?
    public GameObject esferaGrande;
    public GameObject esferaPequeña;
    public bool isInside = false;
    public float distancia = 0f;
    public float radioGrande = 0f;
    public float radioPequeña = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Ensure Points array is initialized
        Points = new point[0];
        AddToArray(Origin,0);
        inicio();
        bandera_sendcommand = false;
        gripper_state = true;
        completed = false;
        gripper_action = false;

        // HAND TRACKING VARIABLES
        aggregator = XRSubsystemHelpers.GetFirstRunningSubsystem<HandsAggregatorSubsystem>();
        case_pickandplace = 0;
        activar_pinza = 0;
    }

    void inicio()
    {
        // Ejemplos de Puntos
        MoveL_Point.SetActive(false);
        MoveJ_Point.SetActive(false);
        MoveP_Point.SetActive(false);
        Gripper_Point.SetActive(false);

        // Objetos de representación en la tabla
        MoveL_Point_table.SetActive(false);
        MoveJ_Point_table.SetActive(false);
        MoveP_Point_table.SetActive(false);
        Gripper_Point_table.SetActive(false);
    }
    public void createmoveL()
    {
        if (isInside == false)
        {
            aviso_type = 2;
        }
        else
        {
            if (cont_points < 15)
            {
                Vector3 newPosition = Points[cont_points - 1].PointObject.transform.position + new Vector3(0.2f, 0, -0.2f);
                GameObject newObject = Instantiate(MoveL_Point, newPosition, Points[cont_points - 1].PointObject.transform.rotation);
                AddToArray(newObject, 0);
                newObject.SetActive(true);
                newObject.transform.SetParent(PointsParent, false);
                newObject.transform.position = newPosition;

            }
            else
            {
                aviso_type = 1;
            }
        }
    }

    public void createmoveL_Pos(Vector3 delta)
    {
        if (isInside == false)
        {
            aviso_type = 2;
        }
        else
        {
            if (cont_points < 50)
            {
                Vector3 newPosition = Points[cont_points - 1].PointObject.transform.position + delta;
                GameObject newObject = Instantiate(MoveL_Point, newPosition, Points[cont_points - 1].PointObject.transform.rotation);
                AddToArray(newObject, 0);
                newObject.SetActive(true);
                newObject.transform.SetParent(PointsParent, false);
                newObject.transform.position = newPosition;

            }
            else
            {
                aviso_type = 1;
            }
        }
    }

    public void createmoveJ()
    {
        if (isInside == false)
        {
            aviso_type = 2;
        }
        else
        {
            if (cont_points < 15)
            {
                Vector3 newPosition = Points[cont_points - 1].PointObject.transform.position + new Vector3(0.2f, 0, -0.2f);
                GameObject newObject = Instantiate(MoveJ_Point, newPosition, Points[cont_points - 1].PointObject.transform.rotation);
                AddToArray(newObject, 1);
                newObject.SetActive(true);
                newObject.transform.SetParent(PointsParent, false);
                newObject.transform.position = newPosition;
            }
            else
            {
                aviso_type = 1;
            }
        }
    }
    public void createmoveP()
    {

        if (isInside == false)
        {
            aviso_type = 2;
        }
        else
        {
            if (cont_points < 15)
            {
                Vector3 newPosition = Points[cont_points - 1].PointObject.transform.position + new Vector3(0.2f, 0, -0.2f);
                GameObject newObject = Instantiate(MoveP_Point, newPosition, Points[cont_points - 1].PointObject.transform.rotation);
                AddToArray(newObject, 2);
                newObject.SetActive(true);
                newObject.transform.SetParent(PointsParent, false);
                newObject.transform.position = newPosition;
            }
            else
            {
                aviso_type = 1;
            }
        }
    }
    public void createGripper()
    {
        if(isInside == false)
        {
            aviso_type = 2;
        }
        else { if (cont_points < 15)
            {
                Vector3 newPosition = Points[cont_points - 1].PointObject.transform.position;
                GameObject newObject = Instantiate(Gripper_Point, newPosition, Points[cont_points - 1].PointObject.transform.rotation);
                AddToArray(newObject, 3);
                newObject.SetActive(true);
                newObject.transform.parent = Points[cont_points - 2].PointObject.transform;
                newObject.transform.position = newPosition;
            }
            else
            {
                aviso_type = 1;
            }
        }
    }


    void AddToArray(GameObject newObject, int typemovement)
    {
        // Crea un nuevo array con una longitud incrementada en 1
        point[] newArray = new point[Points.Length + 1];

        // Copia los elementos del array original al nuevo array
        for (int i = 0; i < Points.Length; i++)
        {
            newArray[i] = Points[i];
        }

        // Se añade el nuevo class punto (para inicializarlo)
        newArray[Points.Length] = new point();
        // Añade el nuevo objeto al final del nuevo array
        newArray[Points.Length].PointObject = newObject;
        newArray[Points.Length].line = newline;
        //Añade el linerenderer al objeto
        newArray[Points.Length].line = newArray[Points.Length].PointObject.AddComponent<LineRenderer>();

        // Configuración comun a todos los tipos de movimiento del LineRenderer
        newArray[Points.Length].line.material = lineMaterial;
        newArray[Points.Length].line.startWidth = 0.01f;
        newArray[Points.Length].line.endWidth = 0.01f;

        switch (typemovement)
        {
            case 0: //MOVEL
                newArray[Points.Length].type = 0;
                // Configurar el LineRenderer
                newArray[Points.Length].line.positionCount = 2; // Inicialmente sin puntos
                break;
            case 1: //MOVEJ
                newArray[Points.Length].type = 1;
                // Configurar el LineRenderer
                newArray[Points.Length].line.positionCount = segments;
                break;
            case 2: //MOVEP
                newArray[Points.Length].type = 2;
                // Configurar el LineRenderer
                newArray[Points.Length].line.positionCount = segments;
                break;
            case 3: //GRIPPER
                newArray[Points.Length].type = 3;
                break;
        }
        // Asigna el nuevo array al array original
        Points = newArray;
        cont_points++;
    }

    public void RemoveLastPoint()
    {
        // Verifica si el arreglo tiene al menos un elemento
        if (Points.Length > 1)
        {
            // Obtén la referencia al último elemento del arreglo
            point lastPoint = Points[Points.Length - 1];
            point BeforelastPoint = Points[Points.Length - 2];

            //BeforelastPoint.line.positionCount = 0;

            // Libera los recursos del LineRenderer
            if (lastPoint.line != null)
            {
                Destroy(lastPoint.line);
            }
            switch (BeforelastPoint.type)
            {
                case 0:
                    Vector3 start = new Vector3();
                    Vector3 end = new Vector3();
                    BeforelastPoint.line.SetPosition(0, start);
                    BeforelastPoint.line.SetPosition(1, end);
                    break;
                case 1:
                    for (int i = 0; i < segments; i++)
                    {
                        Vector3 cero = new Vector3();
                        BeforelastPoint.line.SetPosition(i, cero);
                    }
                    break;
                case 2:
                    for (int i = 0; i < segments; i++)
                    {
                        Vector3 cero = new Vector3();
                        BeforelastPoint.line.SetPosition(i, cero);
                    }
                    break;
                case 3:
                    break;
            }
           
            // Destruye el GameObject asociado
            if (lastPoint.PointObject != null)
            {
                Destroy(lastPoint.PointObject);
            }
            
            // Redimensiona el arreglo para excluir el último elemento
            System.Array.Resize(ref Points, Points.Length - 1);

            cont_points--;
        }
        else
        {
            UnityEngine.Debug.Log("There are no points placed!");
        }
    }

    public void CreatePickandPlace4Points()
    {
        case_pickandplace = 1;
        float altura = 0.1f;           // Movimiento vertical (subir/bajar)
        float desplazamiento = 0.3f;   // Movimiento horizontal entre pick y place

        // Guardamos el origen
        Vector3 origen = Points[0].PointObject.transform.position;

        // --- Punto 1: encima del punto de recogida ---
        createmoveL();
        Points[1].PointObject.transform.position = origen + Vector3.forward * desplazamiento + Vector3.up * altura;
        //Points[1].PointObject.SetActive(false);  // Punto oculto

        // --- Punto 2: punto de recogida ---
        createmoveL();
        Points[2].PointObject.transform.position = origen + Vector3.forward * desplazamiento;

        // --- Punto 3: cerrar gripper ---
        createGripper();
        Points[3].PointObject.transform.position = origen + Vector3.forward * desplazamiento;

        // --- Punto 4: subir con objeto ---
        createmoveL();
        Points[4].PointObject.transform.position = origen + Vector3.forward * desplazamiento + Vector3.up * altura;

        // --- Punto 5: mover al destino (horizontal derecha) ---
        createmoveL();
        Points[5].PointObject.transform.position = origen + Vector3.forward * desplazamiento + Vector3.right * desplazamiento + Vector3.up * altura;

        // --- Punto 6: bajar al destino ---
        createmoveL();
        Points[6].PointObject.transform.position = origen + Vector3.forward * desplazamiento + Vector3.right * desplazamiento;

        // --- Punto 7: abrir gripper ---
        createGripper();
        Points[7].PointObject.transform.position = origen + Vector3.forward * desplazamiento + Vector3.right * desplazamiento;

        // --- Punto 8: encima del punto de destino ---
        createmoveL();
            Points[8].PointObject.transform.position = Points[5].PointObject.transform.position;
        // --- Punto 9: volver al origen ---
        createmoveL();
        Points[9].PointObject.transform.position = origen;

    }
    public void StartHandTracking()
    {
        case_pickandplace = 2;
    }
    private GameObject trackedHand = null; // la mano que se está siguiendo
    private bool handDetected = false;
    private float handDetectedStartTime = 0f;
    private bool trackingActive = false;

    private Vector3 lastHandPosition;
    private float lastMoveLTime = 0f;
    private float waitDuration = 2.0f;
    private float intervalMoveL = 2.0f;



    // Update is called once per frame
    void Update()
    {
        // HAND TRACKING AND PICK AND PLACE CODE

        //Algoritmo pick and place
        switch (case_pickandplace)
        {
            case 1:
                // Punto 1 <- misma posición que Punto 4
                Points[1].PointObject.transform.position = Points[4].PointObject.transform.position;
                Points[1].PointObject.SetActive(false);

                // Punto 8 <- misma posición que Punto 5
                Points[8].PointObject.transform.position = Points[5].PointObject.transform.position;
                Points[8].PointObject.SetActive(false);

                break;
            case 2:
                // 1. Detectar mano derecha y mostrar su posición
                if (aggregator.TryGetJoint(TrackedHandJoint.Palm, XRNode.RightHand, out HandJointPose rightPalm))
                {
                    Hand = RightHand;
                }
                // 2. Detectar mano izquierda
                else
                {
                    if (aggregator.TryGetJoint(TrackedHandJoint.Palm, XRNode.LeftHand, out HandJointPose leftPalm))
                    {
                        Hand = LeftHand;
                    }
                    else
                    {
                        Hand = null;
                    }
                }
                
                // 2. Evaluar si hay mano visible
                if (Hand != null)
                {
                    if (!handDetected || trackedHand != Hand)
                    {
                        // Primera vez o cambio de mano -> reiniciar temporizador
                        handDetected = true;
                        handDetectedStartTime = Time.time;
                        trackedHand = Hand;
                        UnityEngine.Debug.Log("Empezando Cuenta hasta 2 segundos");
                    }
                    else
                    {
                        float timeHeld = Time.time - handDetectedStartTime;

                        if (!trackingActive && timeHeld >= waitDuration)
                        {
                            // Activar seguimiento
                            trackingActive = true;
                            lastHandPosition = Hand.transform.position;
                            lastMoveLTime = Time.time;
                            UnityEngine.Debug.Log("Seguimiento activado");
                        }
                    }
                }
                else
                {
                    // Mano no visible -> reset
                    if (handDetected || trackingActive)

                        UnityEngine.Debug.Log("Mano perdida. Reiniciando seguimiento.");

                    handDetected = false;
                    trackingActive = false;
                    trackedHand = null;
                }

                // 3. Si el seguimiento está activo -> aplicar traslación cada 0.5 s
                if (trackingActive && Time.time - lastMoveLTime >= intervalMoveL && Hand != null)
                {
                    Vector3 currentPosition = Hand.transform.position;
                    Vector3 delta = currentPosition - lastHandPosition;

                    lastHandPosition = currentPosition;
                    lastMoveLTime = Time.time;

                    createmoveL_Pos(delta);
                    UnityEngine.Debug.Log("Punto CREADOOO");
                }

                // 4. Detectar gesto de pinza solo si hay seguimiento activo y mano válida
                if (trackingActive && Hand != null)
                {
                    XRNode currentHandNode = Hand == RightHand ? XRNode.RightHand : XRNode.LeftHand;

                    if (aggregator.TryGetPinchProgress(currentHandNode, out bool isReadyToPinch, out bool isPinching, out float pinchAmount))
                    {
                        if (isPinching && activar_pinza == 0)
                        {
                            activar_pinza = 1;
                            createGripper();
                            UnityEngine.Debug.Log("Gesto de pinza detectado — Gripper activado");
                        }
                        else if (!isPinching)
                        {
                            activar_pinza = 0;
                        }
                    }
                    else
                    {
                        activar_pinza = 0;
                    }
                }


                break;
            case 3:

                break;
        }

        offsetpos.x = Math.Abs(targetpos.x - (float)ur_data_processing.UR_Stream_Data.C_Position[0]);
        offsetpos.y = Math.Abs(targetpos.y - (float)ur_data_processing.UR_Stream_Data.C_Position[1]);
        offsetpos.z = Math.Abs(targetpos.z - (float)ur_data_processing.UR_Stream_Data.C_Position[2]);


        gripper_bandera = gripper_action;


        /*
        //Pruebas
        // Aplicar la nueva rotación al objeto
        newRotation = Origin_BaseRef.transform.localRotation;
        // Rotación de 180 grados alrededor del eje Z
        //Quaternion inversionZ = Quaternion.Euler(0, 0, 180);

        // Nueva rotación con el eje Z invertido
        //newRotation = newRotation * inversionZ;
        // Convertir el quaternion a ángulos de Euler en grados
        eulerDegrees = newRotation.eulerAngles;
        // Convertir los ángulos de Euler de grados a radianes
        eulerRadians = eulerDegrees * Mathf.Deg2Rad;

        real_rot_Degree.x = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[0] * (180.0f / Math.PI));
        real_rot_Degree.y = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[1] * (180.0f / Math.PI));
        real_rot_Degree.z = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[2] * (180.0f / Math.PI));

        real_rot_Radian.x = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[0]);
        real_rot_Radian.y = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[1]);
        real_rot_Radian.z = (float)(ur_data_processing.UR_Stream_Data.C_Orientation[2] );
        //FIN PRuebas
        */
        if(Points[cont_points - 1].type != 3)
        {
            esferaPequeña = Points[cont_points - 1].PointObject;
        }
        // Obtén los radios de las esferas
        radioGrande = esferaGrande.transform.localScale.x / 2.0f;
        radioPequeña = esferaPequeña.transform.localScale.x / 2.0f;

        // Calcula la distancia entre los centros de las esferas
        distancia = Vector3.Distance(esferaGrande.transform.position, esferaPequeña.transform.position);

        // Comprueba si la esfera pequeña está dentro de la esfera grande
        if (distancia + radioPequeña > radioGrande)
        {
            isInside = false;
        }
        else
        {
            isInside = true;
        }

        if (isInside == false)
        {
            aviso_type = 2;
        }

        switch (aviso_type)
        {
            case 1:
                aviso.text = "Just 1 point movement supported!";
                break;
            case 2:
                aviso.text = "Out of range! Make sure is inside the large sphere";
                break;
            case 3:
                aviso.text = "No points? Out of range?";
                break;
        }

        cont_timer++;
        //tcp.position = tcpPosition;
        if (PanelProgramation.activeSelf || PickAndPlace.activeSelf)
        {
            Origin.SetActive(true);
        }
        else
        {
            Origin.SetActive(false);
        }

        if(cont_points > 0)
        {
            UpdateConnections();
        }
        
        if (bandera_sendcommand) {

            if (offsetpos.x < 0.001 && offsetpos.y < 0.001 && offsetpos.z < 0.001 && gripper_action == false)
            {
                cont++;

                // YOU NEED TO MAKE SURE THE BASE AXES REFERENCES OF THE ROBOT ARE THE SAME AS UNITY, FOR YOUR SECURITY
                RobotController controller = new RobotController(UIPanel_Control.global_ip_address, ur_data_processing.UR_Control_Data.port_number);

                if (Points[cont].type == 3)
                {
                    targetpos.x = Points[cont - 1].PointObject.transform.localPosition.x;
                    targetpos.y = Points[cont - 1].PointObject.transform.localPosition.y;
                    targetpos.z = -Points[cont - 1].PointObject.transform.localPosition.z;
                }
                else
                {
                    targetpos.x = Points[cont].PointObject.transform.localPosition.x;
                    targetpos.y = Points[cont].PointObject.transform.localPosition.y;
                    targetpos.z = -Points[cont].PointObject.transform.localPosition.z;
                }
               

                // Conversion of rotation axes
                // Aplicar la nueva rotación al objeto
                rot.x = (float)ur_data_processing.UR_Stream_Data.C_Orientation[0];
                rot.y = (float)ur_data_processing.UR_Stream_Data.C_Orientation[1];
                rot.z = (float)ur_data_processing.UR_Stream_Data.C_Orientation[2];



                coordinates[0] = targetpos.x.ToString("F4", CultureInfo.InvariantCulture);
                coordinates[1] = targetpos.y.ToString("F4", CultureInfo.InvariantCulture);
                coordinates[2] = targetpos.z.ToString("F4", CultureInfo.InvariantCulture);
                coordinates[3] = rot.x.ToString("F4", CultureInfo.InvariantCulture);
                coordinates[4] = rot.y.ToString("F4", CultureInfo.InvariantCulture);
                coordinates[5] = rot.z.ToString("F4", CultureInfo.InvariantCulture);


                switch (Points[cont].type)
                {
                    case 0: //MoveL
                        controller.SendCommandAsync("movel(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, t=0, r=0)" + "\n");
                        break;
                    case 1: //MoveJ
                        controller.SendCommandAsync("movej(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, t=0, r=0)" + "\n");
                        break;
                    case 2: //MoveP
                        controller.SendCommandAsync("movep(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, r=0)" + "\n");
                        break;
                    case 3: //Gripper
                        gripper_state = !gripper_state;
                        controller.SetDigitalOutputsAsync(gripper_state);
                        gripper_action = true;
                        break;
                }
            }

            if (cont == Points.Length - 1)
            {
                    UnityEngine.Debug.Log("Finished!!");
                    bandera_sendcommand = false;
                    cont = 1;
            }

            /*
            if (offsetpos.x < 0.001 && offsetpos.y < 0.001 && offsetpos.z < 0.001)
            {
                completed = true;
                // Block the code until the robot makes the movement
            }
            */
        }
    

    }

    public void UpdateConnections()
    {
        for (int j = 1; j < Points.Length; j++)
        {
            switch (Points[j].type)
            {
                case 0: //MoveL
                    UpdateLineForMoveL(Points[j - 1].line, Points[j - 1].PointObject.transform.position, Points[j].PointObject.transform.position);
                    break;
                case 1: //MoveJ
                    UpdateLineForMoveJ(Points[j - 1].line, Points[j - 1].PointObject.transform.position, Points[j].PointObject.transform.position);
                    break;
                case 2: //MoveP
                    UpdateLineForMoveP(Points[j - 1].line, Points[j - 1].PointObject.transform.position, Points[j].PointObject.transform.position);
                    break;
                case 3: //Gripper
                   //Nothing
                    break;
            }
        }

    }

    public void UpdateLineForMoveL(LineRenderer line, Vector3 start, Vector3 end)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }

    public void UpdateLineForMoveJ(LineRenderer line, Vector3 start, Vector3 end)
    {
        line.positionCount = segments;
        for (int i = 0; i < segments; i++)
        {
            float t = (float)i / (segments - 1);
            Vector3 position = InterpolateMoveJ(start, end, t);
            line.SetPosition(i, position);
        }
    }
    Vector3 InterpolateMoveJ(Vector3 start, Vector3 end, float t)
    {
        // Interpolación esférica (Slerp)
        return Vector3.Slerp(start, end, t);
    }

    public void UpdateLineForMoveP(LineRenderer line, Vector3 start, Vector3 end)
    {
        line.positionCount = segments;
        for (int i = 0; i < segments; i++)
        {
            float t = (float)i / (segments - 1);
            Vector3 position = InterpolateMoveP(start, end, t);
            line.SetPosition(i, position);
        }
    }
    Vector3 InterpolateMoveP(Vector3 start, Vector3 end, float t)
    {
        // Interpolación cúbica Hermite
        float t2 = t * t;
        float t3 = t2 * t;
        float h1 = 2 * t3 - 3 * t2 + 1;          // Hermite cubic interpolation basis function 1
        float h2 = -2 * t3 + 3 * t2;             // Hermite cubic interpolation basis function 2
        float h3 = t3 - 2 * t2 + t;              // Hermite cubic interpolation basis function 3
        float h4 = t3 - t2;                      // Hermite cubic interpolation basis function 4

        Vector3 interpolatedPoint = h1 * start + h2 * end;   // Interpolated point position
        Vector3 interpolatedDerivative = h3 * (end - start); // Interpolated derivative (velocity)

        // Return the interpolated position
        return interpolatedPoint;
    }

    public void sendcommand()
    {
        // YOU NEED TO MAKE SURE THE BASE AXES REFERENCES OF THE ROBOT ARE THE SAME AS UNITY, FOR YOUR SECURITY
        RobotController controller = new RobotController(UIPanel_Control.global_ip_address, ur_data_processing.UR_Control_Data.port_number);

        targetpos.x = Points[1].PointObject.transform.localPosition.x;
        targetpos.y = Points[1].PointObject.transform.localPosition.y;
        targetpos.z = -Points[1].PointObject.transform.localPosition.z;

        // Conversion of rotation axes
        // Aplicar la nueva rotación al objeto
        rot.x = (float)ur_data_processing.UR_Stream_Data.C_Orientation[0];
        rot.y = (float)ur_data_processing.UR_Stream_Data.C_Orientation[1];
        rot.z = (float)ur_data_processing.UR_Stream_Data.C_Orientation[2];



        coordinates[0] = targetpos.x.ToString("F4", CultureInfo.InvariantCulture);
        coordinates[1] = targetpos.y.ToString("F4", CultureInfo.InvariantCulture);
        coordinates[2] = targetpos.z.ToString("F4", CultureInfo.InvariantCulture);
        coordinates[3] = rot.x.ToString("F4", CultureInfo.InvariantCulture);
        coordinates[4] = rot.y.ToString("F4", CultureInfo.InvariantCulture);
        coordinates[5] = rot.z.ToString("F4", CultureInfo.InvariantCulture);

        offsetpos.x = Math.Abs(targetpos.x - (float)ur_data_processing.UR_Stream_Data.C_Position[0]);
        offsetpos.y = Math.Abs(targetpos.y - (float)ur_data_processing.UR_Stream_Data.C_Position[1]);
        offsetpos.z = Math.Abs(targetpos.z - (float)ur_data_processing.UR_Stream_Data.C_Position[2]);

        switch (Points[1].type)
        {
            case 0: //MoveL
                controller.SendCommandAsync("movel(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, t=0, r=0)" + "\n");
                break;
            case 1: //MoveJ
                controller.SendCommandAsync("movej(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, t=0, r=0)" + "\n");
                break;
            case 2: //MoveP
                controller.SendCommandAsync("movep(p[" + coordinates[0] + "," + coordinates[1] + "," + coordinates[2] + "," + coordinates[3] + "," + coordinates[4] + "," + coordinates[5] + "], a = 0.5, v=0.05, r=0)" + "\n");
                break;
            case 3: //Gripper
                gripper_state = !gripper_state;
                controller.SetDigitalOutputsAsync(gripper_state);
                break;
        }

        bandera_sendcommand = true;
    }

    public class RobotController
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public RobotController(string ipAddress, int port)
        {
            _client = new TcpClient();
            _client.Connect(ipAddress, port);
            _stream = _client.GetStream();
        }

        public async Task SendCommandAsync(string command)
        {
            byte[] commandBytes = Encoding.ASCII.GetBytes(command);
            await _stream.WriteAsync(commandBytes, 0, commandBytes.Length);
            UnityEngine.Debug.Log("Comando enviado: " + command);
            await Task.Delay(500); // Is to make sure that the target is changed before waiting for confirmation
            //  If this is not done, the target won´t change at time and WaitForConfirmationAsync() will be "ignored"

            //await WaitForConfirmationAsync();
        }

        private async Task WaitForConfirmationAsync()
        {

            while (completed == false)
            {
                // Block the code until the robot makes the movement
            }
            
        }

        public async Task SetDigitalOutputsAsync(bool gripperState)
        {
            string command = $"set_tool_digital_out({(gripperState ? "1" : "0")}, False)\n";
  
            await SendCommandAsync(command);
            await Task.Delay(500); // Pausa de medio segundo
            command = $"set_tool_digital_out({(gripperState ? "0" : "1")}, True)\n";
            await SendCommandAsync(command);
            await Task.Delay(1500);
            PointsManagement.gripper_action = false;

        }
    }

}

