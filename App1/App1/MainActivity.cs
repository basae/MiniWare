using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RestSharp;
using System.Collections.Generic;
using App1.Models;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        ListView lista;
        List<MensajeGeneral> Mensajes;
        public ArrayAdapter<MensajeGeneral> adapter;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var restClient = new RestClient("http://10.10.24.127:89");

            var request = new RestRequest("api/mensajepersonal/3",Method.GET);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Text = "Obtener Mensajes";
            lista = FindViewById<ListView>(Resource.Id.listView1);

            adapter=new ArrayAdapter<MensajeGeneral>(this,Android.Resource.Layout.SimpleListItem1);
            lista.Adapter=adapter;

            button.Click +=(object o, EventArgs e)=>
                {
                    adapter.Clear();
                    Mensajes = restClient.Execute<List<MensajeGeneral>>(request).Data;
                    foreach (MensajeGeneral json in Mensajes)
                    {
                        adapter.Add("De: " + json.De + "\nFecha de Cierre:" + json.FechaCierre);
                    }
                };

            lista.ItemClick+=lista_ItemClick;
        }
        void lista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Widget.Toast.MakeText(this,"Descripcion:" + Mensajes[e.Position].Descripcion,Android.Widget.ToastLength.Long).Show();
        }
    }
}