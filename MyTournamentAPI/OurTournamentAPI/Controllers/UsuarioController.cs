﻿using OurTournamentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace OurTournamentAPI.Controllers
{
    public class UsuarioController : ApiController
    {
      
        [HttpGet]
        [Route("api/GetTorneosSeguidosPorUsuario/Usuario/{IDUsuario}")]
        public IHttpActionResult ObtenerTorneosSeguidosPorUsuario(int IDUsuario)
        {
            List<TorneoParticipacion> Lista = new List<TorneoParticipacion>();
            QQSM Conexion = new QQSM();
            Lista = Conexion.TraerTorneosSeguidosPorUsuario(IDUsuario);
            if (Lista != null)
            {
                return Ok(Lista);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetTorneosParticipadosPorUsuario/Usuario/{IDUsuario}")]
        public IHttpActionResult ObtenerTorneosParticipadosPorUsuario(int IDUsuario)
        {
            List<TorneoParticipacion> Lista = new List<TorneoParticipacion>();
            QQSM Conexion = new QQSM();
            Lista = Conexion.TraerTorneosParticipadosPorUsuario(IDUsuario);
            if (Lista != null)
            {
                return Ok(Lista);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/InsertTorneosSeguidos")]
        [HttpPost]
        public IHttpActionResult InsertarTorneoSeguidoPorUsuario(List<int> LISTA)
        {
            QQSM Conexion = new QQSM();
            //IDUsuario, IDTorneo,IDEquipo
            return Ok(Conexion.InsertarTorneoSeguidoPorUsuario(LISTA));
        }

        [Route("api/DeleteTorneosSeguidos")]
        [HttpDelete]
        public IHttpActionResult EliminarTorneoSeguidoPorUsuario(List<int> LISTA)
        {
            QQSM Conexion = new QQSM();
            Conexion.DeleteTorneoSeguidoPorUsuario(LISTA); //IDUsuario, IDTorneo
            return Ok();
        }

        [HttpGet]
        [Route("api/GetGoleadores/Torneo/{IDTorneo}")]
        public IHttpActionResult TraerListaGoleadores(int IDTorneo)
        {
            List<Goleadores> Lista = new List<Goleadores>();
            QQSM Conexion = new QQSM();
            Lista = Conexion.TraerListaGoleadores(IDTorneo);
            if (Lista != null)
            {
                return Ok(Lista);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpGet]
        [Route("api/GetUsuarioPorID/Usuario/{IDUsuario}")]
        public IHttpActionResult ObtenerUsuarioID(int IDUsuario)
        {
            QQSM Conexion = new QQSM();
            Usuario U = Conexion.TraerUsuariosPorID(IDUsuario);
            if (U != null)
            {
                return Ok(U);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/GetUsuarioPorContrasenia/Usuario/{Nombre}/contrasenia/{Contrasenia}")]
        public IHttpActionResult ObtenerUsuarioPorContrasenia(String Nombre, String Contrasenia)
        {
            QQSM Conexion = new QQSM();
            Usuario U = Conexion.TraerUsuarioPorNombreContrasenia(Nombre, Contrasenia);
            if (U.NombreUsuario != null)
            {
                return Ok(U);
            }
            else
            {
                Usuario Us = new Usuario(0, "", "", U.FechaDeNacimiento, "", -10,0);
                return Ok(Us);
            }
        }

        [Route("api/InsertUsuario")]
        [HttpPost]
        public IHttpActionResult InsertarUsuarios(Usuario U)
        {
            QQSM Conexion = new QQSM();
            Usuario US = new Usuario(U.IdUsuario,U.NombreUsuario, U.Contrasenia, U.FechaDeNacimiento, U.Email, U.GolesEnTorneo,U.IDTipo);
            int Devolver = Conexion.InsertarUsuario(US);
            return Ok(Devolver);
        }

        [Route("api/InsertJugadoresxEquipos")]
        [HttpPost]
        public IHttpActionResult InsertarJugadoresxEquipos(List<int> lista)
        {
            int Devolver;
            QQSM Conexion = new QQSM();
            Devolver = Conexion.InstertarJugadoresXEquipos(lista);
            return Ok(Devolver);
        }

        [HttpGet]
        [Route("api/GetUsuariosEnEspera/Torneo/{IDTorneo}")]
        public IHttpActionResult ObtenerUsuarioPorContrasenia(int IDTorneo)
        {
            QQSM Conexion = new QQSM();
            List<ListaEspera> ListaUsuarios = Conexion.TraerListaDeEspera(IDTorneo);
            return Ok(ListaUsuarios);
        }
    }
}
