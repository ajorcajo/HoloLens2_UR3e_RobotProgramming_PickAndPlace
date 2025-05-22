using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Globalization;

using UnityEngine.UI;
using UnityEngine;

using TMPro;

public class UIPanel_Control : MonoBehaviour
{
    // Variables para mover robot
    // Bandera para saber cuando se utiliza un joystick
    bool bandera_index;
    public int cont = 0;
    // -------------------- String -------------------- //
    public float velocity = 0.05f;
    public float acceleration = 1.0f;
    public string time = "0.05";
    public string[] speed_param = new string[6] { "0.0", "0.0", "0.0", "0.0", "0.0", "0.0" };
    public string[] speed_param_null = new string[6] { "0.0", "0.0", "0.0", "0.0", "0.0", "0.0" };

    // -------------------- UTF8Encoding -------------------- //
    private UTF8Encoding utf8 = new UTF8Encoding();


    // Declaracion de variables orientado a objetos
    public Transform Camera;
    public Transform UIPanel;

    public GameObject MainPanel;

    public GameObject ConnectionPanel;
    public GameObject DiagnosticPanel;
    public GameObject JoystickPanel;
    public GameObject PanelMuestreo;
    public GameObject ProgramationPanel;

    public GameObject RastroPosReal;

    public Transform ConnectionPanel_t;

    public GameObject robot;


    //Declaración de variables auxiliares
    float rotationSpeed = 30f;
    public bool bandera_muestreo = false;

    public TMP_InputField ip_address_txt;
    public static string global_ip_address;

    public TextMeshProUGUI position_x_txt, position_y_txt, position_z_txt;
    public TextMeshProUGUI position_rx_txt, position_ry_txt, position_rz_txt;
    public TextMeshProUGUI position_j1_txt, position_j2_txt, position_j3_txt;
    public TextMeshProUGUI position_j4_txt, position_j5_txt, position_j6_txt;
    public TextMeshPro connectionInfo_color;
    public TextMeshProUGUI velocity_label, acceleration_label;


    // Start is called before the first frame update
    void Start()
    {
        inicio();
        bandera_muestreo = false;
        bandera_index = false;

        robot.SetActive(true);

        //ConnectionPanel.transform.position = new Vector3(0, 0, 0);
        //DiagnosticPanel.transform.position = new Vector3(0, 0, 0);
        //JoystickPanel.transform.position = new Vector3(0, 0, 0);

        // Position {Cartesian} -> X..Z
        position_x_txt.text = "0.00";
        position_y_txt.text = "0.00";
        position_z_txt.text = "0.00";
        // Position {Rotation} -> EulerAngles(RX..RZ)
        position_rx_txt.text = "0.00";
        position_ry_txt.text = "0.00";
        position_rz_txt.text = "0.00";
        // Position Joint -> 1 - 6
        position_j1_txt.text = "0.00";
        position_j2_txt.text = "0.00";
        position_j3_txt.text = "0.00";
        position_j4_txt.text = "0.00";
        position_j5_txt.text = "0.00";
        position_j6_txt.text = "0.00";

        // red color
        connectionInfo_color.color = new Color32(255, 0, 48, 50);
        ip_address_txt.text = "169.254.12.28";
        global_ip_address = ip_address_txt.text;
    }

    public void inicio()
    {
        ConnectionPanel.SetActive(false);
        DiagnosticPanel.SetActive(false);
        JoystickPanel.SetActive(false);
        PanelMuestreo.SetActive(false);
        ProgramationPanel.SetActive(false);
    }

    public void popup(GameObject Panel)
    {
        Panel.SetActive(true);
        //Panel.transform.localPosition= new Vector3((float)(Camera.position.x), (float)(Camera.position.y), (float)(Camera.position.z));
        closeResto(Panel);

        Vector3 positionInFrontOfCamera = Camera.transform.position + Camera.transform.forward * 0.8f; // Ajusta la distancia según necesites

        // Asignamos la nueva posición al objeto
        Panel.transform.position = positionInFrontOfCamera;
        closeResto(Panel);
    }

    public void close(GameObject Panel)
    {
        Panel.SetActive(false);
    }

