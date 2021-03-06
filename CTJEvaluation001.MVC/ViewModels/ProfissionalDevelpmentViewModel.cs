﻿using CTJEvaluation001.Domain.Entities;
using System;

namespace CTJEvaluation001.MVC.ViewModels
{
    public class ProfissionalDevelpmentViewModel
    {
        public string Chapa { get; set; }
        public int? Ano { get; set; }
        public int? Nseq { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public int? ImagemId { get; set; }
        public FileUpload Imagem { get; set; }
    }
}