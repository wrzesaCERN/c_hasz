using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    Animator animHum;

    public GameObject niewolnik;
    public GameObject kitku;

    private bool nieswiadomy_czlek;
    public float distance = 10;
    void Start()
    {
        nieswiadomy_czlek = true;
        animHum = GetComponent<Animator>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        System.Random rnd = new System.Random();
        int liczba = rnd.Next(0, 3);

        if(LevelControl.Level == 1)
        {
            animHum.speed = 1;
        }
        else if (LevelControl.Level == 2)
        {
            animHum.speed = (float)1.5;
        }
        else
        {
            animHum.speed = 2;
        }

        distance = Vector3.Distance(niewolnik.transform.position, kitku.transform.position);

        if (distance < 0.8)
        {
            nieswiadomy_czlek = false; // człowiek zaczyna iść w stronę kitku. Namierzył go. 
            if (distance < 0.5) // cofnięcie człowieka po zabraniu życia kitku, aby znowu mu nie zabrał 
            {
                if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.back))
                {
                     transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, transform.GetComponent<Rigidbody>().position.y,(float)(transform.GetComponent<Rigidbody>().position.z + 0.5));
                }
                else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.forward))
                {
                     transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, transform.GetComponent<Rigidbody>().position.y, (float)(transform.GetComponent<Rigidbody>().position.z - 0.5));
                }
                else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.left))
                {
                     transform.GetComponent<Rigidbody>().position = new Vector3((float)(transform.GetComponent<Rigidbody>().position.x + 0.5), transform.GetComponent<Rigidbody>().position.y, transform.GetComponent<Rigidbody>().position.z);
                }
                else if (transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.right))
                {
                     transform.GetComponent<Rigidbody>().position = new Vector3((float)(transform.GetComponent<Rigidbody>().position.x - 0.5), transform.GetComponent<Rigidbody>().position.y, transform.GetComponent<Rigidbody>().position.z);
                }
                nieswiadomy_czlek = true;
            }
        }

        if (nieswiadomy_czlek == true)// ta sobie chodzi człowkiek kiedy nie widzi kitku
        {

            if (transform.GetComponent<Rigidbody>().position.z > -8.5)
            {
                transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, (float)1.05, (float)-8.5);
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.VelocityChange);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            }

            if (transform.GetComponent<Rigidbody>().position.z < -11.7)
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1), ForceMode.VelocityChange);
                transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, (float)1.05, (float)-11.7);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            }


            if (transform.GetComponent<Rigidbody>().position.x < -1.2)
            {

                transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.VelocityChange);
                transform.GetComponent<Rigidbody>().position = new Vector3((float)-1.2, (float)1.05, transform.GetComponent<Rigidbody>().position.z);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            }


            if (transform.GetComponent<Rigidbody>().position.x > 0.95)
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.VelocityChange);
                transform.GetComponent<Rigidbody>().position = new Vector3((float)0.95, (float)1.05, transform.GetComponent<Rigidbody>().position.z);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
            }


            /*
            if (transform.GetComponent<Rigidbody>().position.z > -9.5 && transform.GetComponent<Rigidbody>().position.x < -0.6 && transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.left))
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.VelocityChange);
                transform.GetComponent<Rigidbody>().position = new Vector3((float)-0.6, (float)1.05, (float)transform.GetComponent<Rigidbody>().position.z);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            }

            if (transform.GetComponent<Rigidbody>().position.z > -9.5 && transform.GetComponent<Rigidbody>().position.x < -0.6 && transform.GetComponent<Rigidbody>().rotation == Quaternion.LookRotation(Vector3.forward))
            {
                transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.VelocityChange);
                transform.GetComponent<Rigidbody>().position = new Vector3(transform.GetComponent<Rigidbody>().position.x, (float)1.05, (float)-9.5);
                if (liczba == 1)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                else if (liczba == 2)
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                else
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
            }

    */
        }

        else// tak sobie chodzi człowiek kiedy widzi kitku 
        {
            Vector3 kitku_gdzie_ty = kitku.transform.position;
            Vector3 ludziu_gdzie_ty = niewolnik.transform.position;

            float x_kitku = kitku_gdzie_ty.x;
            float z_kitku = kitku_gdzie_ty.z;
            float x_niewolnik = ludziu_gdzie_ty.x;
            float z_niewolnik = ludziu_gdzie_ty.z;
            float d_x = (x_niewolnik - x_kitku);
            float d_z = (z_niewolnik - z_kitku);

            //decyzja, w którym kierunku iść 
            if (System.Math.Abs(d_x) > System.Math.Abs(d_z))
            {
                if (d_x < 0)
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.right);
                }
                else
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.left);
                }
            }
            else
            {
                if (d_z > 0)
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.back);
                }
                else
                {
                    transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.VelocityChange);
                    transform.GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(Vector3.forward);
                }
            }


        }


    }
}
