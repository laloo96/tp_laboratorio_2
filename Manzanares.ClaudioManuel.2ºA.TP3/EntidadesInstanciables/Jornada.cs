﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using System.IO;


namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private List<Alumno> _alumno;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;

        #region Contructores
        private Jornada()
        {
                     
        }

        public Jornada(Gimnasio.EClases clase,Instructor instructor)
        {
            this._alumno = new List<Alumno>();
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        
        #region Propiedades
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._alumno.Count)
                    return this[i];
                else
                    return null;
            }
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Verifica que alumno no este en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j,Alumno a)
        {
            return !(j==a);
        }
        /// <summary>
        /// Verifica que alumno este en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumno)
            {
                if (j._alumno.Contains(a))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Agrega un alumno a la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool repetido = false;

            foreach (Alumno item in j._alumno)
            {
                if (item == a)
                {
                    repetido = true;                    
                }
            }

            if (!repetido)
                j._alumno.Add(a);
          
            return j;
        }
        /// <summary>
        /// Hace publicos los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("JORNADA:");
            str.AppendLine("CLASE DE " + this._clase + " POR ");
            str.Append(this._instructor.ToString());
            foreach (Alumno item in this._alumno)
            {
                str.AppendLine(item.ToString());
            }

            str.AppendLine("<------------------------------------------------>");

            return str.ToString();                      
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la Jornada pasada como parametro en la ruta especificada.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            if (text.guardar("Jornada.txt", jornada.ToString()))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
