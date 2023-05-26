using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.DataTransferObjects
{
    public class AvaliacaoDto
    {
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDate { get; set; }

        public string Image { get; set; }

        public byte Rating { get; set; }

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int PrestadorId { get; set; }
        public Prestador Prestador { get; set; }   
    }
}