    void closeResto(GameObject Panel)
    {
        if(Panel == ConnectionPanel)
        {
            DiagnosticPanel.SetActive(false);
            JoystickPanel.SetActive(false);
            PanelMuestreo.SetActive(false);
            ProgramationPanel.SetActive(false);
        }
        if (Panel == DiagnosticPanel)
        {
            ConnectionPanel.SetActive(false);
            JoystickPanel.SetActive(false);
            PanelMuestreo.SetActive(false);
            ProgramationPanel.SetActive(false);
        }
        if (Panel == JoystickPanel)
        {
            ConnectionPanel.SetActive(false);
            DiagnosticPanel.SetActive(false);
            PanelMuestreo.SetActive(false);
            ProgramationPanel.SetActive(false);
        }
        if (Panel == PanelMuestreo)
        {
            ConnectionPanel.SetActive(false);
            DiagnosticPanel.SetActive(false);
            JoystickPanel.SetActive(false);
            ProgramationPanel.SetActive(false);
        }
        if (Panel == ProgramationPanel)
        {
            ConnectionPanel.SetActive(false);
            DiagnosticPanel.SetActive(false);
            JoystickPanel.SetActive(false);
            PanelMuestreo.SetActive(false);
        }
    }

    public void muestrea()
    {
        bandera_muestreo = !bandera_muestreo;
        robot.SetActive(true);
    }

    public void Connect_Activate()
    {
        ur_data_processing.GlobalVariables_Main_Control.connect = true;
        ur_data_processing.GlobalVariables_Main_Control.disconnect = false;
    }

    public void Disconnect_Activate()
    {
        ur_data_processing.GlobalVariables_Main_Control.connect    = false;
        ur_data_processing.GlobalVariables_Main_Control.disconnect = true;
    }

    public void MoverRobot(int index)
    {
        switch (index)
        {
            case 0:
                speed_param[0] = velocity_label.text;
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 1:
                speed_param[0] = "-" + velocity_label.text;
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 2:
                speed_param[0] = "0.0";
                speed_param[1] = velocity_label.text;
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 3:
                speed_param[0] = "0.0";
                speed_param[1] = "-" + velocity_label.text;
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 4:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = velocity_label.text;
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 5:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "-" + velocity_label.text; 
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 6:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = velocity_label.text;
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 7:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "-" + velocity_label.text; 
                speed_param[4] = "0.0";
                speed_param[5] = "0.0";
                break;
            case 8:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = velocity_label.text;
                speed_param[5] = "0.0";
                break;
            case 9:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "-" + velocity_label.text; 
                speed_param[5] = "0.0";
                break;
            case 10:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = velocity_label.text;
                break;
            case 11:
                speed_param[0] = "0.0";
                speed_param[1] = "0.0";
                speed_param[2] = "0.0";
                speed_param[3] = "0.0";
                speed_param[4] = "0.0";
                speed_param[5] = "-" + velocity_label.text; 
                break;

        }
        bandera_index = true;
        // create auxiliary command string for speed control UR robot
        ur_data_processing.UR_Control_Data.aux_command_str = "speedl([" + speed_param[0] + "," + speed_param[1] + "," + speed_param[2] + "," + speed_param[3] + "," + speed_param[4] + "," + speed_param[5] + "], a =" + acceleration_label.text + ", t =" + time + ")" + "\n";
        Debug.Log("Se ha mandado:" + ur_data_processing.UR_Control_Data.aux_command_str);
        // get bytes from command string
        ur_data_processing.UR_Control_Data.command = utf8.GetBytes(ur_data_processing.UR_Control_Data.aux_command_str);
        // confirmation variable -> is pressed
        ur_data_processing.UR_Control_Data.button_pressed[index] = true;

    }

