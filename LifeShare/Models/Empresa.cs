using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LifeShare.Models
{
    public class Empresa
    {

        //prop -> tab tab
        [HiddenInput]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data de Entrada")] //texto do label
        [DataType(DataType.Date)] // input type="date"
        public DateTime DataEntrada{ get; set; }
        public Status Status { get; set; }

    }
}
