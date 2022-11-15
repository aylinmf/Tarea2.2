using EjercicioA2_2.Models;
using PM2P2_T2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;

namespace EjercicioA2._2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            if (App.DBase != null) { }

        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            

        }



        //Guardar firma
        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            if (Pantalla.IsBlank)
            {
                Message("Debes Ingresar Una firma.");
                return;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                Message("Debes ingresar un nombre y descripcion a la firma.");
                return;
            }


            //Para limpiar -- Sign.Clear();
            Stream img = await Pantalla.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)img;
            Byte[] bytes = mStream.ToArray();
            var signature = new signature()
            {
                Id = 0,
                Nombre = txtNombre.Text,
                Descripcion= txtDescription.Text,
                ArrayByteImage = bytes
            };


            var folderPath = "/storage/emulated/0/Android/data/com.companyname.ejercicioa2._2/files/Pictures";
            var nameSignature = "";
            if (await new service().saveSignatures(signature))
            {

                try
                {
                    //Validacion para q se cree la carpeta donde se guardaran las imagenes

                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);


                    //if(!File.Exists(Path.GetFileName(folderPath + "/" + txtName)))

                    nameSignature = txtNombre.Text + DateTime.Now.ToString("MMddyyyyhhmmss"); ;

                    File.WriteAllBytes(folderPath + "/" + nameSignature + ".png", signature.ArrayByteImage);

                    Message("La firma se guardo correctamente!! \nPath:" + folderPath + "/" + nameSignature + ".png");
                }
                catch
                {
                    Message("Exito, Se Guardo Correctamente!!");
                }



                clear();
            }
            else Message("La firmar no se pudo guardar correctamente!!");
        }


        private void clear()
        {
            txtNombre.Text = null;
            txtDescription.Text = null;

            Pantalla.Clear();
        }

        public async void Message(string msg)
        {
            await DisplayAlert("Notificacion", msg, "OK");
        }

        private async void buttonlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListPage());
        }
    }
}