    public void sum_velocity(bool type)
    {
        if (type)
        {
            velocity = velocity + 0.05f;
        }
        else
        { 
            velocity = velocity - 0.05f;
            if (velocity < 0.00f)
            {
                velocity = 0.00f;
            }
        }
    }
    public void sum_acceleration(bool type)
    {
        if (type)
        {
            acceleration = acceleration + 0.05f;
        }
        else
        {
            acceleration = acceleration - 0.05f;

            if (acceleration < 0.00f)
            {
                acceleration = 0.00f;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Utilización de joystick, mantener siempre desactivado el movimiento, a no ser que se pulse un botón
        if(bandera_index == false)
        {
            ur_data_processing.UR_Control_Data.button_pressed[0] = false;
            ur_data_processing.UR_Control_Data.button_pressed[1] = false;
            ur_data_processing.UR_Control_Data.button_pressed[2] = false;
            ur_data_processing.UR_Control_Data.button_pressed[3] = false;
            ur_data_processing.UR_Control_Data.button_pressed[4] = false;
            ur_data_processing.UR_Control_Data.button_pressed[5] = false;
            ur_data_processing.UR_Control_Data.button_pressed[6] = false;
            ur_data_processing.UR_Control_Data.button_pressed[7] = false;
            ur_data_processing.UR_Control_Data.button_pressed[8] = false;
            ur_data_processing.UR_Control_Data.button_pressed[9] = false;
            ur_data_processing.UR_Control_Data.button_pressed[10] = false;
            ur_data_processing.UR_Control_Data.button_pressed[11] = false;
            cont = 0;
        }

        if (bandera_index == true)
        {
                bandera_index = false;
        }

        //---------------------------------------BOTONES CONTROL PANEL---------------------------------------------//

        // ur_data_processing.UR_Control_Data.button_pressed[index] = false;

        //---------------------------------------------------------------------------------------------------------//

        // Robot IP Address (Read) -> TCP/IP 
        ur_data_processing.UR_Stream_Data.ip_address = ip_address_txt.text;
        // Robot IP Address (Write) -> TCP/IP 
        ur_data_processing.UR_Control_Data.ip_address = ip_address_txt.text;

        // If the button (connect/disconnect) is pressed, change the color and text
        if (ur_data_processing.GlobalVariables_Main_Control.connect == true)
        {
            // green color
            connectionInfo_color.color = new Color32(135, 255, 0, 50);
        }
        else if (ur_data_processing.GlobalVariables_Main_Control.disconnect == true)
        {
            // red color
            connectionInfo_color.color = new Color32(255, 0, 48, 50);
        }

        // ------------------------ Cyclic read parameters {diagnostic panel} ------------------------ //
        // Position {Cartesian} -> X..Z
        position_x_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Position[0] * (1000f), 2)).ToString();
        position_y_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Position[1] * (1000f), 2)).ToString();
        position_z_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Position[2] * (1000f), 2)).ToString();
        // Position {Rotation} -> EulerAngles(RX..RZ)
        position_rx_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Orientation[0] * (180 / Math.PI), 2)).ToString();
        position_ry_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Orientation[1] * (180 / Math.PI), 2)).ToString();
        position_rz_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.C_Orientation[2] * (180 / Math.PI), 2)).ToString();
        // Position Joint -> 1 - 6
        position_j3_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[0] * (180 / Math.PI), 2)).ToString();
        position_j1_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[1] * (180 / Math.PI), 2)).ToString();
        position_j2_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[2] * (180 / Math.PI), 2)).ToString();
        position_j4_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[3] * (180 / Math.PI), 2)).ToString();
        position_j5_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[4] * (180 / Math.PI), 2)).ToString();
        position_j6_txt.text = ((float)Math.Round(ur_data_processing.UR_Stream_Data.J_Orientation[5] * (180 / Math.PI), 2)).ToString();

        if (bandera_muestreo == true)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            robot.transform.Rotate(Vector3.up, rotationAmount);
        }

        if (PanelMuestreo.activeSelf)
        {
            robot.SetActive(true);
        }
        else
        {
            robot.SetActive(false);
        }

        if (ProgramationPanel.activeSelf)
        {
            RastroPosReal.SetActive(true);
        }
        else
        {
            RastroPosReal.SetActive(false);
        }

        velocity_label.text = velocity.ToString("F2", CultureInfo.InvariantCulture);
        acceleration_label.text = acceleration.ToString("F2", CultureInfo.InvariantCulture);

    }
}
