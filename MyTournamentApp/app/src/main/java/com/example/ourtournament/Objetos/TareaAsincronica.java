package com.example.ourtournament.Objetos;

import android.app.ActivityManager;
import android.os.AsyncTask;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;

import androidx.fragment.app.Fragment;

import com.example.ourtournament.MainActivity;
import com.example.ourtournament.R;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonElement;
import com.google.gson.JsonParser;
import com.google.gson.JsonPrimitive;
import com.squareup.picasso.Picasso;

import org.json.JSONStringer;

import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class TareaAsincronica {

    String Ruta1;
    String RutaFoto;
    public TareaAsincronica()
    {
        String baseUrl = String.valueOf(R.string.url);
        Ruta1 = baseUrl + "/api/";
        RutaFoto = baseUrl + "/api/Imagenes/";
    }
    public String RealizarTarea(String Ruta2)
    {
        String Respuesta = null;
        try {
            String miURL = Ruta1 + Ruta2;
            URL miRuta = new URL(miURL);
            Log.d("conexion", "estoy accediendo a la ruta: " + miURL);
            HttpURLConnection miConexion = (HttpURLConnection) miRuta.openConnection();
            miConexion.setRequestMethod("GET");
            if (miConexion.getResponseCode() == 200) {
                Log.d("conexion", "Me conecte perfectamente");
                InputStream lector = miConexion.getInputStream();
                InputStreamReader lectorJSon = new InputStreamReader(lector, "utf-8");
                JsonParser parseador = new JsonParser();

                Respuesta = parseador.parse(lectorJSon).toString();
                Log.d("conexion", "Devolvi: "+String.valueOf(Respuesta));
                miConexion.disconnect();
            } else {
                Log.d("Conexion", "Me pude conectar pero algo malo pasó");
            }
        }catch (Exception ErrorOcurrido) {
            Log.d("Conexion", "Al conectar o procesar ocurrió Error: " + ErrorOcurrido.getMessage());
        }
        return Respuesta;
    }

    public void CargarFoto(final String Ruta, final ImageView Foto, final int Num)
    {
        String URL = RutaFoto+Ruta;
        Picasso.get().load(URL)
                .into(Foto, new com.squareup.picasso.Callback() {
                    @Override
                    public void onSuccess() {
                    }

                    @Override
                    public void onError(Exception e) {
                        switch (Num)
                        {
                            case 1:
                                Foto.setImageResource(R.drawable.icono_torneo);
                                break;
                            case 2:
                                Foto.setImageResource(R.drawable.icono_persona);
                                break;
                            case 3:
                                Foto.setImageResource(R.drawable.icono_equipo);
                                break;
                            case 4:
                                Foto.setImageResource(R.drawable.imagen_error);
                                break;
                        }
                    }
                });
    }
}
