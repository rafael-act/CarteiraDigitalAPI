﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    [Table("transacao")]
    public class Transacao : DbContext
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Column("id")]
        public int? Id { get; set; }
        [Column("dataoperacao")]
        public DateTime DataOperacao { get; set; }
        [Column("tipooperacao")]
        public string TipoOperacao { get; set; }
        [Column("valoroperacao")]
        public decimal ValorOperacao { get; set; }
        [Column("carteirasacadoid")]
        public int? carteirasacadoid { get; set; }
        [Column("carteiracedenteid")]
        public int? carteiracedenteid { get; set; }
        public virtual Carteira? CarteiraSacado { get; set; }
        public virtual Carteira? CarteiraCedente { get; set; }
    }
}
